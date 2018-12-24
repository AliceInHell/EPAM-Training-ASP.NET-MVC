using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount.DAL.Interfaces;
using BankAccount.DAL.DataModel;
using BankAccount.DAL.Account;
using BankAccount.BLL.Interfaces;

namespace BankAccount.DAL.Storages
{
    /// <summary>
    /// Database storage representation
    /// </summary>
    public class DbAccountStorage : IStorage
    {
        /// <summary>
        /// Inner random
        /// </summary>
        private static Random rand = new Random();

        /// <summary>
        /// Data set
        /// </summary>
        private static string sourceString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Add account to database using storage structures
        /// </summary>
        /// <param name="account">Additing account</param>
        public void Add(Account.Account account)
        {
            using (AccountsStorageContext context = new AccountsStorageContext())
            {
                PersonInfo pi = new PersonInfo(account.Id, account.Name, account.SurName, account.Mail, account.Bonus);
                context.Persons.Add(pi);

                foreach (var cashInfo in account.Cash)
                {
                    CashInfo ci = new CashInfo(cashInfo.Value.Id, cashInfo.Value.Amount, (int)cashInfo.Key, (int)cashInfo.Value.GetCashType());
                    context.Cashes.Add(ci);

                    PersonToCashLink link = new PersonToCashLink(account.Id, cashInfo.Value.Id, GenerateLinkId());
                    context.Links.Add(link);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get account using id
        /// </summary>
        /// <param name="accId">Account id</param>
        /// <returns>Founded account</returns>
        public Account.Account GetAccountById(string accId)
        {
            using (AccountsStorageContext context = new AccountsStorageContext())
            {
                PersonInfo pi = context.Persons.SingleOrDefault(person => person.Id == accId);

                if (pi != null)
                {
                    Account.Account foundedAccount = new Account.Account(pi.Id, pi.Name, pi.SurName, pi.Mail, pi.Bonus);

                    List<PersonToCashLink> links = context.Links.Where(link => link.PersonId == pi.Id).ToList();
                    foreach (PersonToCashLink link in links)
                    {
                        CashInfo ci = context.Cashes.SingleOrDefault(cashInfo => cashInfo.Id == link.CashId);

                        switch ((CashType)ci.CashType)
                        {
                            case CashType.BaseCash:
                                BaseCash baseCash = new BaseCash(new BonusCalculator(0.05, 0.03), ci.Id);
                                baseCash.Amount = ci.Amount;
                                foundedAccount.AddCash((Currency)ci.Currency, baseCash);
                                break;
                            case CashType.GoldCash:
                                GoldCash goldCash = new GoldCash(new BonusCalculator(0.05, 0.03), ci.Id);
                                goldCash.Amount = ci.Amount;
                                foundedAccount.AddCash((Currency)ci.Currency, goldCash);
                                break;
                            case CashType.PlatinumCash:
                                PlatinumCash platinumCash = new PlatinumCash(new BonusCalculator(0.05, 0.03), ci.Id);
                                platinumCash.Amount = ci.Amount; 
                                foundedAccount.AddCash((Currency)ci.Currency, platinumCash);
                                break;
                        }
                    }

                    return foundedAccount;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account">Account</param>
        public void UpdateAccount(Account.Account account)
        {
            using (AccountsStorageContext context = new AccountsStorageContext())
            {
                string accountId = account.Id;
                PersonInfo pi = context.Persons.SingleOrDefault(person => person.Id == accountId);

                if (pi != null)
                {
                    Remove(pi.Id);
                    Add(account);
                }
            }
        }

        public void LoadAccounts(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove account from database
        /// </summary>
        /// <param name="accId">Account id</param>
        public void Remove(string accId)
        {
            using (AccountsStorageContext context = new AccountsStorageContext())
            {
                PersonInfo pi = context.Persons.SingleOrDefault(person => person.Id == accId);

                if (pi != null)
                {
                    context.Persons.Remove(pi);

                    List<PersonToCashLink> links = context.Links.Where(link => link.PersonId == pi.Id).ToList();
                    foreach (PersonToCashLink link in links)
                    {
                        CashInfo ci = context.Cashes.SingleOrDefault(cashInfo => cashInfo.Id == link.CashId);
                        context.Cashes.Remove(ci);

                        context.Links.Remove(link);
                    }

                    context.SaveChanges();
                }
            }
        }

        public void SaveAccounts(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Link id generation
        /// </summary>
        /// <returns>Id</returns>
        private string GenerateLinkId()
        {
            string result = string.Empty;
            for (int i = 0; i < 32; i++)
            {
                result += sourceString[rand.Next(0, sourceString.Length - 1)];
            }

            return result;
        }
    }
}
