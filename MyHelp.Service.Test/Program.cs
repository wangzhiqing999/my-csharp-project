using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyHelp.Model;
using MyHelp.Service;
using MyHelp.ServiceImpl;


namespace MyHelp.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            TestInputKeyword("存储");

            TestInputKeyword("游标");

            TestInputKeyword("函数");

            TestInputKeyword("异常");

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }




        private static IHelpService _HelpService = new DefaultHelpService();


        static void TestInputKeyword(string input)
        {
            List<HelpDocument> docList = _HelpService.GetHelpDocumentByInputKeyword(input);
            Console.WriteLine("# Search : {0}", input);
            Console.WriteLine("# Result Count : {0}", docList.Count);
            foreach (var doc in docList)
            {
                Console.WriteLine("### {0} : {1} ", doc.DocumentID, doc.DocumentTitle);
            }
            Console.WriteLine();
        }
    }
}
