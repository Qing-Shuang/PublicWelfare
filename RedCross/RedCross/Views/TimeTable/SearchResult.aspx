<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_FreeTime>" %>

<!DOCTYpE html pUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-检索结果</title>
    <%--<link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Table.css") %>" />
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Search"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1 class="page-header-title">检索结果</h1>
    </div>
    <p>
    <button type="button" class="btn btn-primary btn-large" onclick="location.href='<%=Url.Content("~/TimeTable/Search") %>'">返回检索</button>
    </p>
    <%--<%=Html.ActionLink("返回检索", "Search", "TimeTable")%>--%>

<div id="userInfo">
<%for (int i = 0; i < Model.list_free.Count; ++i)
  { %>
  <div id="<%=Model.list_free[i].ID + 10000%>" style="display:none">
  <table class="userSelected">
    <%--<tr style="background-color:#EFF7FF">--%>
    <tr>
    <td>学号</td>
    <td>姓名</td>
    <td>性别</td>
    <td>长号</td>
    <td>短号</td>
    </tr>
  <tr>
   <td><%=Model.list_free[i].UserID %></td>
   <td><%=Model.list_free[i].UserName %></td>
   <%if (Model.list_free[i].Sex == 1)
         { %><td>男</td><%}
         else
         {%><td>女</td><%} %>
   <td><%=Model.list_free[i].Phone %></td>
   <td><%=Model.list_free[i].Phone_short %></td>
   </tr>
   </table>
     </div>
<%} %>
</div>

    <div id="Result">
        <table class="timeTable">
<%--        <table class="table table-bordered">--%>
    	<%--<tr class="header">--%>
        <tr>
            <%--<td class="firstcell"></td>--%>
    		<td class="span1"></td>
            <td >周一</td>
            <td>周二</td>
            <td>周三</td>
            <td>周四</td>
            <td>周五</td>
            <td>周六</td>
            <td>周日</td>
    	</tr>
    
        <%for(int i = 1;i<=13;++i)
          {
              %><tr><%
                for (int j = 0; j <= 7; ++j) { 
                    if (j == 0)
                    { %><td>第<%=i%>节</td><%}               /*class="firstcolumn"*/
                    else { %>
                    <td id="<%= i +""+ j%>"></td>
                    <%}
                }%>
                </tr>
   <% }%>

    </table>
    </div>
</div>
    <div style="display:none">
        <%for (int i = 0; i < Model.list_free.Count; ++i)
      {%>
        <% string[] sections = Model.list_free[i].FreeTime.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
           for (int j = 0; j < sections.Length; ++j)
           {
                %><label id="<%=Model.list_free[i].ID +"*"+  sections[j]%>" ><%=Model.list_free[i].ID + "*" + sections[j]%> 
                | <%=Model.list_free[i].UserName%> | <%=Model.list_free[i].Phone%></label><br /><%
            } %>
             <% } %>
    </div>
    </div>
    </div>

<%Html.RenderPartial("Bottom"); %>
<%--            <script type="text/javascript" src="../../Scripts/Rc/CookieUtil.js"></script>
    <script type="text/javascript" src="../../Scripts/Rc/UserInfo.js"></script>
        <script type="text/javascript" src="../../Scripts/Rc/EventUtil.js"></script>--%>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/TableStruc.js") %>"></script>
</body>
</html>
