using System;
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
        /// <summary>
        /// Account storage
        /// </summary>
        private IStorage _storage;

        /// <summary>
        /// Account id generator
        /// </summary>
        private IIdGenerator _idGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class.
        /// </summary>
        /// <param name="storage">Inner storage</param>        
        public Bank(IStorage storage, IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
            _storage = storage;
        }

        /// <summary>
        /// Creates new account of the given type and adds it to the storage
        /// </summary>
        /// <param name="accType"></param>
        /// <param name="owner"></param>
        /// <returns>account's id</returns>
        public string CreateNewAccount(string name, string surName)
        {
            if (name.Equals(string.Empty) || surName.Equals(string.Empty))
            {
                throw new ArgumentNullException();
            }

            Account newAccount = new Account(_idGenerator.Generate(), name, surName);
            _storage.Add(newAccount);

            return newAccount.GetId();
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
            tmp.AddCash(currency, cash);
            _storage.UpdateAccount(tmp);
        }

        /// <summary>
        /// Deletes account with given id from the storage
        /// </summary>
        /// <param name="accType"></param>
        public void DeleteAccount(string id)
        {
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
            tmp.Debit(currency, amount);
            _storage.UpdateAccount(tmp);
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
            tmp.Replenish(currency, amount);
            _storage.UpdateAccount(tmp);
        }

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
    }
}
