using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;
using BookShop.Model;
using System.Data;

namespace BookShop.BLL
{
    public class orderManage
    {
        orderService orderservices = new orderService();
        public string getall()
        {
            return orderservices.getallorder();
        }

         public string search(string orderid, string ordernum)
        {
             return orderservices.search(orderid,ordernum);
         }

         public DataTable ShowOrderInfo(string orderId)
         {
             return orderservices.ShowOrderInfo(orderId);
         }

         public string add(order ordermodel)
         {
             return orderservices.add(ordermodel);
         }

         public string update(order ordermodel)
         {
             return orderservices.update(ordermodel);
         }
         public bool delete(int orderid)
         {
             return orderservices.delet(orderid);
         }
    }
}
