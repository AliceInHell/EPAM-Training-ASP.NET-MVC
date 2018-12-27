using System.Collections.Generic;
using BankAccount.DAL.Account;
using BankAccount.DAL.Interfaces;
using BankAccount.DAL.DataModel;

namespace BankAccount.BLL.Interfaces
{
    public interface IBank
    {
        string CreateNewAccount(string name, string surName, string mail);
        void DeleteAccount(string id);
        void AddCash(string id, Currency currency, CashType cash);
        void Deposit(string id, Currency currency, double amount);
        void Replenish(string id, Currency currency, double amount);
        void Transfer(string sourceId, string destinationId, Currency sourceCurrency, Currency destinationCurrency, double amount);
        void CloseAccount(string id);
        void SaveAccounts(string filename);
        void LoadAccounts(string filename);
        IEnumerable<PersonInfo> GetPersons();
    }
}
