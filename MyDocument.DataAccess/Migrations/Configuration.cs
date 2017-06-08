namespace MyDocument.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    public sealed class Configuration : DbMigrationsConfiguration<MyDocument.DataAccess.MyDocumentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDocument.DataAccess.MyDocumentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.DocumentTypes.AddOrUpdate(
                p => p.DocumentTypeCode,
                new MyDocument.Model.DocumentType {DocumentTypeCode = "TEST", DocumentTypeName = "≤‚ ‘¿‡–Õ", IsActive = true, CreateUser = "system", LastUpdateUser="system", CreateTime = DateTime.Now, LastUpdateTime = DateTime.Now }
                );
        }
    }
}
