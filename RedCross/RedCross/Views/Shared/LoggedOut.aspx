<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>您还未登录</title>
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
        <div id="main-content2">
        <fieldset id="LoggedOut">
                您还未登录噢，<label id="time_LoggedOut"></label> 秒后将跳转到登录界面...
        </fieldset>
        </div>
    <div id="nav">    
        &#169;2011 WeiJiaPeng  | Email:jiapeng0828@126.com
    </div>
    <script language="javascript" type="text/javascript">
        var label = document.getElementById("time_LoggedOut");
        var count = 5;
        setInterval("label.innerText=" + count--, 1000);
        //setTimeout("window.location.replace('/User/Login')", 5000);
    </script>
</body>
</html>
