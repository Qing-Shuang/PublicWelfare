<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_List_Status>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-课表查询</title>
<%--        <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
</head>
<body>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Search"); %>
    </div>
    <div class="span9">
    <form class="form-horizontal" action="<%=Url.Content("~/TimeTable/SearchResult") %>" method="post">
     <div class="page-header">
    <h1 class="page-header-title">查找无课时间表</h1>
    </div>
     <div class="control-group">
    <label class="control-label" for="weekStart">开始星期</label>
    <div class="controls">
    <select id="weekStart" name="weekStart" >
    <option></option>
    <%for (int i = 1; i < 8; ++i)
      { %><option value="<%=i %>">星期<%=i%></option><%} %>
    </select>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="weekEnd">结束星期</label>
    <div class="controls">
    <select id="weekEnd" name="weekEnd" >
    <option></option>
        <%for (int i = 1; i < 8; ++i)
          { %><option value="<%=i %>">星期<%=i%></option>
        <%} %>
    </select>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="sectionStart">开始课节</label>
    <div class="controls">
    <select id="sectionStart" name="sectionStart" >
    <option></option>
    <%for (int i = 1; i < 14; )
      {
          if (i == 9)
          {
              %><option value="<%=i %>">第<%=i%>节</option><%
              i += 1;
          }
          else
          {
              %><option value="<%=i %>">第<%=i%>节--第<%=i + 1%>节</option><%
              i+=2;
          }
      }
      %>
    </select>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="sectionEnd">结束课节</label>
    <div class="controls">
    <select id="sectionEnd" name="sectionEnd" >
    <option></option>
        <%for (int i = 1; i < 14; )
      {
          if (i == 9)
          {
              %><option value="<%=i %>">第<%=i%>节</option><%
              i += 1;
          }
          else
          {
              %><option value="<%=i + 1 %>">第<%=i%>节--第<%=i + 1%>节</option><%
              i+=2;
          }
      }
      %>
    </select>
    </div>
    </div>

    <div class="control-group">
    <label class="control-label" for="grdID">年级</label>
    <div class="controls">
    <select id="grdID" name="grdID" >
    <option></option>
    <%for (int i = 0; i < Model.list_Grd.Count; ++i)
      { %>
      <option value="<%=Model.list_Grd[i].ID %>">
      <%=Model.list_Grd[i].Name%>
      </option>
      <%} %>
    </select>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="collageID">学院</label>
    <div class="controls">
    <select id="collageID" name="collageID" >
    <option></option>
        <%for (int i = 0; i < Model.list_Col.Count; ++i)
          { %>
        <option value="<%=Model.list_Col[i].ID %>">
            <%=Model.list_Col[i].Name%>
        </option>
        <%} %>
    </select>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="depID">部门</label>
    <div class="controls">
    <select id="depID" name="depID" >
    <option></option>
        <%for (int i = 0; i < Model.list_Dep.Count; ++i)
          { %>
        <option value="<%=Model.list_Dep[i].ID %>">
            <%=Model.list_Dep[i].Name%>
        </option>
        <%} %>
    </select>
    </div>
    </div>
    <div class="form-actions">
      <button type="submit" class="btn btn-primary btn-large span2">查询</button>
    </div>
   </form>
   </div>
   </div>
   </div>
    
<%Html.RenderPartial("Bottom"); %>
</body>
</html>
