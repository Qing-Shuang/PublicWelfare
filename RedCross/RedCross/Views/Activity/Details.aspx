<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Activity>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-活动列表</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Work_1.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%--     <p>
    <%=Html.Pager(Model.paginate.CurrentPage, Model.paginate.TotalPages,"/Activity/Details")%>
    </p>--%>
    <%Html.RenderPartial("Navbar", "Activity"); %>

    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Activity"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <form id="" action="<%=Url.Content("~/Activity/Delete") %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">爱心活动<small><p>我们会不定期发布一些公益活动，欢迎所有童鞋参与，点击看看，说不定会有你想参加的活动喔！</p></small></h1>
    </div>
    <div class="alert alert-block alert-info">
    <h4 class="alert-heading">温馨提示:</h4>
    鼠标滑过<strong>活动内容</strong>一项,可以看到这项活动的<strong>详细信息</strong>哦！
    </div>
    <div class="row"><button type="button" class="btn btn-success btn-large span2"  onclick="location.href='<%=Url.Content("~/Visit/Details") %>'">已参加成员</button></div><br />
    
    <%if (!string.IsNullOrEmpty(Model.msg))
      { %>
    <div class="alert alert-success">
    <%=Model.msg%>
    </div>
    <%} %>
    
    <table class="table table-hover table-striped" id="ActivitySelect">
        <tr>
             <%if (Model.isDelete)
              {%><th><input type="checkbox" name="" onclick="checkAllorInverse(this,'ActivitySelect')"/></th><%} %>
             <%if (!Model.isVisit)
              {%><th>是否有效</th><%} %>
            <th>活动内容</th>
            <th>发布日期</th>
            <th>开始时间</th>
            <th>结束时间</th>
             <%if (Model.isUpdate)
              {%><th></th><%} %>
             <%if (!Model.isVisit)
              {%><th></th><%} %>
             <%if (Model.isVisit)
              {%><th></th><%} %>
        </tr>

    <% foreach (var item in Model.activities) { %>
        <tr>
        <%if (Model.isDelete)
         {%><td><input type="checkbox" name="<%=item.ID%>"/></td><%} %>
        <%if (!Model.isVisit)
         { if (item.IsActive == 1){%><td>有效</td><%}
          else{ %><td>无效</td><%} } %>
         <td>
        <div class="work">
         <ul>
         <li><%=item.Content %>
         <%if(!string.IsNullOrEmpty(item.ContentDetails))
           { %>
         <ul>
         <%--<li class="nav-header">详细信息:</li>class="nav nav-pills nav-stacked"--%>
         <li><%--<a href="#">--%><%=item.ContentDetails %><%--</a>--%></li>
         </ul>
         <%} %>
         </li>
         </ul>
        </div>
        </td>
        <td><%=item.PublishTime.ToString("yyyy-MM-dd")%></td>
        <td><%=item.PreStart.ToString("yyyy-MM-dd")%></td>
        <td><%=item.OverEnd.ToString("yyyy-MM-dd")%></td>
        <%if (Model.isUpdate)
         {%><td><%= Html.ActionLink("更新", "Update", new { id=item.ID })%></td><%} %>
        <%if (!Model.isVisit)
         {%><td><%=Html.ActionLink("查看工作安排", "Details", "Work", new { id = item.ID },null)%></td><%} %>
        <%if (Model.isVisit)
         {%><td><%if (item.IsVisitApply == 1)
                  { %><button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Visit/Apply/"+item.ID) %>'">
         <i class="icon-heart icon-white"></i>&nbsp;参加&nbsp;<i class="icon-heart icon-white"></i></button><%} %></td><%} %>
        </tr>
    <% } %>
    </table>
    <div>
    <%if (Model.isDelete) 
     { %>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的活动</button>
      <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Activity/Add") %>'">添加新的活动</button>
      <%} } %>
    </div>
    </form>

    <div style="width:940px;margin: 0 auto;">  <%--style="width:90%; margin: 0 auto;"--%>
    <div class="page-header">
    </div>
    <div id="myCarousel" class="carousel slide">
      <!-- Carousel items -->
      <div class="carousel-inner">
        <div class="item active"><img src="<%=Url.Content("~/Images/Activity/Activity_01.jpg") %>" alt=""/>
        <div class="carousel-caption">
        <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织</p>
        </div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Activity/Activity_02.jpg") %>" alt=""/>
        <div class="carousel-caption">
                <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织</p>
        </div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Activity/Activity_03.jpg") %>" alt=""/>
        <div class="carousel-caption">
                <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织</p>
        </div></div>
      </div>
      <!-- Carousel nav -->
      <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
      <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
    </div>
    <div class="page-header">
    </div>
    </div>
    </div>
  </div> 
</div>
<%Html.RenderPartial("Bottom"); %>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/jquery.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/bootstrap-carousel.js") %>"></script>
<script type="text/javascript">
    $('#myCarousel').carousel();
</script>
</body>
</html>

