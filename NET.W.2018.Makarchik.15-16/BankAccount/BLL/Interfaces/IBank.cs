using BankAccount.DAL.Account;
using BankAccount.DAL.Interfaces;

namespace BankAccount.BLL.Interfaces
{
    public interface IBank
    {
        string CreateNewAccount(string name, string surName);
        void DeleteAccount(string id);
        void AddCash(string id, Currency currency, ICash cash);
        void Deposit(string id, Currency currency, double amount);
        void Replenish(string id, Currency currency, double amount);
        void SaveAccounts(string filename);
        void LoadAccounts(string filename);
    }
}
