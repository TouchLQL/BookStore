using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.web.back
{
    public partial class UserAddOrEdit : System.Web.UI.Page
    {
        private string type;
        private string userName;
        private string userId;
        userManage usermanagment = new userManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
                this.userName = Session["userName"].ToString();
            else
                Response.Redirect("backLogin.aspx");

            if (Request.QueryString["type"] != null)
                this.type = Request.QueryString["type"].ToString().Trim();
            if (Request.QueryString["userID"] != null)
                this.userId = Request.QueryString["userID"].ToString().Trim();

            if (!Page.IsPostBack)
            {
                if (this.type == "add")
                {
                    this.lblTitle.Text = "用户添加";
                    this.btnOk.Text = "添加";
                    this.txtUserName.ReadOnly = false;
                }
                else if (this.type == "edit")
                {
                    this.lblTitle.Text = "用户修改";
                    this.btnOk.Text = "更新";
                    this.txtUserName.ReadOnly = true;
                    ShowUserInfo();
                }

            }
        }
        /// <summary>
        /// 修改读取展示数据
        /// </summary>
        private void ShowUserInfo()
        {

            DataTable dt = usermanagment.ShowUserInfo(userId);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txtUserName.Text = dt.Rows[0]["userName"].ToString();
                this.txtPassword.Text = dt.Rows[0]["password"].ToString();
                this.txtRealName.Text = dt.Rows[0]["realName"].ToString();
                this.Textage.Text = dt.Rows[0]["age"].ToString();
                this.txtEmail.Text = dt.Rows[0]["email"].ToString();
                this.txtTelephone.Text = dt.Rows[0]["telephone"].ToString();
                string sex = dt.Rows[0]["sex"].ToString();
                if (sex == "男")
                    this.rblSex.SelectedIndex = 0;
                else
                    this.rblSex.SelectedIndex = 0;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                user usermodel = new user();
                usermodel.userName = this.txtUserName.Text.Trim();
                usermodel.realName = this.txtRealName.Text.Trim();
                usermodel.age = this.Textage.Text.Trim();
                usermodel.password = this.txtPassword.Text.Trim();
                if (this.rblSex.SelectedValue == "男")
                    usermodel.sex = "男";
                else
                    usermodel.sex = "女";
                usermodel.email = this.txtEmail.Text.Trim();
                usermodel.telephone = this.txtTelephone.Text.Trim();

                if (this.type == "add") //新增用户
                {
                    string result = usermanagment.adduser(usermodel);
                    if (result == "0")
                    {
                        this.LblError.Visible = true;
                        this.LblError.Text = "该用户名已存在！";
                    }

                }
                else if (this.type == "edit") //修改用户
                {
                    usermanagment.updateuser(usermodel);
                }
                Response.Redirect("usermanage2.aspx");
            }
            catch (Exception ex)
            {
                this.LblError.Visible = true;
                this.LblError.Text = ex.Message;
            }

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("usermanage2.aspx");
        }
    }
}