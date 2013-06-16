<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_Department>" %>
<%@ Import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>红会-添加部门</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Department"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "PersonalHome"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/Department/Add") %>" method="post">
    <div class="page-header">
    <h2>添加部门</h2>
    </div>
    <div class="control-group">
    <label class="control-label" for="depname">名称</label>
    <div class="controls">
      <input type="text" id="depname" name="name"/>
      <div id="depnameErr" style="display:none" class="Err"></div>     
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="introduce">介绍</label>
    <div class="controls">
      <textarea id="introduce" rows="8" cols="75" name="introduce"></textarea>
      <div id="introduceErr" style="display:none" class="Err"></div>         
    </div>
          <div class="form-actions">
              <button id="depsubmit" type="submit" class="btn btn-primary">
                  添加</button>
              <button type="button" class="btn" onclick="history.back()">
                  取消</button>
          </div>
    </form>
    </div>
    </div>
    <%Html.RenderPartial("Bottom"); %>
    </div>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/VerifyNew.js") %>"></script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/DepartmentVerify.js") %>"></script>
</body>
</html>
