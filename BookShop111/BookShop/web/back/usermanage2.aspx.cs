using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.web.back
{
    public partial class usermanage2 : System.Web.UI.Page
    {
        private string loginId; //登录用户ID

        userManage usermanagment = new userManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
                this.loginId = Session["userName"].ToString().Trim();
            if (!IsPostBack)
            {
                string sql = usermanagment.getalluser();
                PartPages2.Sql = sql;
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_search_Click(object sender, EventArgs e)
        {
            
            try
            {
                string userId = this.txtUserId.Text.ToString().Trim();
                string realName = this.txtRealName.Text.ToString().Trim();
                string sql = usermanagment.search(userId, realName);
                PartPages2.Sql = sql;
            }
            catch (Exception ty)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>confirm('" + ty.Message + "');</script>");
            }
        }

        /// <summary>
        /// 判断是否 新增、修改、删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkOper_Click(object sender, EventArgs e)//
        {
            try
            {
                object id = Request.Form["hidId"];
                string linkId = (sender as LinkButton).ID;
                if (linkId == "linkEdit" && !string.IsNullOrWhiteSpace((string)id))
                {
                    int userid1 = Convert.ToInt32(id);
                    Response.Redirect("UserAddOrEdit.aspx?type=edit&userID=" + userid1);
                }              
                if (linkId == "LinkAdd")
                    Response.Redirect("UserAddOrEdit.aspx?type=add");
                if (linkId == "linkDelete" && !string.IsNullOrWhiteSpace((string)id))
                {
                    int  userid = Convert.ToInt32(id);
                    if (usermanagment.deleteuser(userid))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>alert('删除成功');</script>");
                    }
                    
                }
            }
            catch (Exception eq)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>confirm('" + eq.Message + "');</script>");
            }
        }


    }
}