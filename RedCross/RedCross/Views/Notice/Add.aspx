<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="RedCross" %>
<%@ Import Namespace="System" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-创建公告</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/calendar.js") %>"></script>
</head>
<body>
 <%Html.RenderPartial("Navbar", "Notice"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Notice"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/Notice/Add?curPage=" + ViewData["curPage"]) %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">创建公告</h1>
    </div>
    <div class="alert alert-block alert-info">
    <h4 class="alert-heading">温馨提示:</h4>
    置顶的公告最多只能<strong>8条</strong>,超过8条<strong>依然可以</strong>选择置顶,但在其他置顶的公告<strong>取消置顶</strong>之后,新添加的公告才会<strong>自动置顶</strong>
    </div>
    <div class="control-group">
    <label class="control-label" for="content">内容</label>
    <div class="controls">
      <textarea id="content" name="content" rows="8" cols="75"></textarea>
      <div id="contentErr" style="display:none" class="Err"></div>     
    </div>
    </div>
    <div class="control-group">
    <label class="control-label" for="publish">发布时间</label>
    <div class="controls">
      <input type="text" id="publish" name="publish" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>" onclick="calendar.show(this);" />
      <div id="publishErr" style="display:none" class="Err"></div>     
    </div>
    </div>
   <div class="control-group">
   <label class="control-label">面向范围</label>
      <div class="controls">
     <label class="radio">
      <input type="radio" name="ntype" value="1" checked="checked"/>
      所有人
    </label>
    <label class="radio">
      <input type="radio" name="ntype" value="0"/>
      仅会内
    </label>
    </div>
    </div>
   <div class="control-group">
   <label class="control-label">是否置顶</label>
      <div class="controls">
     <label class="radio">
      <input type="radio" name="isTop" value="1" checked="checked"/>
      置顶
    </label>
    <label class="radio">
      <input type="radio" name="isTop" value="0"/>
      不需要
    </label>
    </div>
    </div>
    <div class="form-actions">
      <button id="noticesubmit" type="submit" class="btn btn-primary">添加</button>
      <button type="button" class="btn" onclick="history.back()">取消</button>
    </div>
    </form>
    </div>
    </div>
    </div>
     <%Html.RenderPartial("Bottom"); %>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/VerifyNew.js") %>"></script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/NoticeVerify.js") %>"></script>
</body>
</html>
