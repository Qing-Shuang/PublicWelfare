<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container_List_Article>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>红会-文章</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Article"); %>
    <div class="container">
    <div class="row">
    <div class="page-header">
    <h1  class="page-header-title">红会文章</h1>
    </div>
    <div>
        <%for (int i = 0; i < Model.list_Article.Count; ++i)
        { %>
            <div class="news_body1">
            <%--<blockquote cite="">--%>
            <p><h3 class="title"><a href="<%=Url.Content("~/Article/Detail/"+Model.list_Article[i].ID) %>">
             <%=Model.list_Article[i].Title%></a></h3></p>
            <p><%=!string.IsNullOrEmpty(Model.list_Article[i].Summary) ?
                                       Model.list_Article[i].Summary : "暂时没有任何内容"%>
             <a href="<%=Url.Content("~/Article/Detail/"+Model.list_Article[i].ID) %>" title="阅读全文">继续阅读</a></p>

             <p><div id="source"><a href="<%=Url.Content("~/Article/Detail/"+Model.list_Article[i].ID) %>" title="阅读全文">
             <%=Model.list_Article[i].Author + "," + Model.list_Article[i].PublishTime%></a></div></p>
             <%--</blockquote>--%>
             </div>
        <%} %>
     </div>
     </div>
     </div>
     

<div id="pager">
<%=Html.Pager(Model.paginate.CurrentPage, Model.paginate.TotalPages,Url.Content("~/Article/Index"))%>
</div>
<%Html.RenderPartial("Bottom"); %>
</body>
</html>

