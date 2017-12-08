using NWEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NWEmployee.DAL
{
    public class NorthwestContext: DbContext
    {
        public NorthwestContext(): base("NorthwestContext")
        {

        }

        public DbSet<Customers> customers { get; set; }
        public DbSet<Potential_Customers> p_customers { get; set; }
        public DbSet<Invoices> invoices { get; set; }

    }
}
