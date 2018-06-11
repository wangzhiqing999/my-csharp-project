using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyHelp.Model;


namespace MyHelp.DataAccess
{

    // Enable-Migrations -ProjectName MyHelp.DataAccess  -EnableAutomaticMigrations
   
    public class MyHelpContext : DbContext
    {

        public MyHelpContext()
            : base("name=MyHelpContext")
        {
        }


        /// <summary>
        /// 帮助文档
        /// </summary>
        public DbSet<HelpDocument> HelpDocuments { get; set; }


        /// <summary>
        /// 帮助文档关键字
        /// </summary>
        public DbSet<HelpKeyword> HelpKeywords { get; set; }



        
        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 多对多的关系， 定义在下面
            // 一对多的， 定义在自己的 Config 里面.


            // 帮助文档 与 帮助文档关键字  多对多关系.
            modelBuilder.Entity<HelpDocument>()
                .HasMany(t => t.HelpKeywordList)
                .WithMany(a => a.HelpDocumentList)
                .Map(m =>
                {
                    // 多对多所使用的表.
                    m.ToTable("my_help_doc_keyword");
                    // 帮助文档 表的主键
                    m.MapLeftKey("document_id");
                    // 帮助文档关键字 表的主键.
                    m.MapRightKey("keyword_id");
                });

        }

    }

}
