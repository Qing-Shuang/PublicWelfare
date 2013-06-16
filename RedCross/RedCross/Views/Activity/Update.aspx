<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Base.Activity>" %>
<%@import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-更新活动</title>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/bootstrap.min.css") %>"/>
    <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Tool/calendar.js") %>"></script>
</head>
<body>
 <%Html.RenderPartial("Navbar", "Activity"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Activity"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" id="" action="<%=Url.Content("~/Activity/Update") %>" method="post">
    <div class="page-header">
    <h1 class="page-header-title">更新活动</h1>
    </div>
    <div style="display:none"><input name="id" value="<%=Model.ID %>"/></div>
    <div class="control-group">
    <label class="control-label" for="content">主题</label>
    <div class="controls">
      <input type="text" id="content" name="content" value="<%=Model.Content %>"/>
      <div id="contentErr" style="display:none" class="Err"></div> 
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="prestart">开始时间</label>
    <div class="controls">
      <input type="text" id="prestart" name="prestart" value="<%=Model.PreStart.ToString("yyyy-MM-dd") %>" onclick="calendar.show(this);"/>
      <div id="prestartErr" style="display:none" class="Err"></div>         
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="overend">结束时间</label>
    <div class="controls">
      <input type="text" id="overend" name="overend" value="<%=Model.OverEnd.ToString("yyyy-MM-dd") %>" onclick="calendar.show(this);"/>
      <div id="overendErr" style="display:none" class="Err"></div>                 
    </div>
  </div>
      <div class="control-group">
    <label class="control-label" for="contentdetails">详细描述</label>
    <div class="controls">
      <textarea id="contentdetails" name="contentdetails" rows="8" cols="75"><%=Model.ContentDetails %></textarea>
      <div id="contentdetailsErr" style="display:none" class="Err"></div>
    </div>
    </div>
    <div class="control-group">
    <label class="control-label" for="publish">发布时间</label>
    <div class="controls">
      <input type="text" id="publish" name="publish" value="<%=Model.PublishTime.ToString("yyyy-MM-dd") %>"  onclick="calendar.show(this);"/>
      <div id="publishErr" style="display:none" class="Err"></div>        
    </div>
  </div>
   <div class="control-group">
   <label class="control-label">是否有效</label>
       <%if (Model.IsActive == 1)
      { %>
       <div class="controls">
           <label class="radio">
               <input type="radio" name="isactive" value="1" checked="checked" />
               有效
           </label>
           <label class="radio">
               <input type="radio" name="isactive" value="0" />
               无效
           </label>
       </div>
      <%}
      else
      { %>
         <div class="controls">
         <label class="radio">
          <input type="radio" name="isactive" value="1"/>
          有效
        </label>
        <label class="radio">
          <input type="radio" name="isactive" value="0" checked="checked"/>
          无效
        </label>
        </div>
      <%} %>
  </div>
    <div class="control-group">
    <label class="control-label" for="isvisitapply">会员是否参加</label>
    <div class="controls">
      <label class="checkbox">
      <input type="checkbox" id="isvisitapply" name="isvisitapply" <%if(Model.IsVisitApply == 1){ %> checked="checked"<%} %>/>参加</label>
    </div>
    </div>
<%--    <div class="control-group">
    <label class="control-label" for="prestart">前期开始时间</label>
    <div class="controls">
      <input type="text" id="prestart" name="prestart" value="<%=Model.PreStart.ToString("yyyy-MM-dd") %>"  onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--    <div class="control-group">
    <label class="control-label" for="preend">前期结束时间</label>
    <div class="controls">
      <input type="text" id="preend" name="preend" value="<%=Model.PreEnd.ToString("yyyy-MM-dd") %>"  onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--    <div class="control-group">
    <label class="control-label" for="midstart">中期开始时间</label>
    <div class="controls">
      <input type="text" id="midstart" name="midstart" value="<%=Model.MidStart.ToString("yyyy-MM-dd") %>"  onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--    <div class="control-group">
    <label class="control-label" for="midend">中期结束时间</label>
    <div class="controls">
      <input type="text" id="midend" name="midend" value="<%=Model.MidEnd.ToString("yyyy-MM-dd") %>"  onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--      <div class="control-group">
    <label class="control-label" for="overstart">后期开始时间</label>
    <div class="controls">
      <input type="text" id="overstart" name="overstart" value="<%=Model.OverStart.ToString("yyyy-MM-dd") %>" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
<%--      <div class="control-group">
    <label class="control-label" for="overend">后期结束时间</label>
    <div class="controls">
      <input type="text" id="overend" name="overend" value="<%=Model.OverEnd.ToString("yyyy-MM-dd") %>" onclick="calendar.show(this);"/>
    </div>
  </div>--%>
    <div class="form-actions">
      <button id="activitysubmit" type="submit" class="btn btn-primary">更新</button>
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
