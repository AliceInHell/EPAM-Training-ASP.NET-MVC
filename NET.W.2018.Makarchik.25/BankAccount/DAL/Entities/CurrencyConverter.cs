using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.DAL.Account
{
    /// <summary>
    /// Conver money between different currencies
    /// </summary>
    public class CurrencyConverter
    {
        /// <summary>
        /// Coefficients
        /// </summary>
        private readonly double[,] _matrix;

        /// <summary>
        /// Matrix rang
        /// </summary>
        private readonly int _rang;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyConverter"/> class
        /// </summary>
        /// <param name="coefficients">Coefficients</param>
        public CurrencyConverter(double[] coefficients)
        {
            if (coefficients.Length != _rang * _rang)
            {
                return;
            }

            _rang = Enum.GetNames(typeof(Currency)).Length;
            _matrix = new double[_rang, _rang];

            int k = 0;
            for (int i = 0; i < _rang; i++)
            {
                for (int j = 0; j < _rang; j++)
                {
                    _matrix[i, j] = coefficients[k++];                  
                }
            }
        }

        /// <summary>
        /// Convert money
        /// </summary>
        /// <param name="from">Source currency</param>
        /// <param name="to">Destination currency</param>
        /// <param name="amount">Converting amount of money</param>
        /// <returns>Converted money</returns>
        public double Convert(Currency from, Currency to, double amount)
        {
            if (_matrix != null)
            {
                return amount * _matrix[(int)from, (int)to];
            }
            else
            {
                throw new InvalidOperationException("Trouble with convertion matrix");
            }
        }
    }
}
