using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    /// <summary>
    /// Bonus calculator
    /// </summary>
    public class BonusCalculator : IBonusCalculator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BonusCalculator"/> class
        /// </summary>
        /// <param name="amountCoefficient"></param>
        /// <param name="valueCoefficient"></param>
        public BonusCalculator(double amountCoefficient, double valueCoefficient)
        {
            AmountCoefficient = amountCoefficient;
            ReplenishValueCoefficient = valueCoefficient;
        }

        /// <summary>
        /// coefficient for calculating bonuses
        /// </summary>
        public double AmountCoefficient { get; set; }

        /// <summary>
        /// coefficient for calculating bonus
        /// </summary>
        public double ReplenishValueCoefficient { get; set; }

        /// <summary>
        /// Calculating logic
        /// </summary>
        /// <param name="value">Replenish value</param>
        /// <param name="amount">Current cash</param>
        /// <returns>Bonuses</returns>
        public int CalculateBonuses(double value, double amount)
        {
            return (int)((value * ReplenishValueCoefficient) + (amount * AmountCoefficient));
        }
    }
}
