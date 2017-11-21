using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using BookShop.BLL;

namespace BookShop.web.front
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
                this.Label1.Text = Session["userName"].ToString().Trim();

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>1成功 0失败</returns>
        [WebMethod]
        public static string Login(string userName, string password)
        {
            userManage usermanage = new userManage();
            return usermanage.login(userName, password);
        }
        /// <summary>
        /// 展示全部图书
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string View()
        {
            bookManage bookmanage = new bookManage();
            DataTable result = bookmanage.showbooks();
            return GetJSONString(result);
        }
        /// <summary>
        /// 根据图书类型获取图书
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod]
        public static string getBytype(string type)
        {
            bookManage bookmanage = new bookManage();
            DataTable result = bookmanage.getBytype(type);
            if (result == null)
            {
                return "0";

            }else{

                return GetJSONString(result);
            }

        }

        /// <summary>
        /// 将datable转换成string
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