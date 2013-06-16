<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Visit>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>红会-参加成员</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%Html.RenderPartial("Navbar"); %>
    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Notice"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <form id="" action="<%if(Model.isDelete){ %><%=Url.Content("~/Visit/Delete?curPage=" + Model.paginate.CurrentPage) %>
    <%} %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">已参加成员</h1>
    </div>
    <%if (!string.IsNullOrEmpty(Model.msg))
      { %>
    <div class="alert alert-success">
    <%=Model.msg%>
    </div>
    <%} %>
        <table class="table table-hover table-striped" id="VisitSelect">
        <tr>
<%--             <%if (Model.isDelete)
              {%><th class="span1"><input type="checkbox" name="" onclick="checkAllorInverse(this,'VisitSelect')"/>删除</th><%} %>--%>
            <th>活动名称</th>
            <th>学号</th>
            <th>姓名</th>
            <th>长号或短号</th>
        </tr>

        <% foreach (var item in Model.list_Visit)
           { %>
        <tr>
<%--           <%if (Model.isDelete)
           {%>
        <td><input type="checkbox" name="<%=item.Id%>"/></td>
        <%} %>--%>
        <td><%=item.ActivityName %></td>
        <td><%=item.UserID %></td>
        <td><%=item.UserName %></td>
        <td><%=item.Phone %></td>
        </tr>
    <% } %>
    </table>
<%--    <%if (Model.isDelete) %>
    <%{ %>
    <div>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的事项</button>
    </div>
    <%} %>--%>
    </form>
    <div id="pager"><%=Html.PagerMutiParam(Model.paginate.CurrentPage, Model.paginate.TotalPages, Url.Content("~/Visit/Details?curPage="))%></div>
    </div>
    </div>
    </div>

    <%Html.RenderPartial("Bottom"); %>
</body>
</html>
