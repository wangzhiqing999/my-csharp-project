using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using CommandLine;
using CommandLine.Text;

using log4net;

using MyMiniTradingSystem.DataAccess;



namespace MyMiniTradingSystem.Cmd
{
    class Program
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        static void Main(string[] args)
        {
            logger.Debug("MyMiniTradingSystem Start!");

            // 当 Code First 与数据库结构不一致时
            // 自动升级到最新的版本.
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyMiniTradingSystemContext, MyMiniTradingSystem.Migrations.Configuration>());

            // 忽略数据库的不一致.
            Database.SetInitializer(new NullDatabaseInitializer<MyMiniTradingSystemContext>());
            

            string invokedVerb = null;
            object invokedVerbInstance = null;

            var options = new Options();

            if (!CommandLine.Parser.Default.ParseArguments(args, options,
              (verb, subOptions) =>
              {
                  // if parsing succeeds the verb name and correct instance
                  // will be passed to onVerbCommand delegate (string,object)
                  invokedVerb = verb;
                  invokedVerbInstance = subOptions;
              }))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            var commonSubOptions = (CommonSubOptions)invokedVerbInstance;

            commonSubOptions.DoProcess();
        }



    }



}
