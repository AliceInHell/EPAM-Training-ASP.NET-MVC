using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.DAL.DataModel
{
    /// <summary>
    /// Store person information
    /// </summary>
    public class PersonInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonInfo"/> class
        /// </summary>
        public PersonInfo() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class
        /// </summary>
        /// <param name="id">account ID</param>
        /// <param name="name">user's name</param>
        /// <param name="surName">user's surname</param>
        public PersonInfo(string id, string name, string surName, string mail, int bonus)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Mail = mail;
            Bonus = bonus;         
        }

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
    }
}
