using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.BLL.Bank;
using BankAccount.BLL.Interfaces;
using BankAccount.DAL.Account;
using BankAccount.DAL.Interfaces;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IdGenerator idGenerator = new IdGenerator();
            AccountStorage accountStorage = new AccountStorage();
            Bank newBank = new Bank(accountStorage, idGenerator);
               
            string myId = newBank.CreateNewAccount("Vadim", "Makarchik");
            newBank.AddCash(myId, Currency.USD, new GoldCash(new BonusCalculator(0.05, 0.03)));
            newBank.Replenish(myId, Currency.USD, 10000.0);
            newBank.Deposit(myId, Currency.USD, 50.0);

            Console.WriteLine(newBank.GetAccountInfo(myId));            

            Console.ReadLine();
        }
    }
}
