<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_Notices_MyWorks_TeamWorks_Activities>" %>
<%@import Namespace="RedCross.Models.Entities.Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-个人主页</title>
<%--        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1 class="page-header-title">个人中心</h1>
    </div>
    <div id="hello" class="well"></div>
    <div class="row-fluid">
    <div class="span6">
        <%--<div class="module">--%>
        <div class="page-header">
        <h2>近期公告</h2>
        </div>
<%--        <div class="module_title">
        <label>公告</label>
        </div>--%>
        <%if (Model != null && Model.list_Notice != null)
          {
              %><ul><%
              for (int i = 0; i < Model.list_Notice.Count; ++i)
              {%>
             <li><p><%if (Model.list_Notice[i].isTop == 1) { %><span class="label label-important">置顶</span><%} %>&nbsp;&nbsp;<%=Model.list_Notice[i].Content + ", " + Model.list_Notice[i].PublishTime.ToString("yyyy-MM-dd")%></p></li>   
              <%}
              %></ul><%
          }
          else
          {%>
            <p class="alert alert-info">暂无公告</p>
          <%}%>
          <p><button type="button" class="btn" onclick="location.href='<%=Url.Content("~/Notice/Details") %>'">
    <i class=" icon-plus"></i>&nbsp;更多</button></p>
        <%--<div class="more"><%=Html.ActionLink(">>more","Details","Notice") %></div>--%>
    <%--</div>--%>
    </div>
    <div class="span6">
    <%--<div class="module">--%>
        <div class="page-header">
        <h2>近期活动</h2>
        </div>
<%--        <div class="module_title">
        <label>近期活动</label>
        </div>--%>

         <%if (Model != null && Model.list_Activity != null)
          {
               %><ul><%
              for (int i = 0; i < Model.list_Activity.Count; ++i)
              {%>
              <li><p><%=Model.list_Activity[i].Content%></p></li>   
              <%}
               %></ul><%
          }
          else
          {%>
             <p class="alert alert-info">暂无活动</p>
          <%}%>
        <%--<div class="more"><%=Html.ActionLink(">>more","Details","Activity") %></div>--%>
        <p><button type="button" class="btn" onclick="location.href='<%=Url.Content("~/Activity/Details") %>'">
    <i class=" icon-plus"></i>&nbsp;详细</button></p>
    <%--</div>--%>
    </div>
    </div>

    <div class="row-fluid">
    <div class="span6">
<%--    <div class="moduleParent">--%>
     <%--<div class="module">--%>
        <div class="page-header">
        <h2>部门近期任务</h2>
        </div>
       <%if (Model != null && Model.list_TeamWork != null)
          {%>
             <ul class="nav nav-pills nav-stacked">
              <%for (int i = 0; i < Model.list_TeamWork.Count; ++i)
              {%>
             <li> 
             <a href="/Work/Detail/<%=Model.list_TeamWork[i].ID %>">
             <%if(Model.list_TeamWork[i].Status == WorkStatus.PROCESS || Model.list_TeamWork[i].Status == WorkStatus.IMPROVE) {%><span class="label label-info">进行中</span><%}
             else if(Model.list_TeamWork[i].Status == WorkStatus.WAITPASS) {%><span class="label label-warning">等待审核</span><%}
             else if(Model.list_TeamWork[i].Status == WorkStatus.FINISH) {%><span class="label label-success">完成</span><%}
             else if(Model.list_TeamWork[i].Status == WorkStatus.NONE) {} %>
             &nbsp;<%=Model.list_TeamWork[i].Content%></a></li>   
              <%}%>
              </ul>
          <%}
          else
          {%>
             <%--<p class="module_content">暂无任务</p>--%>
             <p class="alert alert-info">暂无任务</p>
          <%}%>
          <p><button type="button" class="btn" onclick="location.href='<%=Url.Content("~/Activity/Details") %>'">
    <i class=" icon-plus"></i>&nbsp;详细</button></p>
    <%--</div>--%>
    <%--</div>--%>
    </div>
    <div class="span6">
<%--    <div class="moduleParent">--%>
     <%--<div class="module">--%>
        <div class="page-header">
        <h2>你的近期任务</h2>
        </div>

          <%if (Model != null && Model.list_MyWork != null)
          {%>
             <ul class="nav nav-pills nav-stacked">
              <%for (int i = 0; i < Model.list_MyWork.Count; ++i)
              {%>
             <li> 
             <a href="/Work/Detail/<%=Model.list_MyWork[i].ID %>">
             <%if(Model.list_MyWork[i].Status == WorkStatus.PROCESS || Model.list_MyWork[i].Status == WorkStatus.IMPROVE) {%><span class="label label-info">进行中</span><%}
             else if(Model.list_MyWork[i].Status == WorkStatus.WAITPASS) {%><span class="label label-warning">等待审核</span><%}
             else if(Model.list_MyWork[i].Status == WorkStatus.FINISH) {%><span class="label label-success">完成</span><%}
             else if(Model.list_MyWork[i].Status == WorkStatus.NONE) {} %>
             &nbsp;<%=Model.list_MyWork[i].Content%></a></li>   
              <%}%>
              </ul>  
          <%}
          else
          {%>
             <%--<p class="module_content">暂无任务</p>--%>
             <p class="alert alert-info">暂无任务</p>
          <%}%>
          <p><button type="button" class="btn " onclick="location.href='<%=Url.Content("~/Activity/Details") %>'">
    <i class="icon-plus"></i>&nbsp;详细</button></p>
    <%--</div>--%>
    <%--</div>--%>
    
    </div>
    </div>
    </div>
    </div>
    </div>
    
<%Html.RenderPartial("Bottom"); %>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/UserInfo.js") %>"></script>
</body>
</html>
