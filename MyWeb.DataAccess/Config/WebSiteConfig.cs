using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyWeb.Model;


namespace MyWeb.Config
{
    class WebSiteConfig : EntityTypeConfiguration<WebSite>
    {
        public WebSiteConfig()
        {
            // 一个 网站  允许 多个 模块.
            this.HasMany(s => s.WebSiteModules)
                // 一个 模块 必须属于 一个 网站 .
                .WithRequired(m => m.ModuleWebSite)
                // 外键的列是  WebSiteCode
                .HasForeignKey(m => m.WebSiteCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 网站 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);



            // 一个 网站  允许 多个 菜单.
            this.HasMany(s => s.WebSiteMenus)
                // 一个 菜单 必须属于 一个 网站 .
                .WithRequired(m => m.MenuWebSite)
                // 外键的列是  WebSiteCode
                .HasForeignKey(m => m.WebSiteCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 网站 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);    

        }
    }
}
