<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Base.ActivityWorks>" %>
<%@ import Namespace="RedCross" %>
<%@ import Namespace="RedCross.Models.Entities.Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>红会-工作进度</title>
<%--    <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Work.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/副本 Style_Work.css") %>" />
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%Html.RenderPartial("Navbar", "Activity"); %>
<%--<%Html.RenderPartial("Select_HasInfo"); %>--%>
    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Activity"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <form id="" action="<%=Url.Content("~/Work/Delete") %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title"><%=Model.Content %></h1>
    </div>
    <%if (!string.IsNullOrEmpty(Model.WorkContent))
      { %>
    <div class="alert alert-success">
    <%=Model.WorkContent%>
    </div>
    <%} %>

    <div class="alert alert-block alert-info">
    <h4 class="alert-heading">温馨提示:</h4>
    鼠标滑过<strong>任务</strong>一项,可以看到这项工作的<strong>详细信息</strong>哦！
    </div>
    <div style="display:none"><input name="activityId" value="<%=Model.id %>"/></div>
        <table  class="table table-hover" id="WorkSelect">
        <tr>             
        <%if (Model.isDelete)
              {%><th><input type="checkbox" name="" onclick="checkAllorInverse(this,'WorkSelect')"/></th><%} %>
            <th>任务</th>
            <th class="span4">进行中</th>
            <th>等待审核</th>
            <%--<th>改进中</th>--%>
            <th>完成</th>
            <%if (Model.isUpdate)
              {%><th class="span1"></th><%} %>
       </tr>

<%for (int i = 0; i < Model.list_Works.Count; ++i)
  { %>
     <tr>
     <%if (Model.isDelete)
         {%><td><input type="checkbox" name="<%=Model.list_Works[i].ID%>"/></td><%} %>
    <td>
    <div class="work">
     <ul>
     <li><%=Model.list_Works[i].Content%>
     <ul class="nav nav-pills nav-stacked">
     <li class="nav-header">详细信息:</li>
     <li><a href="#">内容：<%=Model.list_Works[i].Content%></a></li>
     <li><a href="#">学号：<%=Model.list_Works[i].UserID %></a></li>
     <li><a href="#">姓名：<%=Model.list_Works[i].UserName %></a></li>
     <li><a href="#">开始日期：<%=Model.list_Works[i].StartDate.ToString("yyyy-MM-dd")%></a></li>
     <li><a href="#">截止日期：<%=Model.list_Works[i].CutOffDate.Date.ToString("yyyy-MM-dd")%></a></li>
     </ul>
     </li>
     </ul>
<%--    <a href="#"><%=Model.list_Works[i].Content%></a>
    <div class="subwork">
    <p>内容:<%=Model.list_Works[i].Content%></p>
    <p>截止日期:<%=Model.list_Works[i].CutOffDate.Date%></p>
    <p>负责人:<%=Model.list_Works[i].UserName%></p>
    </div>--%>
    </div>
    </td>
   
     <td><%if (Model.list_Works[i].Status == WorkStatus.PROCESS)
           {
               if (!Model.list_Works[i].isTimeOut)
               {
                   if (Model.list_Works[i].ProcessPersent < 80)
                   {
                         %>
                         <div>
                            要记得完成任务哦,&nbsp;
                            离截止时间还有<span class="badge badge-info"><%=Model.list_Works[i].ProcessRemain%></span>天
                         </div>
                         <%
                   } 
                   else
                   {
                       if (Model.list_Works[i].ProcessRemain == 0)
                       {
                         %>
                         <div>
                             <%--<div class="bar" style="<%='width: '+Model.list_Works[i].ProcessPersent+'%;' %>"></div>--%>
                             <span class="label label-warning">警告</span>&nbsp;今天是最后一天
                         </div>
                         <%
                       } 
                       else
                       {
                         %>
                         <div>
                             <%--<div class="bar" style="<%='width: '+Model.list_Works[i].ProcessPersent+'%;' %>"></div>--%>
                             <span class="label label-warning">警告</span>&nbsp;时间不多了呢,&nbsp; 离截止时间还有<span class="badge badge-warning"><%=Model.list_Works[i].ProcessRemain%></span>天
                         </div>
                         <%
                       }
                    }
               } 
               else
               {
                     %>
                     <div>
                         <span class="label label-important">危险</span>&nbsp;任务超时!
                     </div>
                     <%
               }
          } %>
     </td>
     <td><%if (Model.list_Works[i].Status == WorkStatus.WAITPASS)
           {%><span class="label label-info">等待审核</span><%}%>
     </td>

     <td><%if (Model.list_Works[i].Status == WorkStatus.FINISH)
           {%><span class="label label-success">完成</span><%}%></td>
     <%if (Model.isUpdate)
     {%><td><%=Html.ActionLink("编辑", "Update", new { id = Model.list_Works[i].ID, activityId = Model.id })%></td><%} %>
     
      </tr>
       <%} %>
    </table>
    <%if (Model.isDelete) %>
    <%{ %>
    <div>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的任务</button>
      <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Work/Add/" + Model.id) %>'">添加新的任务</button>
      <%} %>
    </div>
    <%} %>
    </form>

    </div>
    </div>
</div>

<%Html.RenderPartial("Bottom"); %>
</body>
</html>
