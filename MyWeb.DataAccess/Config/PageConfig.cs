using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyWeb.Model;

namespace MyWeb.Config
{

    public class PageConfig: EntityTypeConfiguration<Page>
    {
        public PageConfig()
        {
            // 一个 页面  允许 多个 菜单接入.
            this.HasMany(s => s.PageMenus)
                // 一个 菜单 可选跳转 一个 页面 .
                .WithOptional(m => m.MenuPage)
                // 外键的列是  PageCode
                .HasForeignKey(m => m.PageCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 模块 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);     
        }
    }

}
