using System;
using System.Threading.Tasks;
using System.Net.Mail;
using BankAccount.BLL.Interfaces;
using BankAccount.DAL.Account;
using BankAccount.DAL.Interfaces;

namespace BankAccount.BLL.Bank
{
    /// <summary>
    /// Simple bank
    /// </summary>
    public class Bank : IBank
    {
        #region Fields

        /// <summary>
        /// Account storage
        /// </summary>
        private IStorage _storage;

        /// <summary>
        /// Account id generator
        /// </summary>
        private IIdGenerator _idGenerator;

        /// <summary>
        /// Currency converter
        /// </summary>
        private CurrencyConverter _converter;

        /// <summary>
        /// Bank mail
        /// </summary>
        private readonly string _mail;

        /// <summary>
        /// Bank mail password
        /// </summary>
        private readonly string _mailPassword;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="storage">Inner storage</param>        
        public Bank(IStorage storage, IIdGenerator idGenerator, string mail, string mailPassword)
        {
            _idGenerator = idGenerator;
            _storage = storage;
            _mail = mail;
            _mailPassword = mailPassword;
        }

        /// <summary>
        /// Update currency converter coefficients
        /// </summary>
        /// <param name="coefficients">Coefficients</param>
        public void UpdateExchangeRate(double[] coefficients)
        {
            _converter = new CurrencyConverter(coefficients);
        }

        #region Account routine

        /// <summary>
        /// Creates new account of the given type and adds it to the storage
        /// </summary>
        /// <param name="accType"></param>
        /// <param name="owner"></param>
        /// <returns>account's id</returns>
        public string CreateNewAccount(string name, string surName, string mail)
        {
            if (name.Equals(string.Empty) || surName.Equals(string.Empty))
            {
                throw new ArgumentNullException();
            }

            Account newAccount = new Account(_idGenerator.Generate(), name, surName, mail);
            _storage.Add(newAccount);

            Notify(newAccount, "You have successfully created new account");

            return newAccount.Id;
        }

        /// <summary>
        /// Add cash to account
        /// </summary>
        /// <param name="id">Account ud</param>
        /// <param name="currency">New cash currency</param>
        /// <param name="cash">Cash type</param>
        public void AddCash(string id, Currency currency, ICash cash)
        {
            Account tmp = _storage.GetAccountById(id);
            if (tmp.AddCash(currency, cash))
            {
                _storage.UpdateAccount(tmp);

                Notify(tmp, string.Format("You have successfully added new {0} cash", currency));
            }            
        }

        /// <summary>
        /// Deletes account with given id from the storage
        /// </summary>
        /// <param name="accType"></param>
        public void DeleteAccount(string id)
        {
            Account tmp = _storage.GetAccountById(id);

            Notify(tmp, "You have deleted an account");

            _storage.Remove(id);
        }

        /// <summary>
        /// Provides deposit operation for account with given id and amount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Deposit(string id, Currency currency, double amount)
        {
            Account tmp = _storage.GetAccountById(id);
            if (tmp.Debit(currency, amount))
            {
                _storage.UpdateAccount(tmp);

                Notify(tmp, string.Format(
                    "You have withdrawn {0} {1} from your account.\nBalance - {2} {3}",
                    amount,
                    currency,
                    tmp.Cash[currency].Amount,
                    currency));
            }            
        }

        /// <summary>
        /// Get account info
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns>Accoun to string</returns>
        public string GetAccountInfo(string id)
        {
            return _storage.GetAccountById(id).ToString();
        }

        /// <summary>
        /// Provides withdraw operation for account with given id and amount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Replenish(string id, Currency currency, double amount)
        {
            Account tmp = _storage.GetAccountById(id);
            if (tmp.Replenish(currency, amount))
            {
                _storage.UpdateAccount(tmp);

                Notify(tmp, string.Format(
                    "You have replenish your account.\nBalance - {0} {1}",
                    tmp.Cash[currency].Amount,
                    currency));
            }            
        }

        /// <summary>
        /// Transfer money between cashes
        /// </summary>
        /// <param name="sourceId">Source account id</param>
        /// <param name="destinationId">Destination account id</param>
        /// <param name="sourceCurrency">Source currency</param>
        /// <param name="destinationCurrency">Destination currency</param>
        /// <param name="amount">Transferring amount of money</param>
        public void Transfer(
            string sourceId,
            string destinationId,
            Currency sourceCurrency,
            Currency destinationCurrency,
            double amount)
        {
            Account sourceAccount = _storage.GetAccountById(sourceId);
            Account destinationAccount = _storage.GetAccountById(destinationId);

            if (sourceAccount.Transfer(_converter, destinationAccount, destinationCurrency, sourceCurrency, amount))
            {
                _storage.UpdateAccount(sourceAccount);
                _storage.UpdateAccount(destinationAccount);

                Notify(sourceAccount, string.Format(
                    "You have transferred {0} {1} from your account.\nBalance - {2} {3}",
                    amount,
                    sourceCurrency,
                    sourceAccount.Cash[sourceCurrency].Amount,
                    sourceCurrency));
            }            
        }

        #endregion        

        #region Save storage to the disk

        /// <summary>
        /// Saves the storage in file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAccounts(string filename)
        {
            _storage.SaveAccounts(filename);
        }        

        /// <summary>
        /// Loads the storage from file
        /// </summary>
        /// <param name="filename"></param>
        public void LoadAccounts(string filename)
        {
            _storage.LoadAccounts(filename);
        }

        #endregion

        #region Working with mail

        /// <summary>
        /// Notify user about any operation
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="operation">Performed operation</param>
        private async void Notify(Account account, string operation)
        {
            string message = string.Format(
                "Dear {0} {1}!\nThe following operation has been performed on your account:\n{2}", 
                account.SurName, 
                account.SurName,
                operation);

            await Task.Run(() => SendMail(account.Mail, message));
        }

        /// <summary>
        /// Send mail to account mail
        /// </summary>
        /// <param name="mail">Account mail</param>
        /// <param name="message">Message</param>
        private void SendMail(string mail, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(_mail, mail, "Bank operation notification", message);
                SmtpClient client = new SmtpClient
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(_mail, _mailPassword)
                };
                client.Send(mailMessage);
            }
            catch
            {
                // empty
            }
        }

        #endregion
    }
}