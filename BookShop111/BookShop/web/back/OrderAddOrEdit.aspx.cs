using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using System.Data;

namespace BookShop.web.back
{
    
    public partial class OrderAddOrEdit : System.Web.UI.Page
    {
        private string type;
        private string userName;
        private string orderid;

        order ordermodel = new order();
        orderManage ordermanagement = new orderManage();
        userManage usermanagement = new userManage();
        bookManage bookmanagement = new bookManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
                this.userName = Session["userName"].ToString();
            else
                Response.Redirect("backLogin.aspx");

            if (Request.QueryString["type"] != null)
                this.type = Request.QueryString["type"].ToString().Trim();
            if (Request.QueryString["ID"] != null)
                this.orderid = Request.QueryString["ID"].ToString().Trim();

            if (!Page.IsPostBack)
            {
                if (this.type == "add")
                {
                    this.lblTitle.Text = "用户添加";
                    this.btnOk.Text = "添加";
                    this.txtorderid.ReadOnly = false;
                }
                else if (this.type == "edit")
                {
                    this.lblTitle.Text = "用户修改";
                    this.btnOk.Text = "更新";
                    this.txtorderid.ReadOnly = true;
                    ShowOrderInfo();
                }

            }

        }

        /// <summary>
        /// 修改读取展示数据
        /// </summary>
        private void ShowOrderInfo()
        {

            DataTable dt = ordermanagement.ShowOrderInfo(orderid);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txtorderid.Text = dt.Rows[0]["ID"].ToString();
                //this.DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(dt.Rows[0]["bookName"].ToString());
                //this.DropDownList2.SelectedValue = dt.Rows[0]["userName"].ToString();
                //this.DropDownList1.SelectedValue = dt.Rows[0]["bookName"].ToString();
                this.txtordertime.Text = dt.Rows[0]["ordertime"].ToString();
                this.txtprice.Text = dt.Rows[0]["money"].ToString();
                this.txtnum.Text = dt.Rows[0]["ordernum"].ToString();
                this.txttype.Text = dt.Rows[0]["type"].ToString();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt2 = usermanagement.ShowUser(this.txuser.Text.Trim());
                //DataTable dt3 = bookmanagement.ShowBook(this.txtbookname.Text.Trim());

                //int userid = Convert.ToInt32( dt2.Rows[0]["userID"].ToString());

                //int bookid = Convert.ToInt32(dt3.Rows[0]["bookID"].ToString());

                ordermodel.ID = Convert.ToInt32( this.txtorderid.Text.Trim());
                ordermodel.ordertime = this.txtordertime.Text.Trim();
                ordermodel.money = this.txtprice.Text.Trim();
                ordermodel.ordernum = Convert.ToInt32( this.txtnum.Text.Trim());
                ordermodel.type = this.txttype.Text.Trim();
                ordermodel.userid = Convert.ToInt32(this.DropDownList2.SelectedValue.ToString());
                ordermodel.bookid = Convert.ToInt32(this.DropDownList1.SelectedValue.ToString());


                if (this.type == "add") //新增用户
                {
                    string result = ordermanagement.add(ordermodel);
                    if (result == "0")
                    {
                        this.LblError.Visible = true;
                        this.LblError.Text = "该用户名已存在！";
                    }

                }
                else if (this.type == "edit") //修改用户
                {
                    ordermanagement.update(ordermodel);
                }
                Response.Redirect("ordermanage.aspx");
            }
            catch (Exception ex)
            {
                this.LblError.Visible = true;
                this.LblError.Text = ex.Message;
            }

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ordermanage.aspx");
        }
    }
}