using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    /// <summary>
    /// cash interface
    /// </summary>
    public interface ICash
    {
        double Amount { set; get; }
        double AmountCoefficient { get; }
        double ReplenishValueCoefficient { get; }
        int Replenish(double value);
        void Debit(double value);
    }
}
