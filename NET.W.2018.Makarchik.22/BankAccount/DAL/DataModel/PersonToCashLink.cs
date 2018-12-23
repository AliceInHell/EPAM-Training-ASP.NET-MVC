using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.DAL.DataModel
{
    /// <summary>
    /// Bind person to cash in DB
    /// </summary>
    public class PersonToCashLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonToCashLink"/> class
        /// </summary>
        public PersonToCashLink() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonToCashLink"/> class
        /// </summary>
        /// <param name="personId">Person id</param>
        /// <param name="cashId">Person cash</param>
        public PersonToCashLink(string personId, string cashId, string id)
        {
            PersonId = personId;
            CashId = cashId;
            Id = id;
        }

        /// <summary>
        /// Person id
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Cash id
        /// </summary>
        public string CashId { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
}
