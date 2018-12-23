using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace BankAccount.DAL.DataModel
{
    public class AccountsStorageContext : DbContext
    {        
        public AccountsStorageContext()
            : base("name=AccountsStorageContext")
        {
        }

        public DbSet<PersonInfo> Persons { get; set; }  
        public DbSet<CashInfo> Cashes { get; set; }     
        public DbSet<PersonToCashLink> Links { get; set; } 
    }
}
