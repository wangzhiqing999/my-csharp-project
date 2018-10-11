using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyJob.Service.TestClient.Client;


namespace MyJob.Service.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            TestClient1.Start();
            TestClient2.Start();
            TestClient3.Start();



            Console.WriteLine("Press Ctrl+C To Exit.");
            Console.ReadLine();
        }
    }
}
