using System;
using System.Collections.Generic;
using BankAccount.DAL.Interfaces;

namespace BankAccount.DAL.Account
{
    /// <summary>
    /// class for working with cash
    /// </summary>
    public class Account
    {      
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        public Account(string id, string name, string surName, string mail)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Mail = mail;
            Bonus = 0;
            Cash = new Dictionary<Currency, ICash>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        /// <param name="bonus">user's start bonuses</param>
        public Account(string id, string name, string surName, string mail, int bonus)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Mail = mail;
            Bonus = bonus;
            Cash = new Dictionary<Currency, ICash>();
        }

        #region Properties

        /// <summary>
        /// account id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// user's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// user's surname
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// User mail
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// account bonus
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// account cash
        /// </summary>
        public Dictionary<Currency, ICash> Cash { get;}

        #endregion

        #region User access         

        /// <summary>
        /// subtract from bonus
        /// </summary>
        /// <param name="value">subtracting value</param>
        public void DebitBnuce(int value)
        {
            if (value != 0 && value <= Bonus)
            {
                Bonus -= value;
            }
            else
            {
                throw new ArgumentException();
            }
        }        

        /// <summary>
        /// get account owner's name and surname
        /// </summary>
        /// <returns>owner's name</returns>
        public string GetAccountOwner()
        {
            if (Name == null || Name.Equals(string.Empty) || SurName == null || SurName.Equals(string.Empty))
            {
                throw new ArgumentException();
            }

            return Name + " " + SurName;
        }        

        #endregion

        #region Methods for work with cash

        /// <summary>
        /// add new cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="cash">cash kind</param>
        public bool AddCash(Currency key, ICash cash)
        {
            if (!this.Cash.ContainsKey(key))
            {
                this.Cash[key] = cash;
                return true;
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
        public bool ChangeCash(Currency key, ICash cash)
        {
            if (this.Cash.ContainsKey(key))
            {
                double tempAmount = this.Cash[key].Amount;
                this.Cash[key] = cash;
                Replenish(key, tempAmount);

                return true;
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
        public bool CloseCash(Currency key)
        {
            if (Cash.ContainsKey(key))
            {
                Cash.Remove(key);
                return true;
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
        public bool Replenish(Currency key, double value)
        {
            if (Cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    Bonus += Cash[key].Replenish(value);
                    return true;
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
        public bool Debit(Currency key, double value)
        {
            if (Cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    Cash[key].Debit(value);
                    return true;
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
        /// Transfer money between accounts
        /// </summary>
        /// <param name="converter">Money converter</param>
        /// <param name="destinationAccount">Destination Account</param>
        /// <param name="destinationCurrency">Destination currency</param>
        /// <param name="sourceCurrency">Source currency</param>
        /// <param name="transferringAmount">Amount of money</param>
        /// <returns>True if success</returns>
        public bool Transfer(
            CurrencyConverter converter, 
            Account destinationAccount, 
            Currency destinationCurrency, 
            Currency sourceCurrency, 
            double transferringAmount)
        {
            if (Cash.ContainsKey(sourceCurrency))
            {
                if (Cash[sourceCurrency].Amount >= transferringAmount)
                {
                    if (destinationAccount.Cash.ContainsKey(destinationCurrency))
                    {
                        this.Debit(sourceCurrency, transferringAmount);
                        destinationAccount.Replenish(
                            destinationCurrency, 
                            converter.Convert(sourceCurrency, destinationCurrency, transferringAmount));

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns>Account to string</returns>
        public override string ToString()
        {
            string result = string.Format("{0} {1} {2}  :", Id, Name, SurName);

            foreach(var item in Cash)
            {
                result += string.Format("\n {0} : {1}", item.Key, item.Value.Amount);
            }
            result += string.Format("\nBonuses : {0}", Bonus);

            return result;
        }

        #endregion        
    }
}
