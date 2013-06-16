<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:wb="http://open.weibo.com/wb">
<head runat="server">
    <title>红会-联系方式</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Other"); %>
    <div class="container">
    <div class="row">
    <div class="page-header">
    <h1 class="page-header-title">联系我们</h1>
    </div>
    <script src="http://tjs.sjs.sinajs.cn/open/api/js/wb.js" type="text/javascript" charset="utf-8"></script>
    <div><center>
    <wb:bulkfollow uids="1934688341,2020492475,1881894342" type="1" width="260" count="10" color="C2D9F2,FFFFFF,0082CB,666666" ></wb:bulkfollow>
    </center></div>
    </div>
    </div>
   
   <%Html.RenderPartial("Bottom"); %>
</body>
</html>
