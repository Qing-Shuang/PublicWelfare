<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Container.Container_TimeTables_UserBases>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>红会-更新课表</title>
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Base_2.css") %>" />
        <link rel="stylesheet" type="text/css" href="<%=Url.Content("~/Content/Style_Table.css") %>" />
        <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
</head>
<body>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/TimeTable.js") %>"></script>
 <%Html.RenderPartial("Navbar", "Index"); %>
    <div class="container-fluid">
    <div class="row-fluid">
    <div class="span2">
      <%Html.RenderPartial("NavStack", "Update"); %>
    </div>
    <div class="span9">
    <div class="page-header">
    <h1 class="page-header-title">修改课程表</h1>
    </div>

     <%if(Model != null)
     { %>
     <div id="main_content_table">
     <%if (Model.list_u != null)
      { %>
     <%--<div class="subTitile"><label>选择学号或者姓名</label></div>--%>
    <div class="row-fluid">
    <div class="page-header span6">
    <h3>选择学号或者姓名</h3>
    </div>
    </div>
    <div class="row-fluid">
    <form class="form-horizontal" id="userInfoForTimeTable" name="userInfoForTimeTable" action="<%=Url.Content("~/TimeTable/GetUserTimeTable") %>" method="get">

    <div class="control-group">
    <label class="control-label" for="xuehao">学号</label>
    <div class="controls">
    <select id="xuehao" name="xuehao">
    <option></option>
        <%for (int i = 0; i < Model.list_u.Count; ++i)
          {%>
          <option value="<%=Model.list_u[i].ID %>" <%if(Model.ub != null && Model.ub.UserID == Model.list_u[i].UserID) {%> selected="selected"<%} %>>
          <%=Model.list_u[i].UserID%></option>
        <%} %>
    </select>
    <div id="xuehaoErr" style="display:none" class="Err"></div>
    </div>
    </div>

     <div class="control-group">
    <label class="control-label" for="xinming">姓名</label>
    <div class="controls">
    <select id="xinming" name="xinming">
    <option></option>
        <%for (int i = 0; i < Model.list_u.Count; ++i)
          {%>
          <option value="<%=Model.list_u[i].ID %>" <%if(Model.ub != null && Model.ub.UserName == Model.list_u[i].UserName) {%> selected="selected"<%} %>>
          <%=Model.list_u[i].UserName%></option>
        <%} %>
    </select>
    </div>
    <div id="xinmingErr" style="display:none" class="Err"></div>
    </div>

     <div class="control-group">
    <label class="control-label"></label>
    <div class="controls">
      <button type="submit" class="btn btn-primary" name="btnSearch">查询课表</button>
    </div>
  </div>

    </form>
    </div>
    <%} %>


    <%if (Model.list_t != null && Model.list_t.Count > 0)
      { %>
     <%--<div class="subTitile"><label><%= Model.ub.UserID + "," + Model.ub.UserName + "的课表"%></label></div>--%>
     <div class="row-fluid">
    <div class="page-header span6">
    <h3><%= Model.ub.UserID + "," + Model.ub.UserName + "的课表"%></h3>
    </div>
    </div>
    <div class="row-fluid">
    <form action="<%=Url.Content("~/TimeTable/Updating") %>" method="post">
         <table class="timeTable">
          <%--<tr class="header">--%>
          <tr>
    		<%--<td class="firstcell"></td>--%>
            <td></td>
            <td>周一 <input type="checkbox" name="cell0" onclick="checkColumn(this,0)" /></td>
            <td>周二 <input type="checkbox" name="cell1" onclick="checkColumn(this,1)" /></td>
            <td>周三 <input type="checkbox" name="cell2" onclick="checkColumn(this,2)" /></td>
            <td>周四 <input type="checkbox" name="cell3" onclick="checkColumn(this,3)" /></td>
            <td>周五 <input type="checkbox" name="cell4" onclick="checkColumn(this,4)" /></td>
            <td>周六 <input type="checkbox" name="cell5" onclick="checkColumn(this,5)" /></td>
            <td>周日 <input type="checkbox" name="cell6" onclick="checkColumn(this,6)" /></td>
    	</tr>
        <%for (int i = 0; i < Model.list_t.Count; ++i)
          { %>
          <tr>
        <td>第<%=Model.list_t[i].Section%>节 
        <input type="checkbox" name="row<%=i %>" onclick="checkRow(this,<%=i %>)" /></td>
        <td id="t<%=i %>d0" <%if (Model.list_t[i].FirstDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell0" <%if (Model.list_t[i].FirstDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d0')"/>
        </td>
        <td id="t<%=i %>d1" <%if (Model.list_t[i].SecondDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell1" <%if (Model.list_t[i].SecondDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d1')"/>
        </td>
        <td id="t<%=i %>d2" <%if (Model.list_t[i].ThirdDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell2" <%if (Model.list_t[i].ThirdDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d2')"/>
        </td>
        <td id="t<%=i %>d3" <%if (Model.list_t[i].FourthDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell3" <%if (Model.list_t[i].FourthDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d3')"/>
        </td>
        <td id="t<%=i %>d4" <%if (Model.list_t[i].FifthDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell4" <%if (Model.list_t[i].FifthDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d4')"/>
        </td>
        <td id="t<%=i %>d5" <%if (Model.list_t[i].SixthDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell5" <%if (Model.list_t[i].SixthDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d5')"/>
        </td>
        <td id="t<%=i %>d6" <%if (Model.list_t[i].SeventhDay == '1'){ %>class="blue"<%} %>>
                <input type="checkbox" name="row<%=i %>cell6" <%if (Model.list_t[i].SeventhDay == '1'){ %>checked="true"<%} %>
                onchange="checkCell(this,'t<%=i %>d6')"/>
        </td>
         </tr>
        <%} %>
    </table><br />  
     <div>
      <button type="submit" class="btn btn-primary">保存</button>
      <button type="button" class="btn" onclick="history.back()">取消</button>
    </div>
    </form>
    </div>
    <%}
      else
      {
          if (Model.ub != null)
          {%>
    <div class="alert alert-block alert-info">
    暂没有<strong><%= Model.ub.UserID + "," + Model.ub.UserName%></strong>的课表信息哦！
    </div>
      <%}
      }%>
      </div>
<%} %>

</div>
</div>
</div>

<%Html.RenderPartial("Bottom"); %>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/Verify.js") %>"></script>
<script type="text/javascript" src="<%=Url.Content("~/Scripts/Rc/SyncOption.js") %>"></script>
</body>
</html>
