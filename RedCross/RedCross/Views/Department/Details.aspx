<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Department>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" html xmlns:wb=“http://open.weibo.com/wb”>
<head runat="server">
    <title>红会-部门介绍</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
    <script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
<%Html.RenderPartial("Navbar", "Department"); %>
    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <div class="page-header">
    <h1 class="page-header-title">红会介绍
        <% foreach (var item in Model.List_Dep)
           {
               if (item.Name == "红会")
               {%>
               <small><p><%=item.Introduce%></p></small>
           <%
                   break;
               }
           } %>
    </h1>
    </div>
    <%if (!string.IsNullOrEmpty(Model.message))
      { %>
    <div class="alert alert-success">
    <%=Model.message%> 
    </div>
    <%} %>

    <p>
    <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary" onclick="location.href='<%=Url.Content("~/Department/Add") %>'">创建新的部门</button>
    <%} %>
    </p>

    <% foreach (var item in Model.List_Dep)
       {
           if (item.Name != "红会" && item.Name != "其他")
           {%>
    <div class="row">
    <div class="span7">
    <div class="alert alert-block alert-info">
    <h2><%=item.Name%></h2>
    <p><i class="icon-plus icon-white"></i>&nbsp;<%=item.Introduce%>
    <p>
    <%if (Model.isUpdate)
      { %><%= Html.ActionLink("编辑", "Update", new { id = item.ID, message = item.Name })%><%} %>
          <%if (Model.isDelete)
            { %> | <%= Html.ActionLink("删除", "Delete", new { id = item.ID, message = item.Name })%><%} %>
      </p>
    </div>
    </div>
    <div class="span4">
    <wb:follow-button uid="<%=item.WeiboId %>" type="red_4" width="100%" height="64" ></wb:follow-button>
    </div>
    </div>
    <% }
       } %>
    </div>
    </div>

    <%Html.RenderPartial("Bottom"); %>
    </div>
</body>
</html>

