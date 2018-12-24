using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount.DAL.Interfaces
{
    /// <summary>
    /// Interface for bonus calculators
    /// </summary>
    public interface IBonusCalculator
    {
        double AmountCoefficient { get; }
        double ReplenishValueCoefficient { get; }
        int CalculateBonuses(double value, double amount);
    }
}
