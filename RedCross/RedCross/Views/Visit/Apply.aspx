<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_Visit>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-参加活动</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
<%Html.RenderPartial("Navbar"); %>
    <div class="container">
    <div class="row">
    <div class="CenterUpLeft">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/Visit/Apply") %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">感谢您的参与</h1>
    </div>
    <%if (Model != null)
      {%> 
    <div class="alert alert-block alert-error">
    <%for (int i = 0;i<Model.list_err.Count;++i) {%>
     <p><%=Model.list_err[i] %></p>
    <% } %>
    </div>
    <%} %>
    <div style="display:none"><input name="activityId" value="<%=ViewData["activity"] %>"/></div>
    <div class="control-group">
    <label class="control-label" for="userid">学号</label>
    <div class="controls">
      <input type="text" id="userid" name="userid" <%if(Model != null && !string.IsNullOrEmpty(Model.visit.UserID)){ %> value="<%=Model.visit.UserID %>" <%} %>/>
      <div id="useridErr" style="display:none" class="Err"></div>
    </div>
    </div>
    <div class="control-group">
    <label class="control-label" for="username">姓名</label>
    <div class="controls">
      <input type="text" id="username" name="username" <%if(Model != null && !string.IsNullOrEmpty(Model.visit.UserName)){ %> value="<%=Model.visit.UserName %>" <%} %>/>
      <div id="usernameErr" style="display:none" class="Err"></div>
    </div>
    </div>
    <div class="control-group">
    <label class="control-label" for="telenumber">长号或短号</label>
    <div class="controls">
      <input type="text" id="telenumber" name="telenumber" <%if(Model != null && !string.IsNullOrEmpty(Model.visit.Phone)){ %> value="<%=Model.visit.Phone %>" <%} %>/>
      <div id="telenumberErr" style="display:none" class="Err"></div>
    </div>
    </div>
    <div class="form-actions">
      <button id="applysubmit" type="submit" class="btn btn-primary btn-large span2">报名</button>
      <%--<input id="applysubmit" type="submit" class="btn btn-primary btn-large span2" value="报名"/>--%>
    </div>
    </form>
    </div>
    </div>
    </div>
   
   <%Html.RenderPartial("Bottom"); %>

    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/VerifyNew.js") %>"></script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/ApplyVerify.js") %>"></script>

</body>
</html>
