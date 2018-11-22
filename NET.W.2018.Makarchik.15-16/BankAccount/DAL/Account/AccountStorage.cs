using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BankAccount.DAL.Interfaces;

namespace BankAccount.DAL.Account
{
    /// <summary>
    /// Account storage
    /// </summary>
    public class AccountStorage : IStorage
    {
        /// <summary>
        /// Account container
        /// </summary>
        private List<Account> accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStorage"/> class
        /// </summary>
        /// <returns>instance</returns>
        public AccountStorage()
        {
            accounts = new List<Account>();
        }

        #region Instance methods for interface

        /// <summary>
        /// Adds account to the list
        /// </summary>
        /// <param name="acc"></param>
        public void Add(Account acc)
        {
            accounts.Add(acc);
        }

        /// <summary>
        /// Removes account with given id from the list
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            accounts.Remove(GetAccountById(id));
        }

        /// <summary>
        /// Finds account in the list by given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public Account GetAccountById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            if (id == string.Empty)
            {
                throw new ArgumentException();
            }

            if (accounts.Count == 0)
            {
                throw new ArgumentException("No accounts in storage");
            }

            foreach (Account acc in accounts)
            {
                if (acc.GetId() == id)
                {
                    return acc;
                }
            }

            return null;
        }

        /// <summary>
        /// Converts byte array to the list of accounts
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>list</returns>
        public void LoadAccounts(string filename)
        {
            if (File.Exists(filename))
            {
                using (BinaryReader binReader = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    byte[] byteArr = binReader.ReadBytes((int)binReader.BaseStream.Length);
                    List<Account> loadedList = ByteArrayToList(byteArr);
                    if (loadedList != null)
                    {
                        RemoveExistingElements(loadedList);
                    }

                    accounts.AddRange(loadedList);
                }
            }
        }

        /// <summary>
        /// Saves accounts from the list in file.
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAccounts(string filename)
        {
            if (filename == null || filename.Length == 0)
            {
                throw new ArgumentNullException();
            }

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                byte[] byteArr = ListToByteArray(accounts);
                fs.Write(byteArr, 0, byteArr.Length);
            }
        }

        #endregion

        /// <summary>
        /// Convert bytes to account list
        /// </summary>
        /// <param name="arr">array</param>
        /// <returns>Account list</returns>
        private static List<Account> ByteArrayToList(byte[] arr)
        {
            List<Account> dserList;
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arr, 0, arr.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                dserList = (List<Account>)binForm.Deserialize(memStream);

                return dserList;
            }
        }

        /// <summary>
        /// Converts the list of accounts to byte array
        /// </summary>
        /// <param name="list"></param>
        /// <returns>array of bytes</returns>
        private static byte[] ListToByteArray(List<Account> list)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                binFormatter.Serialize(ms, list);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Removes accounts from the loaded list if they are already in the current list of accounts
        /// </summary>
        /// <param name="list"></param>
        private void RemoveExistingElements(List<Account> list)
        {
            foreach (Account oldAcc in accounts)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (oldAcc.GetId() == list[i].GetId())
                    {
                        list.Remove(list[i]);
                        i--;
                    }
                }
            }
        }
    }
}
