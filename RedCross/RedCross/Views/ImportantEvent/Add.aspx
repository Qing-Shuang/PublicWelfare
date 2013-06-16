<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@import Namespace="RedCross" %>
<%@ Import Namespace="System" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-添加大事</title>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
        <script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/calendar.js") %>"></script>
</head>
<body>
 <%Html.RenderPartial("Navbar", "ImportantEvent"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/ImportantEvent/Add?curPage=" + ViewData["curPage"]) %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">添加事项</h1>
    </div>
    <div class="control-group">
    <label class="control-label" for="publish">发布时间</label>
    <div class="controls">
      <input type="text" id="publish" name="publish" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>" onclick="calendar.show(this);"/>
      <div id="publishErr" style="display:none" class="Err"></div>     
    </div>
  </div>
    <div class="control-group">
    <label class="control-label" for="content">大事内容</label>
    <div class="controls">
      <textarea id="content" rows="8" cols="75" name="content"></textarea>
      <div id="contentErr" style="display:none" class="Err"></div>     
    </div>
    </div>
    <div class="form-actions">
    <button id="importantsubmit" type="submit" class="btn btn-primary">
        添加</button>
    <button type="button" class="btn" onclick="history.back()">
        取消</button>
    </div>
    </form>
    </div>
    </div>
    </div>
    <%Html.RenderPartial("Bottom"); %>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/VerifyNew.js") %>"></script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/ImportantVerify.js") %>"></script>
</body>
</html>
