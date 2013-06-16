<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Status>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>红会-注册</title> 
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Form.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>

<%Html.RenderPartial("Navbar", "Register"); %>

<div id="main-content2">
<div id="info_frame">
    <div class="page-header">
    <h1 class="page-header-title">感谢您的注册</h1>
    </div>

<div id="info_left">
    <div class="page-header">
    <h1>注意噢：</h1>
    </div>
<p>1、注册时候左手边几项都是必填项，需全部填满才能注册.</p>
<p>2、没有短号的童鞋可直接填入"666666"代替.</p>
<p>3、你所填写信息须是真实信息，在24小时内工作人员将进行审核，通过后你就可以使用本站功能.</p>
<p>4、感谢你对红会和本站的支持，如有任何问题，可发邮件到 wumeng1118@gmail.com .</p>
<div>

</div>
<%--<blockquote id="msg_refister_note">
</blockquote>--%>
</div>

<div id="info_right">
<form id="register" action="<%=Url.Content("~/User/Registering") %>" method="post">
<fieldset id="info">
<h1>注册</h1>

<div id="ErrFromServerVerify"  <%if (Model.list_ErrMsg != null && Model.list_ErrMsg.Count > 0){%>style="display:"
<%}else{ %>style="display:none"<%} %>>
<%if (Model.list_ErrMsg != null && Model.list_ErrMsg.Count > 0)
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
    <label for="userNo">学号</label><input id="userNo" type="text" name="userNo"
    <%if(Model.user !=null){ %>value="<%=Model.user.UserID%>"<%} %>/>
</li>
<li>
    <div id="userNoErr" style="display:none" class="Err"></div>
</li>
<li>
<label for="userName">姓名</label><input id="userName" type="text" name="userName"
<%if(Model.user !=null){ %>value="<%=Model.user.UserName%>"<%} %>/>
</li>
<li>
    <div id="userNameErr" style="display:none" class="Err"></div>
</li>
<li>
<label for="userPassword">密码</label><input id="userPassword" type="password" name="userPassword"
<%if(Model.user !=null){ %>value="<%=Model.user.Password%>"<%} %> 
onpaste="return false" oncopy="return false" oncut="return false"/>
</li>
<li>
    <div id="userPasswordErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="userPasswordRepeat">重输密码</label>
    <input id="userPasswordRepeat" type="password" name="userPasswordRepeat"
    <%if(Model.user !=null){ %>value="<%=Model.user.Password%>"<%} %>
    onpaste="return false" oncopy="return false" oncut="return false"/>
</li>
<li>
    <div id="userPasswordRepeatErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="Sex">性别</label>
    <input id="SexM" type="radio" name="Sex" value="1"
   <%if(Model.user !=null && Model.user.Sex == 1){ %> checked="checked"<%}
   else if (Model.user == null){%> checked="checked"<%}%>/>男
    <input id="SexW" type="radio" name="Sex" value="0"
    <%if(Model.user !=null && Model.user.Sex == 0){ %> checked="checked"<%}%>/>女
</li>
<li>
    <div id="SexErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="grdID">年级</label><select id="grdID" name="grdID">
    <option></option>
    <%for (int i = 0; i < Model.list_Grd.Count; ++i)
      { %>
      <option value="<%=Model.list_Grd[i].ID %>" 
      <%if(Model.user !=null && Model.user.Grd !=null && Model.user.Grd.ID == Model.list_Grd[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Grd[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="grdIDErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="collageID">学院</label><select id="collageID" name="collageID">
    <option></option>
    <%for (int i = 0; i < Model.list_Col.Count; ++i)
      { %>
      <option value="<%=Model.list_Col[i].ID %>"
      <%if(Model.user !=null && Model.user.Clg !=null && Model.user.Clg.ID == Model.list_Col[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Col[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="collageIDErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="depID">部门</label><select id="depID" name="depID">
    <option></option>
    <%for (int i = 0; i < Model.list_Dep.Count; ++i)
      { %>
      <option value="<%=Model.list_Dep[i].ID %>"
      <%if(Model.user !=null && Model.user.Dep !=null && Model.user.Dep.ID == Model.list_Dep[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Dep[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="depIDErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="roleID">职位</label><select id="roleID" name="roleID">
    <option></option>
    <%for (int i = 0; i < Model.list_Role.Count; ++i)
      { %>
      <option value="<%=Model.list_Role[i].ID %>"
      <%if(Model.user !=null && Model.user.Ro !=null && Model.user.Ro.ID == Model.list_Role[i].ID)
      { %>selected="selected"<%} %>>
      <%=Model.list_Role[i].Name%>
      </option>
      <%} %>
    </select>
</li>
<li>
    <div id="roleIDErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="phone">长号</label><input  id="phone" type="text" name="phone"
    <%if(Model.user !=null){ %>value="<%=Model.user.Phone%>"<%} %>/>
</li>
<li>
    <div id="phoneErr" style="display:none" class="Err"></div>
</li>
<li>
    <label for="phone_short">短号</label><input  id="phone_short" type="text" name="phone_short"
    <%if(Model.user !=null){ %>value="<%=Model.user.Phone_short%>"<%} %>/>
</li>
<li>
    <div id="phone_shortErr" style="display:none" class="Err"></div>
</li>
<li>
<input id="submit" type="submit" value="注册"/>
</li>
</ol>
</fieldset>
</form>
</div>

</div>
</div>

<%Html.RenderPartial("Bottom"); %>
        <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/Verify.js") %>"></script>
        <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/Form_Register.js") %>"></script>
</body>
</html>
