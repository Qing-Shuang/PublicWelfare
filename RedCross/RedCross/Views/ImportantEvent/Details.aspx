<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_ImportantEvent>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-大事记</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%Html.RenderPartial("Navbar", "ImportantEvent"); %>

    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <form id="" action="<%if(Model.isDelete){ %><%=Url.Content("~/ImportantEvent/Delete?curPage=" + Model.paginate.CurrentPage) %><%} %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">大事记<small><p>记录了红会的点点滴滴，等着你来继续谱写下去</p></small></h1>
    </div>
    <%if (!string.IsNullOrEmpty(Model.msg))
      { %>
    <div class="alert alert-success">
    <%=Model.msg%>
    </div>
    <%} %>
        <table  class="table table-hover table-striped" id="ImportantEventSelect">
        <tr>
            <%if (Model.isDelete)
              {%><th><input type="checkbox" name="" onclick="checkAllorInverse(this,'ImportantEventSelect')"/></th><%} %>
            <th>内容</th>
            <th>时间</th>
            <%if (Model.isUpdate)
              {%><th></th><%} %>
        </tr>

    <% foreach (var item in Model.List_ImportantEvent) { %>
        <tr>
           <%if (Model.isDelete)
           {%>
        <td><input type="checkbox" name="<%=item.Id%>"/></td>
        <%} %>
        <td><%=item.Content %></td>
        <td><%=item.PublisTime.ToString("yyyy-MM-dd") %></td>
        <%if (Model.isUpdate)
          {%>
            <td><%= Html.ActionLink("更新", "Update", new { id = item.Id, curPage = Model.paginate.CurrentPage })%></td> 
       <%} %>    
        </tr>
    <% } %>
    </table>
    <%if (Model.isDelete) %>
    <%{ %>
    <div>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的事项</button>
      <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/ImportantEvent/Add?curPage=" + Model.paginate.CurrentPage) %>'">添加新的事项</button>
      <%} %>
    </div>
    <%} %>
    </form>
    <div id="pager"><%=Html.PagerMutiParam(Model.paginate.CurrentPage, Model.paginate.TotalPages, Url.Content("~/ImportantEvent/Details?curPage="))%></div>
    </div>
    </div>
    </div>

    <%Html.RenderPartial("Bottom"); %>
</body>
</html>

