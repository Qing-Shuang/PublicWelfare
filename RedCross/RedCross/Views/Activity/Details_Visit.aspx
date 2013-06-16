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
    <%Html.RenderPartial("Navbar", "Activity"); %>

    <div class="container">
    <div class="row">
    <div class="page-header">
    <h1 class="page-header-title">爱心活动<small><p>我们会不定期发布一些公益活动，欢迎所有童鞋参与，点击看看，说不定会有你想参加的活动喔！</p></small></h1>
    </div>

    <div class="row"><button type="button" class="btn btn-success btn-large span2"  onclick="location.href='<%=Url.Content("~/Visit/Details") %>'">已参加成员</button></div><br />

    <div class="row">
    <div class="span12">
    
    <ul class="thumbnails">
    <% foreach (var item in Model.activities)
       {   %>

  <li class="span4">
    <div class="thumbnail">
    <div class="caption">
      <h3><%=item.Content%></h3>
      <p><%=item.ContentDetails%></p>
      <p>开始时间：<%=item.PreStart.ToString("yyyy-MM-dd")%></p>
      <p>结束时间：<%=item.OverEnd.ToString("yyyy-MM-dd")%></p>
      <%if (item.IsVisitApply == 1)
        { %>
      <p><button type="button" class="btn btn-primary"  onclick="location.href='<%=Url.Content("~/Visit/Apply/"+item.ID) %>'">
         <i class="icon-heart icon-white"></i>&nbsp;参加&nbsp;<i class="icon-heart icon-white"></i></button></p>
         <%} %>
         </div>
    </div>
  </li>
  <%} %>
</ul>
</div>
</div>

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

<%Html.RenderPartial("Bottom"); %>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/jquery.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/bootstrap-carousel.js") %>"></script>
<script type="text/javascript">
    $('#myCarousel').carousel();
</script>
</body>
</html>

