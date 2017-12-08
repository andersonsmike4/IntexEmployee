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
    }
}