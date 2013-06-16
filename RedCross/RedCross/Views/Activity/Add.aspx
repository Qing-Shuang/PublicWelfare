<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_Activity>" %>
<%@ Import Namespace="RedCross" %>
<%@ Import Namespace="System" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-添加活动</title>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/calendar.js") %>"></script>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar","Activity"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Activity"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/Activity/Add") %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">添加活动</h1>
    </div>
  <div class="control-group">
    <label class="control-label" for="content">主题</label>
    <div class="controls">
      <input type="text" id="content" name="content"/>
      <div id="contentErr" style="display:none" class="Err"></div> 
    </div>
  </div>
    <div class="control-group">
    <label class="control-label" for="prestart">开始时间</label>
    <div class="controls">
      <input type="text" id="prestart" name="prestart" onclick="calendar.show(this);"/>
      <div id="prestartErr" style="display:none" class="Err"></div>     
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="overend">结束时间</label>
    <div class="controls">
      <input type="text" id="overend" name="overend" onclick="calendar.show(this);"/>
      <div id="overendErr" style="display:none" class="Err"></div>         
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="contentdetails">详细描述</label>
    <div class="controls">
      <textarea id="contentdetails" name="contentdetails" rows="8" cols="75"></textarea>
      <div id="contentdetailsErr" style="display:none" class="Err"></div>
    </div>
    </div>
    <div class="control-group">
    <label class="control-label" for="publish">发布时间</label>
    <div class="controls">
      <input type="text" id="publish" name="publish" value="<%=DateTime.Now.ToString("yyyy-MM-dd")%>"  onclick="calendar.show(this);"/>
      <div id="publishErr" style="display:none" class="Err"></div>    
    </div>
  </div>
   <div class="control-group">
   <label class="control-label">是否有效</label>
    <div class="controls">
     <label class="radio">
      <input type="radio" name="isactive" value="1" checked='checked'/>
      有效
    </label>
    <label class="radio">
      <input type="radio" name="isactive" value="0"/>
      无效
    </label>
    </div>
  </div>
    <div class="control-group">
    <label class="control-label" for="isvisitapply">会员是否参加</label>
    <div class="controls">
      <label class="checkbox">
      <input type="checkbox" id="isvisitapply" name="isvisitapply"/>参加</label>
    </div>
    </div>
    <%--<%=m_HtmlHelper.Radio("是否有效", "有", "active", "isactive", 1)%><%=m_HtmlHelper.Radio("", "否", "noactive", "isactive", 0)%>--%>
<%--    <div class="control-group">
    <label class="control-label" for="preend">前期结束时间</label>
    <div class="controls">
      <input type="text" id="preend" name="preend" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--    <div class="control-group">
    <label class="control-label" for="midstart">中期开始时间</label>
    <div class="controls">
      <input type="text" id="midstart" name="midstart" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--    <div class="control-group">
    <label class="control-label" for="midend">中期结束时间</label>
    <div class="controls">
      <input type="text" id="midend" name="midend" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--      <div class="control-group">
    <label class="control-label" for="overstart">后期开始时间</label>
    <div class="controls">
      <input type="text" id="overstart" name="overstart" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
    <div class="form-actions">
      <button id="activitysubmit" type="submit" class="btn btn-primary">添加</button>
      <button type="button" class="btn" onclick="history.back()">取消</button>
    </div>
    </form>
    </div>
    </div>
        <%Html.RenderPartial("Bottom"); %>
    </div>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/VerifyNew.js") %>"></script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/ActivityVerify.js") %>"></script>
</body>
</html>
