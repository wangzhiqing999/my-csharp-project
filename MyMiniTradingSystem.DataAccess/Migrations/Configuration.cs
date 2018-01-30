namespace MyMiniTradingSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    using MyMiniTradingSystem.Model;



    public sealed class Configuration : DbMigrationsConfiguration<MyMiniTradingSystem.DataAccess.MyMiniTradingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // AutomaticMigrationDataLossAllowed = true;
        }




        protected override void Seed(MyMiniTradingSystem.DataAccess.MyMiniTradingSystemContext context)
        {

            // 帐户.
            context.UserAccounts.AddOrUpdate(
                p => p.UserCode,
                new UserAccount() { UserCode = "000000", UserName = "Me", Status = "ACTIVE", CreateUser = "system", CreateTime = DateTime.Now, LastUpdateUser = "system", LastUpdateTime = DateTime.Now }
                );


            // 商品.
            context.TradableCommoditys.AddOrUpdate(
                p => p.CommodityCode,
                new TradableCommodity {  CommodityCode= "510060", CommodityName="央企ETF",  NumOfOneHand = 100, DepositRatio=100,  Status = "ACTIVE", CreateUser = "system", CreateTime = DateTime.Now, LastUpdateUser = "system", LastUpdateTime = DateTime.Now },
                new TradableCommodity {  CommodityCode= "512070", CommodityName="非银ETF",  NumOfOneHand = 100, DepositRatio=100,  Status = "ACTIVE", CreateUser = "system", CreateTime = DateTime.Now, LastUpdateUser = "system", LastUpdateTime = DateTime.Now },
                new TradableCommodity {  CommodityCode= "510230", CommodityName="金融ETF",  NumOfOneHand = 100, DepositRatio=100,  Status = "ACTIVE", CreateUser = "system", CreateTime = DateTime.Now, LastUpdateUser = "system", LastUpdateTime = DateTime.Now },
                new TradableCommodity {  CommodityCode= "600642", CommodityName="申能股份",  NumOfOneHand = 100, DepositRatio=100, Status = "ACTIVE", CreateUser = "system", CreateTime = DateTime.Now, LastUpdateUser = "system", LastUpdateTime = DateTime.Now }
                );


            
        }
    }
}
