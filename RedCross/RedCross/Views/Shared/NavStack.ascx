<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<ul class="nav nav-pills nav-stacked">
        <li class="nav-header">导航</li>
        <li <%if(Model=="PersonalHome"){ %>class="active"<%} %>><a href="<%=Url.Content("~/User/PersonalHome") %>">
        <i <%if(Model=="PersonalHome"){ %>class="icon-home icon-white"<%} else{%>class="icon-home"<%} %>></i> 我的中心</a></li>
        <li <%if(Model=="Search"){ %>class="active"<%} %>><a href="<%=Url.Content("~/TimeTable/Search") %>">
        <i <%if(Model=="Search"){ %>class="icon-search icon-white"<%} else{%>class="icon-search"<%} %>></i> 无课查询</a></li>
        <li <%if(Model=="Detail"){ %>class="active"<%} %>><a href="<%=Url.Content("~/TimeTable/Detail") %>">
        <i <%if(Model=="Detail"){ %>class="icon-book icon-white"<%} else{%>class="icon-book"<%} %>></i> 个人课表</a></li>
        <li <%if(Model=="Update"){ %>class="active"<%} %>><a href="<%=Url.Content("~/TimeTable/Update") %>">
        <i <%if(Model=="Update"){ %>class="icon-pencil icon-white"<%} else{%>class="icon-pencil"<%} %>></i> 修改课表</a></li>
        <li <%if(Model=="Notice"){ %>class="active"<%} %>><a href="<%=Url.Content("~/Notice/Details") %>">
        <i <%if(Model=="Notice"){ %>class="icon-comment icon-white"<%} else{%>class="icon-comment"<%} %>></i> 公告</a></li>
        <li <%if(Model=="Activity"){ %>class="active"<%} %>><a href="<%=Url.Content("~/Activity/Details") %>">
        <i <%if(Model=="Activity"){ %>class="icon-heart icon-white"<%} else{%>class="icon-heart"<%} %>></i> 活动和任务</a></li>
        <li <%if(Model=="PermissionNewUser"){ %>class="active"<%} %>><a href="<%=Url.Content("~/User/PermissionNewUser") %>">
        <i <%if(Model=="PermissionNewUser"){ %>class="icon-ok icon-white"<%} else{%>class="icon-ok"<%} %>></i> 审核新成员</a></li>
</ul>