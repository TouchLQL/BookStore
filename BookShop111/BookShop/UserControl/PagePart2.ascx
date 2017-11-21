<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagePart2.ascx.cs" Inherits="BookShop.PagePart2" %>
<input id="hidPageSize" name="hidPageSize" type="hidden" />
<div class="pages">
           <span>显示</span>
           <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" >
                 <asp:ListItem Text="15"></asp:ListItem>
                 <asp:ListItem Text="20" Selected="True"></asp:ListItem>
                 <asp:ListItem Text="50"></asp:ListItem>
                 <asp:ListItem Text="100"></asp:ListItem>
                 <asp:ListItem Text="200"></asp:ListItem>
           </asp:DropDownList>
           <span>条，共 <%=TotalCount %> 条&nbsp;&nbsp;&nbsp;&nbsp;第 <%=NowPage %> / <%=TotalPages %> 页</span>
</div>		
<div class="pagination">
            <ul>
	           <li class="j-first">
	         	  <a class="first" href="javascript:"  onclick="SubNowPage(this);"><span>首页</span></a>
		          <span class="first"><span>首页</span></span>
	           </li>
	           <li class="j-prev">
		           <a class="previous" href="javascript:"  onclick="SubNowPage(this);"><span>上一页</span></a>
		           <span class="previous"><span>上一页</span></span>
	            </li>
                <%=HtmlLinkPages()%>
	            <li class="j-next">
		            <a class="next" href="javascript:;" onclick="SubNowPage(this);"><span>下一页</span></a>
		            <span class="next" ><span>下一页</span></span>
	             </li>
	            <li class="j-last">
		            <a class="last" href="javascript:;" onclick="SubNowPage(this);"><span>末页</span></a>
		            <span class="last" ><span>末页</span></span>
	            </li>
	            <li class="jumpto"><input class="textInput" id="textInput" runat="server" type="text" size="4" value="1"/><asp:Button 
                        ID="btnGotoPage" CssClass="goto" runat="server" Text="确定" 
                        onclick="btnGotoPage_Click" /></li>
             </ul>
</div>
<script>
    function SubNowPage(a) {
        document.getElementById("hidPageSize").value = a.innerHTML.replace(/<[^>]+>/g,"");
        if (document.forms.length > 0)
            document.forms[0].submit();
    }
    function linkStyle(nowPage, totalPage){
        if (nowPage == 1) {
            $(".j-first").addClass("disabled");
            $(".j-prev").addClass("disabled");
            $("a.first").css("display", "none");
            $("a.previous").css("display", "none");
        }
        else{
            $("span.first").css("display", "none");
            $("span.previous").css("display", "none");
        }
        if (nowPage == totalPage) {
            $(".j-next").addClass("disabled");
            $(".j-last").addClass("disabled");
            $("a.next").css("display", "none");
            $("a.last").css("display", "none");
        }
        else{
            $("span.next").css("display", "none");
            $("span.last").css("display", "none");
        }
    }
    $(function () {
        var nowPage = <%=NowPage %>;
        var totalPage = <%=TotalPages %>
        linkStyle(nowPage, totalPage);
    })
</script>