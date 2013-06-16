<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Notice>" %>
<%@ Import Namespace="RedCross" %>
<%@ Import Namespace="RedCross.Models.Entities.Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-公告</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%Html.RenderPartial("Navbar", "Notice"); %>

    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Notice"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <form id="" action="<%if(Model.isDelete){ %><%=Url.Content("~/Notice/Delete?ntype=" + Model.NType +
    "&curPage=" + Model.paginate.CurrentPage) %>
    <%} %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">公告栏
    <small><p>我们会不定时地发布一些公告，包含红会的爱心活动、培训、招新等</p></small></h1>
    </div>
    <%if (!string.IsNullOrEmpty(Model.msg))
      { %>
    <div class="alert alert-success">
    <%=Model.msg%>
    </div>
    <%} %>
    <table class="table table-hover table-striped" id="NoticeSelect">
        <tr>
             <%if (Model.isDelete)
              {%><th class="span1"><input type="checkbox" name="" onclick="checkAllorInverse(this,'NoticeSelect')"/></th><%} %>
             <%if (!Model.isVisit)
             {%><th class="span1">范围</th><%} %>
            <th <%if (!Model.isVisit){%>style="width:75%"<%}else{ %>style="width:85%"<%} %>>内容</th>
            <th>发布时间</th>
             <%if (Model.isUpdate)
              {%><th></th><%} %>
        </tr>

    <% foreach (var item in Model.list_Notice) {
           if (item.isTop == 1)
           {%>
        <tr>
        <%if (Model.isDelete)
           {%>
        <td><input type="checkbox" name="<%=item.ID%>"/></td>
        <%} %>
        <%if (!Model.isVisit)
         {%><td><%if (item.NType == NoticeType.All_MEMBER)
              {%>所有人<%}
              else if (item.NType == NoticeType.ASSOCIATION)
              { %>仅会内<%} %></td><%} %>
        <td><span class="label label-important">置顶</span>&nbsp;&nbsp;<%=item.Content %></td>
        <td><%=item.PublishTime.ToString("yyyy-MM-dd") %></td>
        <%if (Model.isUpdate)
          {%>
            <td><%= Html.ActionLink("更新", "Update", new { id=item.ID,curPage = Model.paginate.CurrentPage }) %></td> 
       <%} %>  
        </tr>
    <% }} %>

     <% foreach (var item in Model.list_Notice) {
         if (item.isTop != 1)
           {%>
        <tr>
        <%if (Model.isDelete)
           {%>
        <td><input type="checkbox" name="<%=item.ID%>"/></td>
        <%} %>
        <%if (!Model.isVisit)
         {%><td><%if (item.NType == NoticeType.All_MEMBER)
              {%>所有人<%}
              else if (item.NType == NoticeType.ASSOCIATION)
              { %>仅会内<%} %></td><%} %>
        <td><%=item.Content %></td>
        <td><%=item.PublishTime.ToString("yyyy-MM-dd") %></td>
        <%if (Model.isUpdate)
          {%>
            <td><%= Html.ActionLink("更新", "Update", new { id=item.ID,curPage = Model.paginate.CurrentPage }) %></td> 
       <%} %>  
        </tr>
    <% }} %>

    </table>
    <%if (Model.isDelete) %>
    <%{ %>
    <div>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的公告</button>
      <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Notice/Add?curPage=" + Model.paginate.CurrentPage) %>'">
      <i class="icon-comment icon-white"></i>&nbsp;添加新的公告</button>
      <%} %>
    </div>
    <%} %>
</form>
<div id="pager"><%=Html.PagerMutiParam(Model.paginate.CurrentPage, Model.paginate.TotalPages, Url.Content("~" + string.Format("/Notice/Details?ntype={0}&curPage=", Model.NType)))%></div>
   </div>
    </div>
    </div>

    <%Html.RenderPartial("Bottom"); %>
</body>
</html>

