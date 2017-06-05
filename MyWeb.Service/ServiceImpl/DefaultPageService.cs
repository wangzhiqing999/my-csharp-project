using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWeb.Model;
using MyWeb.DataAccess;
using MyWeb.Service;


namespace MyWeb.ServiceImpl
{
    public class DefaultPageService : IPageService
    {
        public List<Page> GetSubPageList(string code)
        {
            using (MyWebContext context = new MyWebContext())
            {
                var query =
                    from data in context.Pages
                    where
                        data.ParentPageCode == code
                    orderby
                        data.DisplayIndex
                    select
                        data;

                var resultList = query.ToList();

                return resultList;
            }
        }

    }

}
