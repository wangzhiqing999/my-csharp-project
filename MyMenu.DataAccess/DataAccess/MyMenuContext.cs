using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;

using MyMenu.Model;



namespace MyMenu.DataAccess
{

    //  Enable-Migrations -ProjectName MyMenu.DataAccess  -EnableAutomaticMigrations
    public class MyMenuContext : DbContext
    {

        public MyMenuContext()
            : base("name=MyMenuContext")
        {
        }


        /// <summary>
        /// 菜单.
        /// </summary>
        public DbSet<Menu> Menus { get; set; }



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
