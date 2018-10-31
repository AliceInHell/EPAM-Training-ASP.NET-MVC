using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BankAccount
{
    public class Account
    {
        #region Fields

        private int id;
        private string name;
        private string surName;
        private int bonuce;
        private string logFilePath = "./Cash.bin";
        private Dictionary<Currency, ICash> cash;

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        public Account(int id, string name, string surName)
        {
            this.id = id;
            this.name = name;
            this.surName = surName;
            cash = new Dictionary<Currency, ICash>();
        }

        #region Properties

        /// <summary>
        /// get account bonuce
        /// </summary>
        /// <returns>bonuces</returns>
        public int GetBonuce()
        {
            return bonuce;
        }

        /// <summary>
        /// subtract from bonuce
        /// </summary>
        /// <param name="value">value</param>
        public void DebitBnuce(int value)
        {
            if (value != 0 && value <= bonuce)
            {
                bonuce -= value;
            }
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// get account id
        /// </summary>
        /// <returns>id</returns>
        public int GetId()
        {
            if (id == 0 || id.Equals(""))
                throw new ArgumentException("wrong id");

            return id;
        }

        /// <summary>
        /// get account owner's name and surname
        /// </summary>
        /// <returns>owner's name</returns>
        public string GetAccountOwner()
        {
            if (name == null || name.Equals("") || surName == null || surName.Equals(""))
                throw new ArgumentException();

            return name + " " + surName;
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
            LoadCash(logFilePath);

            if (!this.cash.ContainsKey(key))
            {
                this.cash[key] = cash;
                SaveCash(logFilePath);
            }
            else
                throw new ArgumentException(string.Format("cash {0} already exists", key));
        }

        /// <summary>
        /// change existing cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="cash">cash kind</param>
        public void ChangeCash(Currency key, ICash cash)
        {
            LoadCash(logFilePath);

            if (this.cash.ContainsKey(key))
            {
                double tempAmount = this.cash[key].Amount;
                this.cash[key] = cash;
                Replenish(key, tempAmount);

                SaveCash(logFilePath);
            }
            else
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
        }

        /// <summary>
        /// close existing cash
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        public void CloseCash(Currency key)
        {
            LoadCash(logFilePath);

            if (cash.ContainsKey(key))
            {
                cash.Remove(key);
                SaveCash(logFilePath);
            }
            else
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
        }

        #endregion

        #region methods for work with cash amount

        /// <summary>
        /// add sum to cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="value">money</param>
        public void Replenish(Currency key, double value)
        {
            LoadCash(logFilePath);

            if (cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    bonuce += cash[key].Replenish(value);
                    SaveCash(logFilePath);
                }
                else
                    throw new ArgumentException("wrong value");
            }
            else
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
        }

        /// <summary>
        /// subtract sum from cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <param name="value">money</param>
        public void Debit(Currency key, double value)
        {
            LoadCash(logFilePath); 

            if (cash.ContainsKey(key))
            {
                if (!double.IsInfinity(value) && !double.IsNaN(value) && Math.Abs(value) > 0.01)
                {
                    cash[key].Debit(value);
                    SaveCash(logFilePath);
                }
                else
                    throw new ArgumentException("wrong value");
            }
            else
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
        }

        /// <summary>
        /// get existing cash amount
        /// </summary>
        /// <param name="key">enumerable cash representation</param>
        /// <returns>cash amount</returns>
        public double getAmount(Currency key)
        {
            LoadCash(logFilePath);

            if (cash.ContainsKey(key))
            {
                double tmp = cash[key].Amount;
                cash.Clear();

                return tmp;
            }
            else
                throw new ArgumentNullException(string.Format("cash {0} does not exists", key));
        }

        #endregion

        #region methods for work with file

        /// <summary>
        /// load cash for work
        /// </summary>
        /// <param name="filePath">cash log file</param>
        private void LoadCash(string filePath)
        {
            if (File.Exists(filePath))
            {
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));

                try
                {
                    while (reader.BaseStream.Length != reader.BaseStream.Position)
                    {
                        int key = reader.ReadInt32();
                        ICash cash = (ICash)Activator.CreateInstance(
                            Type.GetType(reader.ReadString()));
                        cash.Amount = reader.ReadDouble();

                        this.cash.Add((Currency)key, cash);
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
            else
                throw new ArgumentNullException("file does not exists");
        }

        /// <summary>
        /// save cash to file
        /// </summary>
        /// <param name="filePath">path or a new file name</param>
        public void SaveCash(string filePath)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate));

            foreach (var item in cash)
            {
                writer.Write((int)item.Key);
                writer.Write(item.Value.GetType().ToString());
                writer.Write(item.Value.Amount);
            }

            writer.Close();

            //clear it after saving
            cash.Clear();
        }

        #endregion
    }
}
