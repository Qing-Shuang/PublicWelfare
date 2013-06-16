<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Status>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>红会-登录</title>
<%--    <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Form.css") %>" />
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
</head>
<body>
<%Html.RenderPartial("Navbar", "Login"); %>

<%--<div id="main-content2">--%>
<div id="login">
<form action="<%=Url.Content("~/User/Login") %>" method="post">
<fieldset id="info">
<h1>登录</h1>

<div id="ErrFromServerVerify"  <%if (Model != null && Model.list_ErrMsg != null && Model.list_ErrMsg.Count > 0)
{%>style="display:"
<%}else{ %>style="display:none"<%} %>>
<%if (Model != null && Model.list_ErrMsg != null && Model.list_ErrMsg.Count > 0)
  {%>
      <ol>
      <%for (int i = 0; i < Model.list_ErrMsg.Count; ++i)
      { %>
        <li><%=Model.list_ErrMsg[i] %></li>
      <%}%>
        </ol>
  <%} %>
</div>

<ol>
<li>
    <label for="userID">学号</label>
    <input type="text" id="userID" name="userID"
    <%if(Model != null && Model.user !=null){ %>value="<%=Model.user.UserID%>"<%} %>/>
</li>
<li>
    <div id="userIDErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="pwd">密码</label>
    <input type="password" id="pwd" name="pwd"
     <%if(Model != null && Model.user !=null){ %>value="<%=Model.user.Password%>"<%} %> 
     onpaste="return false" oncopy="return false" oncut="return false"/>
</li>
<li>
    <div id="pwdErr" style="display:none" class="Err"></div>
</li>
<li>
    <label id="msg_register"><%=Html.ActionLink("还没注册？", "Register")%></label>
</li>
<li>
<input id="submit" type="submit" value="登录"/>
</li>
</ol>   
</fieldset>
</form>
</div>

<%Html.RenderPartial("Bottom"); %>
<%--<%Html.RenderPartial("Nav"); %>--%>

<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/Verify.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/Form_Login.js") %>"></script>
</body>
</html>
