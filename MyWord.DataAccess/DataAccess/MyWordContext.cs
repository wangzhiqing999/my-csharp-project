using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyWord.Model;




namespace MyWord.DataAccess
{


    public class MyWordContext : DbContext
    {
        public MyWordContext()
            : base("name=MyWordContext")
        {
        }


        /// <summary>
        /// 词.
        /// </summary>
        public DbSet<Word> Words { get; set; }


    }

}
