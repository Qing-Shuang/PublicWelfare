<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_list_UserWaitForPass>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-审核新成员</title>
<%--        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Table.css") %>" />
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>

 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PermissionNewUser"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1 class="page-header-title">审核新成员</h1>
    </div>
    <div>
    <%--<div id="main_content_table_PermisNewUser">--%>
<%--    <div class="subTitileWithOutLine">审核新用户</div>--%>
    <form action="<%=Url.Content("~/User/PermissionNewUser") %>" method="post">
<%--         <table class="permisNewUser">--%>
         <table class="table table-hover table-striped">
          <tr class="header">
            <th class="w120"><input type="checkbox" onclick="checkAllorInverse(this,'main_content_table_PermisNewUser')"/>是否通过</th>
      		<th class="w100">学号</th>
            <th class="w60">姓名</th>
            <th class="w60">性别</th>
            <th class="w60">年级</th>
            <th class="w120">学院</th>
            <th class="w130">部门</th>
            <th class="w60">职位</th>
            <th class="w100">长号</th>
            <th class="w60">短号</th>
      	  </tr>
    <%if (Model != null && Model.list_UserStatus != null)
      {
          for (int i = 0; i < Model.list_UserStatus.Count; ++i)
          { %>
      	<tr>
            <td><input type="checkbox" name="<%=Model.list_UserStatus[i].UserID%>"/></td>
      		<td><%=Model.list_UserStatus[i].UserID%></td>
            <td><%=Model.list_UserStatus[i].UserName%></td>
            <td><%=Model.list_UserStatus[i].Sex == 0? "女":"男"%></td>
            <td><%=Model.list_UserStatus[i].Grd.Name%></td>
            <td><%=Model.list_UserStatus[i].Clg.Name%></td>
            <td><%=Model.list_UserStatus[i].Dep.Name%></td>
            <td><%=Model.list_UserStatus[i].Ro.Name%></td>
            <td><%=Model.list_UserStatus[i].Phone%></td>
            <td><%=Model.list_UserStatus[i].Phone_short%></td>
      	</tr>
      <%}
      }%>
     </table>
            <button type="submit" class="btn btn-primary span2">提交</button>
    </form>
    </div>
</div>
    <div id="pager">
         <%=Html.Pager(Model.paginate.CurrentPage, Model.paginate.TotalPages, Url.Content("~/User/PermissionNewUser")) %>
   </div>
   </div>
   </div>

<%Html.RenderPartial("Bottom"); %>
</body>
</html>
