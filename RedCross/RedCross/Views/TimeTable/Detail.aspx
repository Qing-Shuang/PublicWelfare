<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_TimeTables_UserBases>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>红会-你的课表</title>
<%--        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Table.css") %>" />
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Detail"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1 class="page-header-title">个人课表</h1>
    </div>
    <table  class="timeTable">
        <tr>
    	<%--<tr class="header">--%>
    		<%--<td class="firstcell"></td>--%>
            <td></td>
            <td>周一</td>
            <td>周二</td>
            <td>周三</td>
            <td>周四</td>
            <td>周五</td>
            <td>周六</td>
            <td>周日</td>
    	</tr>

        <%for (int i = 0; i < Model.list_t.Count; ++i)
          { %>
           <tr>
          <td>第<%=Model.list_t[i].Section%>节</td>
            <td <%if (Model.list_t[i].FirstDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].SecondDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].ThirdDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].FourthDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].FifthDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].SixthDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
            <td <%if (Model.list_t[i].SeventhDay == '1'){ %>style="background-color:#b7ddf2"<%} %>></td>
        </tr>
        <%} %>
    </table>
    </div>
    </div>
    </div>
    
<%Html.RenderPartial("Bottom"); %>
</body>
</html>
