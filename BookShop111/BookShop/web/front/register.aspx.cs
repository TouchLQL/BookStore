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
    public partial class register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registe(string userName, string password, string sex, string birth,
            string mail, string realName, string address, string telephone)
        {
            userManage usermanage = new userManage();
            return usermanage.registe(userName, password, sex, birth, mail, realName, address, telephone);
        }
    }
}