<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 
    <title>红会-个人资料</title>
    <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />
</head>
<body>
<%Html.RenderPartial("Header"); %>
<%Html.RenderPartial("Select_HasInfo"); %>

<%Html.RenderPartial("Nav"); %>
        <script type="text/javascript" src="../../Scripts/Rc/CookieUtil.js"></script>
    <script type="text/javascript" src="../../Scripts/Rc/UserInfo.js"></script>
</body>
</html>
