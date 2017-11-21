using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using BookShop.BLL;

namespace BookShop.web.front
{
    public partial class booksDetail : System.Web.UI.Page
    {
        bookManage bookmanage = new bookManage();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 展示图书详情
        /// </summary>
        /// <param name="ISBN2"></param>
        /// <returns></returns>
        [WebMethod]
        public static string showDetails(string bookID)
        {
            bookManage bookmanage = new bookManage();

            return GetJSONString(bookmanage.showDetails(bookID));
        }

        /// <summary>
        /// 将DataTable类型转换为string类型字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetJSONString(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rows.Add(row);
            }

            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            return ser.Serialize(rows);
        }
    }
}