<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Success</title>
        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />
</head>
<body>
<div id="header">
            <div id="branding">
            <h1>
            <img src="/Images/Share.Curiosity 5.png" alt="logo" /></h1>
            </div>
            <div id="tabwrapper">
            <%=Html.ActionLink("登录","Login","User") %>
            <%=Html.ActionLink("注册", "Register", "User")%>
            </div>
</div>
<div id="divider">
            <div id="left">
            <%=Html.ActionLink("主页","Detail","Article") %>
            <%=Html.ActionLink("留言板","Detail","Article") %>
            </div>
</div>
<div id="select"><label id="person"></label><a id="personLink"></a><a id="changePerson"></a></div>
    <div id="main-content2">
    <fieldset id="info">
    <%=Html.ActionLink("添加自己的课表","Add","TimeTable") %> |
    <%=Html.ActionLink("查看自己的课表","Detail","Timetable") %> | 
    <%=Html.ActionLink("无课查询", "Select", "Timetable")%>
    <p>～～～你的操作已完成～～～</p>
    </fieldset>
    </div>
            <div id="nav">    
        &#169;2011 WeiJiaPeng  | Email:jiapeng0828@126.com
    </div>
    <script type="text/javascript" src="/Scripts/Rc/CookieUtil.js"></script>
    <script type="text/javascript" src="/Scripts/Rc/UserInfo.js"></script>
</body>
</html>
