using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.DAL.DataModel;

namespace BankAccount.DAL.Interfaces
{
    public interface IStorage
    {
        void Add(Account.Account acc);
        void Remove(string accId);
        Account.Account GetAccountById(string accId);
        void SaveAccounts(string fileName);
        void LoadAccounts(string fileName);
        void UpdateAccount(Account.Account account);
        IEnumerable<PersonInfo> GetPersons();        
    }
}
