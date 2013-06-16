<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Family>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-家谱</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Pager.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/All_Reverse.js") %>"></script>
<%Html.RenderPartial("Navbar", "Family"); %>

    <div <%if (!Model.isVisit){ %>class="container-fluid"<%}else{%>class="container"<%} %>>
    <div <%if (!Model.isVisit){ %>class="row-fluid"<%}else{%>class="row"<%} %>>
    <%if (!Model.isVisit){ %>
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <%} %>
    <div <%if (!Model.isVisit){ %>class="span9"<%} %>>
    <div class="page-header">
    <h1 class="page-header-title">我们的家谱<small><p>生活可以是平淡的，犹如蓝天下碧蓝的湖水。生活也可以是诗，在一路的奔腾中高歌。只要我们牵着手，每一个日子都是幸福。 感谢一路有你</p></small></h1>
    </div>
    <div style="width:940px;margin: 0 auto; height:320px;">  <%--style="width:90%; margin: 0 auto;"--%>
    <div id="myCarousel" class="carousel slide">
      <!-- Carousel items -->
      <div class="carousel-inner">
        <div class="item active"><img src="<%=Url.Content("~/Images/Family/Family_01.jpg") %>" alt=""/>
        <div class="carousel-caption">
        <p>06级&nbsp;邱俊杰&nbsp;&nbsp;07级&nbsp;何润东</p></div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Family/Family_02.jpg") %>" alt=""/>
        <div class="carousel-caption">
        <p>06级&nbsp;何婷&nbsp;&nbsp;06级&nbsp;叶芷兰&nbsp;&nbsp;06级&nbsp;李学聪</p></div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Family/Family_03.jpg") %>" alt=""/>
        <div class="carousel-caption">
        <p>08级&nbsp;徐志强&nbsp;&nbsp;05级&nbsp;会长&nbsp;&nbsp;谭老师</p></div></div>
      </div>
      <!-- Carousel nav -->
      <a class="carousel-control left" href="#myCarousel" data-slide="prev">&lsaquo;</a>
      <a class="carousel-control right" href="#myCarousel" data-slide="next">&rsaquo;</a>
    </div>
    </div>

    <form id="" action="<%=Url.Content("~/Family/Delete?curPage=" + Model.paginate.CurrentPage) %>" method="post">
    <%if (!string.IsNullOrEmpty(Model.msg))
      { %>
    <div class="alert alert-success">
    <%=Model.msg%>
    </div>
    <%} %>
        <table class="table table-hover table-striped" id="FamilySelect">
        <tr>
            <%if (Model.isDelete)
              {%><th><input type="checkbox" name="" onclick="checkAllorInverse(this,'FamilySelect')"/></th><%} %>
            <th>学号</th>
            <th>姓名</th>
            <th style="width:35%"><i class="icon-heart"></i>签名与祝福</th>
            <th>部门</th>
            <th>性别</th>
            <th>年级</th>
            <th>学院</th>
            <%if (Model.isUpdate)
              {%><th></th><%} %>
        </tr>

    <% foreach (var item in Model.List_Family) { %>
        <tr>
           <%if (Model.isDelete)
           {%>
        <td><input type="checkbox" name="<%=item.ID%>"/></td>
        <%} %>
        <td><%=item.UserID %></td>
        <td><%=item.UserName %></td>
        <td><i class="icon-heart"></i><%=item.Wish %></td>
        <td><%=item.Dep.Name %></td>
        <td><%=item.Sex == 1? "男":"女" %></td>
        <td><%=item.Grd.Name %></td>
        <td><%=item.Clg.Name %></td>
        <%if (Model.isUpdate)
          {%>
            <td><%= Html.ActionLink("更新", "Update", new { id = item.ID, curPage = Model.paginate.CurrentPage })%></td> 
       <%} %>    
        </tr>
    <% } %>
    </table>
    <%if (Model.isDelete) %>
    <%{ %>
    <div>
      <button type="submit" class="btn btn-warning"><i class="icon-trash icon-white"></i>&nbsp;删除所选择的成员</button>
      <%if (Model.isAdd)
      { %>
      <button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Family/Add?curPage=" + Model.paginate.CurrentPage) %>'">添加新的成员</button>
      <%} %>
    </div>
    <%} %>
    </form>
    <div id="pager"><%=Html.PagerMutiParam(Model.paginate.CurrentPage, Model.paginate.TotalPages, Url.Content("~/Family/Details?curpage="))%></div>
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

