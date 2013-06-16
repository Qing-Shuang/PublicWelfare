<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="header">
            <div id="branding">
            <h1>
            <img src="/Images/RedLogo.png" alt="logo" /></h1>
            </div>
            <div id="tabwrapper">
                <%=Html.ActionLink("登录","Login","User") %>
                <%=Html.ActionLink("注册", "Register", "User")%>
<%--                <input type="button" value="测试用(切换主题)" onclick="loadStyles('/Content/Style_Theme_Pink.css')"/>--%>
            </div>
</div>

<div id="menu_wrapper">
            <ul id="menu">
            <li class="active"><%=Html.ActionLink("主页", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会介绍", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会家谱", "Index", "Article")%></li>
            <li><%=Html.ActionLink("爱心活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会公告", "Index", "Article")%></li>
            <li><%=Html.ActionLink("大事记", "Index", "Article")%></li>
            <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会招新", "Index", "Article")%></li>
            <li><%=Html.ActionLink("联系我们", "Index", "Article")%></li>
            </ul> 
</div>



<%-- 
<div id="divider">
            <div id="left">
           <%=Html.ActionLink("主页", "Index", "Article")%>
            <%=Html.ActionLink("红会介绍", "Index", "Article")%>
            <%=Html.ActionLink("红会家谱", "Index", "Article")%>
            <%=Html.ActionLink("爱心活动", "Index", "Article")%>
            <%=Html.ActionLink("预约活动", "Index", "Article")%>
            <%=Html.ActionLink("公告", "Index", "Article")%>
            <%=Html.ActionLink("大事记", "Index", "Article")%>
            <%=Html.ActionLink("留言板", "Index", "Article")%>
            <%=Html.ActionLink("招新", "Index", "Article")%>
            <%=Html.ActionLink("联系我们", "Index", "Article")%>

            </div>
</div>

--%>

<%--

<div id="menu_wrapper" class="black">
            <ul id="menu">
            <li class="active"><%=Html.ActionLink("主页", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会介绍", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会家谱", "Index", "Article")%></li>
            <li><%=Html.ActionLink("爱心活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("公告", "Index", "Article")%></li>
            <li><%=Html.ActionLink("大事记", "Index", "Article")%></li>
            <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>
            <li><%=Html.ActionLink("招新", "Index", "Article")%></li>
            <li><%=Html.ActionLink("联系我们", "Index", "Article")%></li>
            </ul> 
</div>

<div id="menu_wrapper" class="blue">
            <ul id="menu">
            <li class="active"><%=Html.ActionLink("主页", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会介绍", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会家谱", "Index", "Article")%></li>
            <li><%=Html.ActionLink("爱心活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("公告", "Index", "Article")%></li>
            <li><%=Html.ActionLink("大事记", "Index", "Article")%></li>
            <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>
            <li><%=Html.ActionLink("招新", "Index", "Article")%></li>
            <li><%=Html.ActionLink("联系我们", "Index", "Article")%></li>
            </ul> 
</div>

<div id="menu_wrapper" class="red">
            <ul id="menu">
            <li class="active"><%=Html.ActionLink("主页", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会介绍", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会家谱", "Index", "Article")%></li>
            <li><%=Html.ActionLink("爱心活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("公告", "Index", "Article")%></li>
            <li><%=Html.ActionLink("大事记", "Index", "Article")%></li>
            <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>
            <li><%=Html.ActionLink("招新", "Index", "Article")%></li>
            <li><%=Html.ActionLink("联系我们", "Index", "Article")%></li>
            </ul> 
</div>

<div id="menu_wrapper" class="orange">
            <ul id="menu">
            <li class="active"><%=Html.ActionLink("主页", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会介绍", "Index", "Article")%></li>
            <li><%=Html.ActionLink("红会家谱", "Index", "Article")%></li>
            <li><%=Html.ActionLink("爱心活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>
            <li><%=Html.ActionLink("公告", "Index", "Article")%></li>
            <li><%=Html.ActionLink("大事记", "Index", "Article")%></li>
            <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>
            <li><%=Html.ActionLink("招新", "Index", "Article")%></li>
            <li><%=Html.ActionLink("联系我们", "Index", "Article")%></li>
            </ul> 
</div>

--%>