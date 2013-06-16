<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-添加你的课程表</title>
    <%--<link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Table.css") %>" />
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
</head>
<body>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/TimeTable.js") %>"></script>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Detail"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1>添加你的课程表</h1>
    </div>
<%--   <div id="main_content_table">--%>
    <form action="<%=Url.Content("~/TimeTable/Adding") %>" method="post">
        <table class="timeTable">
          <%--<tr class="header">--%>
          <tr>
    		<%--<td class="firstcell"></td>--%>
            <td></td>
            <td>周一 <input type="checkbox" name="cell0" onclick="checkColumn(this,0)" /></td>
            <td>周二 <input type="checkbox" name="cell1" onclick="checkColumn(this,1)" /></td>
            <td>周三 <input type="checkbox" name="cell2" onclick="checkColumn(this,2)" /></td>
            <td>周四 <input type="checkbox" name="cell3" onclick="checkColumn(this,3)" /></td>
            <td>周五 <input type="checkbox" name="cell4" onclick="checkColumn(this,4)" /></td>
            <td>周六 <input type="checkbox" name="cell5" onclick="checkColumn(this,5)" /></td>
            <td>周日 <input type="checkbox" name="cell6" onclick="checkColumn(this,6)" /></td>
    	</tr>
        <%for(int i = 0;i<13;++i)
          { %>
          <tr>
        <td>第<%=i+1 %>节                                                             
        <input type="checkbox" name="row<%=i %>" onclick="checkRow(this,<%=i %>)" /></td>
        <%for(int j = 0;j<7;++j)
          { %>
                  <td id="t<%=i %>d<%=j %>">
                  <input type="checkbox" name="row<%=i %>cell<%=j %>" onclick="checkCell(this,'t<%=i %>d<%=j %>')"/>
                  </td>
          <%} %>
         </tr>
        <%} %>
    </table><br />
     <div>
      <button type="submit" class="btn btn-primary">保存</button>
      <button type="button" class="btn" onclick="history.back()">取消</button>
    </div>
</form>
    </div>
    </div>
    </div>

<%Html.RenderPartial("Bottom"); %>
</body>
</html>
