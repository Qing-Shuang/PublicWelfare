<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_Article_Detail>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:wb="http://open.weibo.com/wb">
<head>
    <title>红会-<%=Model.curArticle.Title%></title>
<%--        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Art_Dta.css") %>" />
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/1145588419.css") %>" />
</head>
<body>
<script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js?appkey=" type="text/javascript" charset="utf-8"></script>
<%Html.RenderPartial("Navbar", "Article"); %>
    <div class="container">
    <div class="row">

    <div class="span9">
    <div class="page-header">
    <h2><%=Model.curArticle.Title%></h2>
    <div id="source"><a href="<%=Url.Content("~/Article/Detail/" + Model.curArticle.ID) %>" title="阅读全文">
    <%=Model.curArticle.Author + "," + Model.curArticle.PublishTime%></a></div>
    </div>
    <div id="articleBody">
    <div>
    <wb:share-button count="n" type="button" size="middle" ></wb:share-button>
    </div>
    <p style="font-size:15px"><%=Model.curArticle.Body%></p></div>    

     <div>
     <ul class="pager">
     <%if (Model.isNext)
            { %>
        <li>
        <a href="<%=Url.Content("~/Article/Detail/" + (Model.curArticle.ID+1)) %>">前一篇</a>
        </li>
     <%} if (Model.isPre)
       { %>
        <li>
        <a href="<%=Url.Content("~/Article/Detail/" + (Model.curArticle.ID-1)) %>">后一篇</a>
        </li>
     <%} %>
    </ul>
    </div>
    </div>

    <div  class="span3">
    <div class="page-header">
    <h3>其他文章:</h3>
    </div>
    <%--<ol style="list-style:none">--%>
    <ul>
    <%for (int i = 0; i < Model.list_Article.Count; ++i)
      { %>
    	<li><%=Html.ActionLink(Model.list_Article[i].Title, "Detail", new { id = Model.list_Article[i].ID })%></li>
    <%} %>
    </ul>
    </div>
    </div>
    </div>
        <%Html.RenderPartial("Bottom"); %>
</body>
</html>
