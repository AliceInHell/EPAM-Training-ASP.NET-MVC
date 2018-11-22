using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount.DAL.Interfaces
{
    public interface IStorage
    {
        void Add(Account.Account acc);
        void Remove(string accId);
        Account.Account GetAccountById(string accId);
        void SaveAccounts(string fileName);
        void LoadAccounts(string fileName);
    }
}
