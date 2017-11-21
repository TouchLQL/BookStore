using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class PagePart2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*pageSize和nowPage都大于等于1*/
        private string controlId = null, sql = null;
        private DataTable dt = null;
        private int pageSize, nowPage, totalCount, totalPages;

        /// <summary>
        /// 获取或设置待绑定的repeater控件
        /// </summary>
        public string ControlId
        {
            get
            {
                return this.controlId;
            }
            set
            {
                this.controlId = value;
            }
        }
        /// <summary>
        /// 设置用于生成datatable的数据源（sql语句）
        /// </summary>
        public string Sql
        {
            get
            {
                return (string)ViewState["Sql"];
            }
            set
            {
                ViewState["Sql"] = value;
            }
        }
        /// <summary>
        /// 设置用于生成datatable的数据源（sql语句）
        /// </summary>
        public DataTable Dt
        {
            get
            {
                return (DataTable)ViewState["Dt"];
            }
            set
            {
                ViewState["Dt"] = value;
            }
        }
        /// <summary>
        /// 获取每页显示的条目数量
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
        }
        /// <summary>
        /// 获取或设置当前页索引页
        /// </summary>
        public int NowPage
        {
            get
            {
                return Convert.ToInt32(ViewState["NowPage"]);
            }
            set
            {
                ViewState["NowPage"] = value;
            }
        }
        /// <summary>
        /// 获取总的条目数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return this.totalCount;
            }
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                return this.totalPages;
            }
        }

        /**方法**/
        protected void Page_PreRender()
        {
            DataBind();
        }

        private new void DataBind()
        {
            this.pageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            this.sql = (string)ViewState["Sql"];
            this.dt = (DataTable)ViewState["Dt"];

            if (string.IsNullOrWhiteSpace(this.sql) && this.dt == null) return;

            SqlDBConnect db = new SqlDBConnect();
            DataTable dtSourse = null;
            if (this.sql != null)
                dtSourse = db.GetDataTable(this.sql);
            else if (this.dt != null)
                dtSourse = this.dt;

            Control control = Parent.FindControl(this.controlId);//待绑定控件 

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dtSourse.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = this.pageSize;
            this.totalCount = pds.DataSourceCount;//获取总项数
            this.totalPages = pds.PageCount;//获取总页数
            if (IsPostBack && Request.Form["hidPageSize"] != "")
            {
                if (Request.Form["hidPageSize"] == "首页")
                    this.nowPage = 1;
                else if (Request.Form["hidPageSize"] == "上一页")
                    this.nowPage = Convert.ToInt32(ViewState["NowPage"]) - 1;
                else if (Request.Form["hidPageSize"] == "下一页")
                    this.nowPage = Convert.ToInt32(ViewState["NowPage"]) + 1;
                else if (Request.Form["hidPageSize"] == "末页")
                    this.nowPage = this.totalCount;
                else if (Request.Form["hidPageSize"] != "")
                {
                    string i = Request.Form["hidPageSize"];
                    this.nowPage = Convert.ToInt32(Request.Form["hidPageSize"]);
                }
            }
            if (this.nowPage < 1)
            {
                if (ViewState["NowPage"] == null)
                    this.nowPage = 1;
                else
                    this.nowPage = Convert.ToInt32(ViewState["NowPage"]);
            }
            else if (this.nowPage > this.totalCount)
                this.nowPage = this.totalCount;
            this.nowPage = this.nowPage > this.totalPages ? this.totalPages : this.nowPage;//矫正当前索引页
            ViewState["NowPage"] = this.nowPage;
            pds.CurrentPageIndex = this.nowPage - 1;

            if (control.GetType() == typeof(Repeater))
            {
                (control as Repeater).DataSource = pds;
                control.DataBind();
            }
            else if (control.GetType() == typeof(GridView))
            {
                (control as GridView).DataSource = pds;
                control.DataBind();
            }
        }

        /// <summary>
        /// //添加翻页链接
        /// </summary>
        /// <returns></returns>
        public string HtmlLinkPages()
        {
            StringBuilder htmlLinkPages = new StringBuilder(null);
            string linkPageTemplate = "<li><a class=\"{0}\" href=\"javascript:\" onclick=\"SubNowPage(this);\">{1}</a></li>";
            int startLinkPage = 1, endLinkPage = 1;
            this.nowPage = Convert.ToInt32(ViewState["NowPage"]);
            if (this.nowPage <= 5)
            {
                startLinkPage = 1;
                endLinkPage = this.totalPages - startLinkPage <= 9 ? this.totalPages - startLinkPage + 1 : 10;
            }
            else
            {
                startLinkPage = this.nowPage - 4;
                endLinkPage = startLinkPage + 9 >= this.totalPages ? this.totalPages : startLinkPage + 9;
            }
            for (int i = startLinkPage; i <= endLinkPage; i++)
            {
                if (i == this.nowPage)
                    htmlLinkPages.AppendFormat(linkPageTemplate, "selected", i);
                else
                    htmlLinkPages.AppendFormat(linkPageTemplate, "", i);
            }
            return htmlLinkPages.ToString();
        }

        //跳转页面
        protected void btnGotoPage_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserPage = textInput.Value;
                this.nowPage = Convert.ToInt32(strUserPage);
            }
            catch
            {
            }
        }
    }
}