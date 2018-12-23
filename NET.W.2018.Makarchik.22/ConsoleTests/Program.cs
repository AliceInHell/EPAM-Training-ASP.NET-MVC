using System;
using BankAccount.BLL.Bank;
using BankAccount.DAL.Account;
using BankAccount.DAL.Storages;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IdGenerator idGenerator = new IdGenerator();

            // AccountStorage accountStorage = new AccountStorage();
            // Bank newBank = new Bank(accountStorage, idGenerator);

            DbAccountStorage storage = new DbAccountStorage();
            Bank newBank = new Bank(storage, idGenerator);
               
            string myId = newBank.CreateNewAccount("Vadim", "Makarchik");
            newBank.AddCash(myId, Currency.USD, new GoldCash(new BonusCalculator(0.05, 0.03), idGenerator.Generate()));
            newBank.Replenish(myId, Currency.USD, 10000.0);
            newBank.Deposit(myId, Currency.USD, 50.0);

            Console.WriteLine(newBank.GetAccountInfo(myId));            

            Console.ReadLine();
        }
    }
}
