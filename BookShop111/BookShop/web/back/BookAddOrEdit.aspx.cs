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
    public partial class BookAddOrEdit : System.Web.UI.Page
    {
        private string type;
        private string userName;
        private string bookId;
        bookManage bookmansgement = new bookManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
                this.userName = Session["userName"].ToString();
            else
                Response.Redirect("backLogin.aspx");

            if (Request.QueryString["type"] != null)
                this.type = Request.QueryString["type"].ToString().Trim();
            if (Request.QueryString["bookID"] != null)
                this.bookId = Request.QueryString["bookID"].ToString().Trim();

            if (!Page.IsPostBack)
            {
                if (this.type == "add")
                {
                    this.lblTitle.Text = "图书添加";
                    this.btnOk.Text = "添加";
                    this.txtbookID.ReadOnly = false;
                }
                else if (this.type == "edit")
                {
                    this.lblTitle.Text = "图书修改";
                    this.btnOk.Text = "更新";
                    this.txtbookID.ReadOnly = true;
                    ShowBookInfo();
                }

            }
        }

        private void ShowBookInfo()
        {

            DataTable dt = bookmansgement.showDetails(bookId);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txtbookName.Text = dt.Rows[0]["bookName"].ToString();
                this.txtbookID.Text = dt.Rows[0]["bookID"].ToString();
                this.txtPress.Text = dt.Rows[0]["press"].ToString();
                this.txtprice.Text = dt.Rows[0]["price"].ToString();
                this.txtType.Text = dt.Rows[0]["type"].ToString();
                this.txtwriter.Text = dt.Rows[0]["writer"].ToString();
                this.txtstock.Text = dt.Rows[0]["stock"].ToString();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                book books = new book();
                books.press = this.txtPress.Text.Trim();
                books.stock = this.txtPress.Text.Trim();
                books.type = this.txtType.Text.Trim();
                books.writer = this.txtwriter.Text.Trim();
                books.bookName = this.txtbookName.Text.Trim();
                books.price = this.txtprice.Text.Trim();
                books.bookID =Convert.ToInt32( this.txtbookID.Text.Trim());
                if (this.type == "add") //新增
                {
                    string result = bookmansgement.add(books);
                    if (result == "0")
                    {
                        this.LblError.Visible = true;
                        this.LblError.Text = "该用图书已存在！";
                    }

                }
                else if (this.type == "edit") //修改
                {
                    bookmansgement.update(books);
                }
                Response.Redirect("booksmanage.aspx");
            }
            catch (Exception ex)
            {
                this.LblError.Visible = true;
                this.LblError.Text = ex.Message;
            }

        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("booksmanage.aspx");
        }
    }
}