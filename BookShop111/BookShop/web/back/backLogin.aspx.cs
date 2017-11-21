using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using System.Web.Services;

namespace BookShop.web.back
{
    public partial class backLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>1成功 0失败</returns>
        [WebMethod]
        public static string backlogin(string userName, string password)
        {
            userManage usermanage = new userManage();
         
            return usermanage.backlogin(userName, password);
        }
    }
   
}