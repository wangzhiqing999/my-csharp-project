using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyDocument.Util;


namespace MyDocument.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Pdf2SwfConverter converter = new Pdf2SwfConverter();

            bool result = converter.Pdf2Swf("Pdf/django10-cheat-sheet.pdf", "Swf/django10-cheat-sheet.swf");


            Console.WriteLine("Finish! " + result);


            Console.ReadLine();
        }
    }
}
