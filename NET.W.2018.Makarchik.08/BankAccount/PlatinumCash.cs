﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class PlatinumCash : ICash
    {
        public double Amount { set; get; }
        public double AmountCoefficient { get; }
        public double ReplenishValueCoefficient { get; }

        /// <summary>
        /// constructor, coefficient initialization
        /// </summary>
        public PlatinumCash()
        {
            Amount = 0.0;
            AmountCoefficient = 0.005;
            ReplenishValueCoefficient = 0.006;
        }

        /// <summary>
        /// add amount to amount
        /// </summary>
        /// <param name="value">amount</param>
        /// <returns>bonuces</returns>
        public int Replenish(double value)
        {
            double tmp = Amount * AmountCoefficient;
            Amount += value;

            return (int)(value * ReplenishValueCoefficient + tmp);
        }

        /// <summary>
        /// subtract from amount
        /// </summary>
        /// <param name="value">amount</param>
        public void Debit(double value)
        {
            if (Amount - value < 0)
                throw new ArgumentException("no such amount");
            else
                Amount -= value;
        }
    }
}
