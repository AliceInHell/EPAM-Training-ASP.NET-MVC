﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class PlatinumCash : ICash
    {
        /// <summary>
        /// constructor, coefficient initialization
        /// </summary>
        public PlatinumCash(IBonusCalculator calculator)
        {
            BonusesCalculator = calculator;
            Amount = 0.0;
        }

        /// <summary>
        /// amount of money
        /// </summary>
        public double Amount { get; set; }

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
    }
}
