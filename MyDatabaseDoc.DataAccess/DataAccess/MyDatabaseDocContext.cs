using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyDatabaseDoc.DataAccess
{
    public class MyDatabaseDocContext : DbContext
    {

        public MyDatabaseDocContext()
            : base("name=MyDatabaseDocContext")
        {
        }

    }
}
