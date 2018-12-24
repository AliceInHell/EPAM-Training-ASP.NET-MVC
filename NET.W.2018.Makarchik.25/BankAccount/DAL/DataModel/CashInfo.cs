using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.DAL.DataModel
{
    /// <summary>
    /// Store cash information
    /// </summary>
    public class CashInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashInfo"/> class
        /// </summary>
        public CashInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CashInfo"/> class
        /// </summary>
        /// <param name="id">Cash id </param>
        /// <param name="amount">Money in cash</param>
        /// <param name="currency">Cash currency</param>
        /// <param name="cashType">Cash type</param>
        public CashInfo(string id, double amount, int currency, int cashType)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            CashType = cashType;            
        }

        /// <summary>
        /// Cash id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Money in cash
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Cash currency
        /// </summary>
        public int Currency { get; set; }

        /// <summary>
        /// Cash type
        /// </summary>
        public int CashType { get; set; }
    }
}
