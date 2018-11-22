using System;
using NUnit.Framework;
using BankAccount.BLL.Bank;
using BankAccount.BLL.Interfaces;
using BankAccount.DAL.Account;
using BankAccount.DAL.Interfaces;

namespace NUnitBankTests
{
    [TestFixture]
    public class NUnitTestClass
    {
        private IdGenerator idGenerator = new IdGenerator();
        private AccountStorage accountStorage = new AccountStorage();
        private Bank newBank;

        [SetUp]
        public void SetUp()
        {
            newBank = new Bank(accountStorage, idGenerator);
        }
        
        [Test]
        public void AccountInfoTest()
        {
            string myId = newBank.CreateNewAccount("Vadim", "Makarchik");
            newBank.AddCash(myId, Currency.USD, new GoldCash(new BonusCalculator(0.05, 0.03)));
            newBank.Replenish(myId, Currency.USD, 10000.0);
            newBank.Deposit(myId, Currency.USD, 50.0);

            Account newAccount = new Account(myId, "Vadim", "Makarchik");
            newAccount.AddCash(Currency.USD, new GoldCash(new BonusCalculator(0.05, 0.03)));
            newAccount.Replenish(Currency.USD, 10000.0);
            newAccount.Debit(Currency.USD, 50.0);

            Assert.IsTrue(newBank.GetAccountInfo(myId).Equals(newAccount.ToString()));
        }        
    }
}