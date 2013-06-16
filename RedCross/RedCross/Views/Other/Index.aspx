<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" html xmlns:wb=“http://open.weibo.com/wb”>
<head>
    <title>红会</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
    <script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js" type="text/javascript" charset="utf-8"></script>
    
    <%--<link href="~/Content/bootstrap.min.css" rel="stylesheet"/>--%>
    <%--<link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>--%>
</head>
<body>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container">
    <div class="row">
    <div class="hero-unit">
<%--    <div class="span3">
    <ul class="thumbnails">
        <li>
        <a href="#" class="thumbnail">
            <img src="/Images/logo.png" alt="北师大校红十字会"/>
        </a>
        </li>
     </ul>
    </div>--%>
      <h2>北师大珠海分校校红十字会&nbsp;</h2><%--<wb:follow-button uid="1654675690" type="red_1" width="67" height="24" ></wb:follow-button>--%>
      <p><h1>人道&nbsp;·&nbsp;博爱&nbsp;·&nbsp;奉献</h1></p>
      <p>
      <button type="button" class="btn btn-danger btn-large" style="font-size:20px;" onclick="location.href='<%=Url.Content("~/Family/Details") %>'">
       红会家谱</button>&nbsp;&nbsp;
      <button type="button" class="btn btn-primary btn-large" style="font-size:20px;" onclick="location.href='<%=Url.Content("~/Activity/Details") %>'">
      <i class="icon-heart icon-white"></i>&nbsp;报名参加活动&nbsp;<i class="icon-heart icon-white"></i></button></p>
    </div>
    </div>
    <div class="row">
    <div class="page-header">
    <h2 class="page-header-title">感谢您一直以来的支持和关注</h2>
    </div>
     <div class="span6">
    <h2>红会介绍</h2>
    <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织.</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Department/Details") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    <div class="span6">
    <h2>红会公告</h2>
    <p>我们会不定时地发布一些公告，包含红会的爱心活动、培训、招新等</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Notice/Details") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    </div>
    <div class="row">
    <div style="width:940px;margin: 0 auto;">  <%--style="width:90%; margin: 0 auto;"--%>
    <div class="page-header">
    </div>
    <div id="myCarousel" class="carousel slide">
      <!-- Carousel items -->
      <div class="carousel-inner">
        <div class="item active"><img src="<%=Url.Content("~/Images/Index_01.jpg") %>" alt=""/>
        <div class="carousel-caption">
        <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织</p>
        </div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Index_02.jpg") %>" alt=""/>
        <div class="carousel-caption">
                <p>红十字会是一个遍布全球的慈善救援组织，目的是为推动“红十字运动”（或称“红十字与红新月运动”），
    是全世界组织最庞大，也是最有影响力的类似组织，除了许多国家立法保障其特殊地位外，于战时红十字也常与政府、军队紧密合作，成为了一个人尽皆知的慈善组织</p>
        </div></div>
        <div class="item"><img src="<%=Url.Content("~/Images/Index_03.jpg") %>" alt=""/>
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
    <div class="row">
    <div class="span4">
    <h2>爱心活动</h2>
    <p>我们会不定期发布一些公益活动，欢迎所有童鞋参与，点击看看，说不定会有你想参加的活动喔！</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Activity/Details") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    <div class="span4">
    <h2>红会家谱</h2>
    <p>历届红会成员名单，里面有着他们的祝福和希望，快去围观吧！</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Family/Details") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    <div class="span4">
    <h2>红会文章</h2>
    <p>活动文章、报道等</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Article/Index") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    </div>
    <div class="row">
    <div class="span4">
    <h2>大事记</h2>
    <p>记录了红会的点点滴滴，等着你来继续谱写下去</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/ImportantEvent/Details") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
    </div>
    <div class="span4">
    <h2>联系我们</h2>
    <p>有疑问，猛戳这里，可以联系到我们哦！</p>
    <p><button type="button" class="btn btn-success" onclick="location.href='<%=Url.Content("~/Other/Contant") %>'">
    <i class=" icon-plus icon-white"></i>&nbsp;了解更多</button></p>
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
