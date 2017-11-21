using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Default : System.Web.UI.Page
    {
        //当前登录用户名
        public string LoginName
        {
            get
            {
                try
                {
                    string RealName = "";
                    if (Session["userName"] != null)
                    {
                        RealName = new SqlDBConnect().GetSingleVal("select RealName from [user] where userName = '" + Session["userName"] + "'");
                    }
                    return RealName;
                }
                catch
                {
                    return "";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["LoginId"] = "admin";

            //if (!RemoteMonitor.Infrastructure.TestUser.Action(this)) return;
        }

        /// <summary>
        /// 获取左侧便拦组
        /// </summary>
        public string GetLeftMenu()
        {
            LeftMenu leftMenu = new LeftMenu();
            string userName = (string)Session["userName"];
            if (userName == null)
                Response.Redirect("web/back/backLogin.aspx");
            leftMenu.LoginId = userName;
            return leftMenu.GetLeftMenu();
        }
    }
}