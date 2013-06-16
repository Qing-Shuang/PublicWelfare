<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<RedCross.Models.Entities.Base.MessageModel>" %>
<%@ import Namespace="RedCross" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>
 <%=Model.titile%>
 </title>
<%--    <link rel="stylesheet" type="text/css" href="/Content/Style_Base.css" />--%>
    <link href="<%=Url.Content("~/Content/bootstrap.min.css") %>" rel="stylesheet"/>
    <%--<link rel="stylesheet" type="text/css" href="/Content/Style_Bottom.css" />--%>
</head>
<body>
 <%Html.RenderPartial("Navbar", "Other"); %>
<%--<%Html.RenderPartial("Select_HasInfo"); %>--%>
    <div <%if (Request.Cookies[GLB.userId] == null){%>class="container"<%}else{ %>class="container-fluid"<%} %>>
    <div <%if (Request.Cookies[GLB.userId] == null){%>class="row"<%}else{ %>class="row-fluid"<%} %>>
    <%if (Request.Cookies[GLB.userId] == null){}else{ %>    
    <div class="span2">
      <%Html.RenderPartial("NavStack"); %>
    </div><%} %>
    <div <%if (Request.Cookies[GLB.userId] == null){}else{ %>class="span9"<%} %>>
    <center><img src="<%=Url.Content("~" + Model.pictrueUrl ) %>" alt=""/></center>

    <div class="row">
    <center>
    <div class="<%=Model.css %>">
    <h3 ><%=Model.content %></h3>
    </div>
    </center>
    </div>

    <div class="row">
    <center>
    <button type="button" class="btn btn-primary btn-large" onclick="<%=Model.onClickCode %>"><%=Model.buttonName %></button>
    </center>
    </div>

    </div> 

    </div>
    </div>
    <%Html.RenderPartial("Bottom"); %>
</body>
</html>
