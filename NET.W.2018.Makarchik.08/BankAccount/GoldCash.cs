﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class GoldCash : ICash
    {
        public double Amount { set; get; }
        public double AmountCoefficient { get; }
        public double ReplenishValueCoefficient { get; }

        /// <summary>
        /// constructor, coefficient initialization
        /// </summary>
        public GoldCash()
        {
            Amount = 0.0;
            AmountCoefficient = 0.003;
            ReplenishValueCoefficient = 0.005;
        }

        /// <summary>
        /// add amount to amount
        /// </summary>
        /// <param name="value">amount</param>
        /// <returns>bonuces</returns>
        public int Replenish(double value)
        {
            if (Amount + value <= 10000000)
            {
                double tmp = Amount * AmountCoefficient;
                Amount += value;

                return (int)(value * ReplenishValueCoefficient + tmp);
            }
            else
                throw new ArgumentException("wrong value");
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
