using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount.DAL.Interfaces
{
    /// <summary>
    /// cash interface
    /// </summary>
    public interface ICash
    {
        double Amount { set; get; }        
        IBonusCalculator BonusesCalculator { get; }
        int Replenish(double value);
        void Debit(double value);
    }
}
