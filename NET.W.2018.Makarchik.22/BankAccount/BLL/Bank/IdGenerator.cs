using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccount.BLL.Interfaces;

namespace BankAccount.BLL.Bank
{
    /// <summary>
    /// Id generator
    /// </summary>
    public class IdGenerator : IIdGenerator
    {
        /// <summary>
        /// Inner random
        /// </summary>
        private static Random rand = new Random();

        /// <summary>
        /// Data set
        /// </summary>
        private static string sourceString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Generates new id
        /// </summary>
        /// <returns>string</returns>
        public string Generate()
        {
            string result = string.Empty;
            for (int i = 0; i < 32; i++)
            {
                result += sourceString[rand.Next(0, sourceString.Length - 1)];
            }

            return result;
        }
    }
}
