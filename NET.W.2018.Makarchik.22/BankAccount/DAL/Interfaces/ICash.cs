using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.DAL.Account;

namespace BankAccount.DAL.Interfaces
{
    /// <summary>
    /// cash interface
    /// </summary>
    public interface ICash
    {
        string Id { get; }
        double Amount { get; set; }        
        IBonusCalculator BonusesCalculator { get; }
        int Replenish(double value);
        void Debit(double value);
        CashType GetCashType();
    }
}
