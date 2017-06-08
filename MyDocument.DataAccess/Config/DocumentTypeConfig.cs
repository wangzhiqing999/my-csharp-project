using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data.Entity.ModelConfiguration;

using MyDocument.Model;


namespace MyDocument.Config
{

    class DocumentTypeConfig : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeConfig()
        {
            // 一个 文档类型  允许 多个 文档.
            this.HasMany(s => s.DocumentList)
                // 一个 文档 必须属于 一个 文档类型 .
                .WithRequired(m => m.DocumentType)
                // 外键的列是  DocumentTypeCode
                .HasForeignKey(m => m.DocumentTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 文档类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);

        }
    }

}
