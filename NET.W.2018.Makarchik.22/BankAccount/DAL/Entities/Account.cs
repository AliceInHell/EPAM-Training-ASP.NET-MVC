using System;
using System.Collections.Generic;
using System.IO;
using BankAccount.DAL.Interfaces;

namespace BankAccount.DAL.Account
{
    /// <summary>
    /// class for working with cash
    /// </summary>
    public class Account
    {
        #region Fields

        /// <summary>
        /// account id
        /// </summary>
        private string id;

        /// <summary>
        /// user's name
        /// </summary>
        private string name;

        /// <summary>
        /// user's surname
        /// </summary>
        private string surName;

        /// <summary>
        /// account bonus
        /// </summary>
        private int bonus;

        /// <summary>
        /// account cash
        /// </summary>
        private Dictionary<Currency, ICash> cash;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        public Account(string id, string name, string surName)
        {
            this.id = id;
            this.name = name;
            this.surName = surName;
            this.bonus = 0;
            cash = new Dictionary<Currency, ICash>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        /// <param name="bonus">user's start bonuses</param>
        public Account(string id, string name, string surName, int bonus)
        {
            this.id = id;
            this.name = name;
            this.surName = surName;
            this.bonus = bonus;
            cash = new Dictionary<Currency, ICash>();
        }

        #region user access 

        /// <summary>
        /// get account bonus
        /// </summary>
        /// <returns>available bonuses</returns>
        public int GetBonus()
        {
            return bonus;
        }

        /// <summary>
        /// subtract from bonus
        /// </summary>
        /// <param name="value">subtracting value</param>
        public void DebitBnuce(int value)
        {
            if (value != 0 && value <= bonus)
            {
                bonus -= value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// get account id
        /// </summary>
        /// <returns>user's id</returns>
        public string GetId()
        {
            if (id.Equals(string.Empty))
            {
                throw new ArgumentException("wrong id");
            }

            return id;
        }

        /// <summary>
        /// get account owner's name and surname
        /// </summary>
        /// <returns>owner's name</returns>
        public string GetAccountOwner()
        {
            if (name == null || name.Equals(string.Empty) || surName == null || surName.Equals(string.Empty))
            {
                throw new ArgumentException();
            }

            return name + " " + surName;
        }

        /// <summary>
        /// Get accoun owner name
        /// </summary>
        /// <returns>Name</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Get account owner surname
        /// </summary>
        /// <returns>Surname</returns>
        public string GetSurname()
        {
            return surName;
        }

        /// <summary>
        /// Get all account cashes
        /// </summary>
        /// <returns>cashes</returns>
        public Dictionary<Currency, ICash> GetCahes()
        {
            return this.cash;
        }

        #endregion

        #region methods for work with cash

        /// <summary>
        /// add new cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="cash">cash kind</param>
        public void AddCash(Currency key, ICash cash)
        {
            if (!this.cash.ContainsKey(key))
            {
                this.cash[key] = cash;                
            }
            else
            {
                throw new ArgumentException(string.Format("cash {0} already exists", key));
            }
        }

        /// <summary>
        /// change existing cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="cash">cash kind</param>
        public void ChangeCash(Currency key, ICash cash)
        {
            if (this.cash.ContainsKey(key))
            {
                double tempAmount = this.cash[key].Amount;
                this.cash[key] = cash;
                Replenish(key, tempAmount);                
            }
            else
            {
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
            }
        }

        /// <summary>
        /// close existing cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        public void CloseCash(Currency key)
        {
            if (cash.ContainsKey(key))
            {
                cash.Remove(key);                
            }
            else
            {
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
            }
        }

        #endregion

        #region methods for work with cash amount

        /// <summary>
        /// add sum to cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="value">replenishing money</param>
        public void Replenish(Currency key, double value)
        {
            if (cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    bonus += cash[key].Replenish(value);                    
                }
                else
                {
                    throw new ArgumentException("wrong value");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
            }
        }

        /// <summary>
        /// subtract sum from cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="value">subtracting money</param>
        public void Debit(Currency key, double value)
        {
            if (cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    cash[key].Debit(value);                    
                }
                else
                {
                    throw new ArgumentException("wrong value");
                }
            }
            else
            {
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
            }
        }

        /// <summary>
        /// get existing cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <returns>cash amount</returns>
        public double GetAmount(Currency key)
        {           
            if (cash.ContainsKey(key))
            {
                double tmp = cash[key].Amount;
                cash.Clear();

                return tmp;
            }
            else
            {
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
            }
        }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns>Account to string</returns>
        public override string ToString()
        {
            string result = string.Format("{0} {1} {2}  :", id, name, surName);

            foreach(var item in cash)
            {
                result += string.Format("\n {0} : {1}", item.Key, item.Value.Amount);
            }
            result += string.Format("\nBonuses : {0}", GetBonus());

            return result;
        }

        #endregion
    }
}
