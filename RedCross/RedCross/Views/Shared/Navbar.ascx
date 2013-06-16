<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ import Namespace="RedCross" %>
<%@ import Namespace="RedCross.Models.Entities.Base" %>
<%@ Import Namespace="System.Web" %>

<div class="navbar">
  <div class="navbar-inner">
    <div class="container">
    <a class="brand" href="<%=Url.Content("~/Other/Index") %>">
    <%--<i class=" icon-plus icon-white"></i>--%>&nbsp;北师大红十字会
    </a>
    <div class="nav-collapse"> 
    <ul class="nav">
    <li id="otherIndex" <%if(Model=="Index"){ %>class="active"<%} %>><%=Html.ActionLink("主页", "Index", "Other")%></li>
    <li <%if(Model=="Department"){ %>class="active"<%} %>><%=Html.ActionLink("红会介绍", "Details", "Department")%></li>
    <li <%if(Model=="Family"){ %>class="active"<%} %>><%=Html.ActionLink("红会家谱", "Details", "Family")%></li>
    <li <%if(Model=="Activity"){ %>class="active"<%} %>><%=Html.ActionLink("爱心活动", "Details", "Activity")%></li>
<%--    <li><%=Html.ActionLink("预约活动", "Index", "Article")%></li>--%>
    <li <%if(Model=="Notice"){ %>class="active"<%} %>><%=Html.ActionLink("红会公告", "Details", "Notice")%></li>
<%--    <li <%if(Model=="Article"){ %>class="active"<%} %>><%=Html.ActionLink("文章", "Index", "Article")%></li>--%>
    <li <%if(Model=="ImportantEvent"){ %>class="active"<%} %>><%=Html.ActionLink("大事记", "Details", "ImportantEvent")%></li>
<%--    <li><%=Html.ActionLink("留言板", "Index", "Article")%></li>--%>
<%--    <li><%=Html.ActionLink("红会招新", "", "")%></li>--%>
    <li <%if(Model=="Other"){ %>class="active"<%} %>><%=Html.ActionLink("联系我们", "Contact", "Other")%></li>
    </ul>
    <ul class="nav pull-right">
    <%if (Request.Cookies[GLB.userId] == null || string.IsNullOrEmpty(Request.Cookies[GLB.userId].Value))
      { %>
    <li <%if(Model!="Register"){ %>class="active"<%} %>><%=Html.ActionLink("登录", "Login", "User")%></li>
    <li id="userRegister" <%if(Model=="Register"){ %>class="active"<%} %>><%=Html.ActionLink("注册", "Register", "User")%></li>
    <%}
      else
      { %>
      <li id="userPersonalHome" class="active"><%=Html.ActionLink("欢迎!  "+ HttpUtility.UrlDecode(Request.Cookies[GLB.userName].Value, Encoding.UTF8), 
                             "PersonalHome", "User")%></li>
      <li><a id="logout" href="<%=Url.Content("~/Other/Index")%>">退出</a></li>
        <%} %>
        <%--Html.ActionLink(HttpUtility.UrlDecode(Request.Cookies[GLB.userId].Value, Encoding.UTF8)--%>
    </ul>
      
      <%if (Request.Cookies[GLB.userId] == null || string.IsNullOrEmpty(Request.Cookies[GLB.userId].Value))
      {}else{ %>
      <div style="display:none">
      <label id="Name"><%=Request.Cookies[GLB.userId].Name%></label>
      <label id="Domain"><%=Request.Cookies[GLB.userId].Domain%></label>
      <label id="Path"><%=Request.Cookies[GLB.userId].Path%></label>
      <label id="Expires"><%=Request.Cookies[GLB.userId].Expires%></label>
      <label id="Secure"><%=Request.Cookies[GLB.userId].Secure%></label>
      </div>
      <%}%>
      
    </div>
    </div>
  </div>
</div>

<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/CookieUtil.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/EventUtil.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/LogOut.js") %>"></script>