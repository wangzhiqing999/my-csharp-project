using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

using MyFx678Kx.Model;




namespace MyFx678Kx.DataAccess
{


    // Enable-Migrations -ProjectName MyFx678Kx.DataAccess  -EnableAutomaticMigrations
    public class MyFx678KxContext : DbContext
    {

        public MyFx678KxContext()
            : base("name=MyFx678KxContext")
        {

        }



        /// <summary>
        /// 汇通网 快讯.
        /// </summary>
        public DbSet<Fx678Kx> Fx678Kxs { get; set; }


        



        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }


    }

}
