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
    public partial class LeftMenu : System.Web.UI.Page
    {
        public string LoginId { get; set; }//账户Id号

        protected void Page_Load(object sender, EventArgs e)
        {

        }             

        /// <summary>
        /// 用datatable数据集绑定菜单
        /// </summary>
        /// <returns></returns>
        public string GetLeftMenu()
        {
            StringBuilder leftMenu = new StringBuilder(null);

            #region 二级菜单            
            //string strLeftFatherMenu = "<div class=\"accordionHeader\"><h2><span>Folder</span>{0}</h2></div>";
            //string strLeftSonMenu = "<li>" +
            //                        "<a href=\"{0}\" target=\"navTab\" rel=\"p_{1}\" fresh=\"{2}\" external=\"{3}\">{4}</a>" +
            //                        "</li>";

            //string mainMenu = null;//第一级菜单
            //string childMenu = null;//子菜单
            //for (int i = 0; i < dtMenuSourse.Rows.Count; i++)
            //{
            //    mainMenu = dtMenuSourse.Rows[i]["MenuId"].ToString();
            //    if (mainMenu.Length != 2) continue;//不是主菜单
            //    leftMenu.AppendFormat(strLeftFatherMenu, dtMenuSourse.Rows[i]["MenuName"]);
            //    leftMenu.Append("<div class=\"accordionContent\" style=\"display:block;\">");
            //    leftMenu.Append("<ul class=\"tree treeFolder\">");
            //    for (int j = 0; j < dtMenuSourse.Rows.Count; j++)
            //    {
            //        childMenu = dtMenuSourse.Rows[j]["MenuId"].ToString();
            //        if (childMenu == mainMenu || childMenu.Substring(0, 2) != mainMenu) continue;
            //        leftMenu.AppendFormat(strLeftSonMenu,
            //            dtMenuSourse.Rows[j]["URL"], dtMenuSourse.Rows[j]["MenuId"], "1", "1", dtMenuSourse.Rows[j]["MenuName"]);
            //    }
            //    leftMenu.Append("</ul>");
            //    leftMenu.Append("</div>");
            //}       
            #endregion

            leftMenu.Append("<div class=\"accordionHeader\"><h2><span>Folder</span>系统管理</h2></div>");
            leftMenu.Append("<div class=\"accordionContent\" style=\"display:block;\">");
            leftMenu.Append("<ul class=\"tree treeFolder\">");
            leftMenu.Append("<li><a href=\"web/back/usermanage2.aspx\" target=\"navTab\" rel=\"用户管理\" fresh=\"1\" external=\"1\">用户管理</a></li>");      
            //leftMenu.Append("<li><a href=\"{0}\" target=\"navTab\" rel=\"角色权限\" fresh=\"1\" external=\"1\">角色权限</a></li>");
            leftMenu.Append("</ul>");
            leftMenu.Append("</div>");
            leftMenu.Append("<div class=\"accordionHeader\"><h2><span>Folder</span>商品管理</h2></div>");
            leftMenu.Append("<div class=\"accordionContent\" style=\"display:block;\">");
            leftMenu.Append("<ul class=\"tree treeFolder\">");
            leftMenu.Append("<li><a href=\"web/back/booksmanage.aspx\" target=\"navTab\" rel=\"商品信息\" fresh=\"1\" external=\"1\">图书管理</a></li>");
            leftMenu.Append("<li><a href=\"web/back/ordermanage.aspx\" target=\"navTab\" rel=\"我的订单\" fresh=\"1\" external=\"1\">订单管理</a></li>");
            leftMenu.Append("</ul>");
            leftMenu.Append("</div>");

            return leftMenu.ToString();
        }
       
    }
}