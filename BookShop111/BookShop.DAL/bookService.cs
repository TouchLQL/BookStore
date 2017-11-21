using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Model;

namespace BookShop.DAL
{
    public class bookService
    {
        SqlDBConnect db = new SqlDBConnect();

        /// <summary>
        /// 根据展示图书详情
        /// </summary>
        /// <param name="ISBN2"></param>
        /// <returns></returns>
        public DataTable showDetails(string bookid)
        {

            string sql = "select * FROM book where bookID='" + bookid + "'";

            DataTable result = db.GetDataTable(sql);

            return result;
        }

        /// <summary>
        /// 展示全部图书数据
        /// </summary>
        /// <returns></returns>
        public DataTable View()
        {
            SqlDBConnect db = new SqlDBConnect();
            string sql1 = "select * FROM book";

            return db.GetDataTable(sql1);
        }
        /// <summary>
        /// 根据图书类型读取图书
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable getBytype(string type)
        {

            string sql = "select * FROM book where type='" + type + "'";
            bool boolen = db.YNExistData(sql);
            if (boolen)
            {
                return db.GetDataTable(sql);
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 后台展示所有图书
        /// </summary>
        /// <returns></returns>
        public string getallbooks()
        {
            string sql = "select * FROM book";
            return sql;
        }


        /// <summary>
        /// 新增图书
        /// </summary>
        /// <param name="bookmodel">图书实体</param>
        /// <returns>"1"表示新增成功 "0"表示新增失败</returns>
        public string add(book bookmodel)
        {
            string sql_1 = "select * from [book] where bookID = '" + bookmodel.bookID + "'";
            bool isExist = db.YNExistData(sql_1);
            if (isExist == false)
            {
                string sql1 = "select max(bookID) as bookid from [book]";
                DataTable dt = db.GetDataTable(sql1);
                int bookid = int.Parse(dt.Rows[0][0].ToString());
                bookid = bookid + 1;

                string sql = "insert into [book](bookID,bookName, writer, price, " +
               " press, stock, type ,synopsis) " +
                      "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                sql = string.Format(sql, bookid,bookmodel.bookName,
                    bookmodel.writer, bookmodel.price, bookmodel.press, bookmodel.stock,
                    bookmodel.type, bookmodel.synopsis);
                db.ExecuteNonQuery(sql);
                return "1";
            }
            else
                return "0";
        }

        /// <summary>
        /// 修改图书信息
        /// </summary>
        /// <param name="bookmodel">图书实体</param>
        /// <returns>"1"表示修改成功 "0"表示修改失败</returns>
        public string update(book bookmodel)
        {
            string sql_1 = "select * from [book] where bookID = '" + bookmodel.bookID + "'";
            bool isExist = db.YNExistData(sql_1);

            if (isExist)
            {
                string sql = "update [book] set bookName = '{0}', writer = '{1}', price = '{2}', press = '{3}', stock='{4}', type='{5}'" +
                         " where bookID= '{6}'";
                sql = string.Format(sql, bookmodel.bookName, bookmodel.writer, bookmodel.price, bookmodel.press, bookmodel.stock,
                    bookmodel.type, bookmodel.bookID);
                db.ExecuteNonQuery(sql);
                return "1";
            }
            else
                return "0";
        }

        /// <summary>
        /// 根据图书编号删除图书
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>true or false</returns>
        public bool delet(int bookid)
        {
            try
            {
                string sql = "delete from [book] where bookID = '{0}'";
                sql = string.Format(sql, bookid);
                //执行插入
                db.ExecuteNonQuery(sql);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public string search(string bookid, string bookname)
        {
            string sql = "select * from [book] where 1=1";
            if (bookname != null || bookname != "" || bookid != null || bookid!="")
            {
                sql += " and bookName like '%" + bookname + "%' and bookID like '%" + bookid + "%'";
            }
            return sql;
        }

        /// <summary>
        /// 根据图书名称获取图书信息
        /// </summary>
        /// <param name="userName">用户名</param>
        public DataTable ShowBook(string bookName)
        {
            string sql = "select * from [book] where bookName= '" + bookName + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }
    }
}
