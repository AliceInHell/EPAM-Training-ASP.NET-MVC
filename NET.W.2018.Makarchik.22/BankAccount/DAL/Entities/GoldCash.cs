using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.DAL.Interfaces;

namespace BankAccount.DAL.Account
{
    public class GoldCash : ICash
    {
        /// <summary>
        /// constructor, coefficient initialization
        /// </summary>
        public GoldCash(IBonusCalculator calculator, string id)
        {
            BonusesCalculator = calculator;
            Id = id;
            Amount = 0.0;
        }

        /// <summary>
        /// amount of money
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Cash id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Bonuses calculator
        /// </summary>
        public IBonusCalculator BonusesCalculator { get; }

        /// <summary>
        /// add amount to amount
        /// </summary>
        /// <param name="value">amount</param>
        /// <returns>bonus</returns>
        public int Replenish(double value)
        {
            if (Amount + value <= 10000000)
            {
                double tmpAmount = Amount;
                Amount += value;

                return BonusesCalculator.CalculateBonuses(value, tmpAmount);
            }
            else
            {
                throw new ArgumentException("wrong value");
            }
        }

        /// <summary>
        /// subtract from amount
        /// </summary>
        /// <param name="value">amount</param>
        public void Debit(double value)
        {
            if (Amount - value < 0)
            {
                throw new ArgumentException("no such amount");
            }
            else
            {
                Amount -= value;
            }
        }

        /// <summary>
        /// Get cash type
        /// </summary>
        /// <returns>Cash type</returns>
        public CashType GetCashType()
        {
            return CashType.GoldCash;
        }
    }
}
