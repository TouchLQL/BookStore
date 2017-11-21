using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;
using System.Data;
using System.Web;
using BookShop.Model;
using BookShop.DAL;

namespace BookShop.BLL
{
    public class bookManage
    {
        bookService bookmanage = new bookService();

        /// <summary>
        /// 展示图书详情
        /// </summary>
        /// <param name="ISBN">图书id</param>
        /// <returns></returns>
        public DataTable showDetails(string bookID)
        {
            DataTable result = bookmanage.showDetails(bookID);

            return result;
        }

        public DataTable showbooks()
        {
            return bookmanage.View();
        }

        public DataTable getBytype(string type)
        {
            DataTable result = bookmanage.getBytype(type);
            return result;
        }

        public string getallbook()
        {
            return bookmanage.getallbooks();
        }

        public string search(string bookid, string bookname)
        {
            return bookmanage.search(bookid, bookname);
        }

        public bool delete(int bookid)
        {
            return bookmanage.delet(bookid);
        }

        public string update(book bookmodel)
        {
            return bookmanage.update(bookmodel);
        }

        public string add(book bookmodel)
        {
            return bookmanage.add(bookmodel);
        }

        public DataTable ShowBook(string bookName)
        {
            return bookmanage.ShowBook(bookName);
        }
    }
}
