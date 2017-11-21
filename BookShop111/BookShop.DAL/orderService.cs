using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Model;
using System.Data;

namespace BookShop.DAL
{
    public class orderService
    {
        SqlDBConnect db = new SqlDBConnect();
        /// <summary>
        /// 初始化订单管理
        /// </summary>
        /// <returns></returns>
        public string getallorder()
        {
            string sql = "SELECT ID,ordertime,ordernum,[order].bookid,[order].userid,[order].type,money,bookName,userName " +
                         "FROM [order],[user],[book] WHERE [order].bookid = book.bookID AND [order].userid = [user].userID ";
            return sql;
        }

        public DataTable ShowOrderInfo(string orderId)
        {
            string sql = "SELECT ID,ordertime,ordernum,[order].bookid,[order].userid,[order].type,money,bookName,userName " +
                         "FROM [order],[user],[book] WHERE [order].bookid = book.bookID AND [order].userid = [user].userID and ID= '" + orderId + "'";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="bookmodel">图书实体</param>
        /// <returns>"1"表示新增成功 "0"表示新增失败</returns>
        public string add(order ordermodel)
        {
            string sql_1 = "select * from [order] where bookID = '" + ordermodel.ID + "'";
            bool isExist = db.YNExistData(sql_1);
            if (isExist == false)
            {
                string sql1 = "select max(ID) as orderid from [order]";
                DataTable dt = db.GetDataTable(sql1);
                int orderid = int.Parse(dt.Rows[0][0].ToString());
                orderid = orderid + 1;

                string sql = "insert into [order](ID,ordertime, ordernum, bookid, userid, type, money) " +
                      "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                sql = string.Format(sql, orderid, ordermodel.ordertime,
                    ordermodel.ordernum, ordermodel.bookid, ordermodel.userid,
                    ordermodel.type, ordermodel.money);
                db.ExecuteNonQuery(sql);
                return "1";
            }
            else
                return "0";
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="bookmodel">订单实体</param>
        /// <returns>"1"表示修改成功 "0"表示修改失败</returns>
        public string update(order ordermodel)
        {
            string sql_1 = "select * from [order] where ID = '" + ordermodel.ID + "'";
            bool isExist = db.YNExistData(sql_1);

            if (isExist)
            {
                string sql = "update [order] set ordertime = '{0}', ordernum = '{1}', bookid = '{2}', userid = '{3}', money='{4}', type='{5}'" +
                         " where ID= '{6}'";
                sql = string.Format(sql, ordermodel.ordertime, ordermodel.ordernum, ordermodel.bookid, ordermodel.userid, ordermodel.money,
                    ordermodel.type, ordermodel.ID);
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
        public bool delet(int orderid)
        {
            try
            {
                string sql = "delete from [order] where ID = '{0}'";
                sql = string.Format(sql, orderid);
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
        /// <param name="orderid">订单编号</param>
        /// <param name="ordernum">订单数目</param>
        /// <returns></returns>
        public string search(string orderid, string ordernum)
        {
            string sql = "SELECT ID,ordertime,ordernum,[order].bookid,[order].userid,[order].type,money,bookName,userName " +
                         "FROM [order],[user],[book] WHERE [order].bookid = book.bookID AND [order].userid = [user].userID";
            if (ordernum != null || ordernum != "" || orderid != null || orderid != "")
            {
                sql += " and ordernum like '%" + ordernum + "%' and ID like '%" + orderid + "%'";
            }
            return sql;
        }
    }
}
