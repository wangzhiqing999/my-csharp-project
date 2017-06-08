using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data.Entity;

using MyDocument.Config;
using MyDocument.Model;



namespace MyDocument.DataAccess
{

    //  Enable-Migrations -ProjectName MyDocument.DataAccess  -EnableAutomaticMigrations
    public class MyDocumentContext : DbContext
    {

        public MyDocumentContext()
            : base("name=MyDocumentContext")
        {
        }


        /// <summary>
        /// 文档类型.
        /// </summary>
        public DbSet<DocumentType> DocumentTypes { get; set; }


        /// <summary>
        /// 文档.
        /// </summary>
        public DbSet<Document> Documents { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // 文档类型 配置信息.
            modelBuilder.Configurations.Add(new DocumentTypeConfig());
        }


    }

}
