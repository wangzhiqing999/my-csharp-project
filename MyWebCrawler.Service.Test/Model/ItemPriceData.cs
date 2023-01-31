using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebCrawler.Service.Test.Model
{
    public class ItemPriceData
    {

        /// <summary>
        /// 日期.
        /// </summary>
        public string Date { set; get; }


        /// <summary>
        /// 价格.
        /// </summary>
        public string Price { set; get; }




        public override string ToString()
        {
            return $"{this.Date} {this.Price}";
        }


    }
}
