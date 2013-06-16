<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.List_TimeTable>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>测试</title>
            <link rel="stylesheet" type="text/css" href="/Content/Style_Table.css" />
</head>
<body>
<h1>测试用页面，可以查看修改过的课节数</h1>
    <div>
        <table  class="timeTable" border="1" cellspacing="2" cellpadding="1" width="75%">
    	<tr style="background-color:#EFF7FF">
    		<td width="12%" style="background-color:#FFFFFF"></td>
            <td width="12%">周一</td>
            <td width="12%">周二</td>
            <td width="12%">周三</td>
            <td width="12%">周四</td>
            <td width="12%">周五</td>
            <td width="12%">周六</td>
            <td width="12%">周日</td>
    	</tr>

        <%for (int i = 0; i < Model.list_u_TmTab.Count; ++i)
          { %>
           <tr>
          <td  style="background-color:#EFF7FF">第<%=Model.list_u_TmTab[i].Section%>节</td>
            <td <%if (Model.list_u_TmTab[i].FirstDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].SecondDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].ThirdDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].FourthDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].FifthDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].SixthDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
            <td <%if (Model.list_u_TmTab[i].SeventhDay == '1'){ %>style="background-color:#96C2F1"<%} %>></td>
        </tr>
        <%} %>
    </table>
    </div>
</body>
</html>
