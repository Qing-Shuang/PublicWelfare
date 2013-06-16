<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-开发中</title>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
</head>
<body>
 <%Html.RenderPartial("Navbar"); %>
    <div class="container">
    <br />
    <br />
    <div class="row">
    <center><img src="<%=Url.Content("~/Images/process1.jpg") %>" alt="进行当中"/></center>
    </div>
    <div class="row">
    <div class="alert alert-info alert-block">
    <center><h2>（～￣▽￣～）--- --- 正在开发当中 --- --- ㄟ(￣▽￣ㄟ)</h2></center>
    </div>
    </div>
    </div>
    <%Html.RenderPartial("Bottom"); %>
</body>
</html>
