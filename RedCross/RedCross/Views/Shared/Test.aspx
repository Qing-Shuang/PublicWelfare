<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8"/>
    <title>Test Cookie</title>
</head>
<body>
<%--<input type="button" id="Test" value="Click"/>--%>
<input type="button" value="Click1"/>
<div style="display:none">Click1</div>
<input type="button" value="Click2"/>
<div style="display:none">Click2</div>
   
      <script type="text/javascript" src="/Scripts/RC/EventUtil.js"></script>
   <script type="text/javascript" src="/Scripts/RC/CookieUtil.js"></script>
      <script language="javascript" type="text/javascript">

          var eventUtil = new EventUtil();
          var buttons = document.getElementsByTagName("input");
          var divs = document.getElementsByTagName("div");

          for(var i = 0;i<buttons.length;++i) {

              var func = function (elm) {
                  return function () {
                      if (elm.style.display) {
                          elm.style.display = "";
                      }
                      else {
                          elm.style.display = "none";
                      }
                      //alert(elm.innerText);
                  }
              } (divs[i]);
              eventUtil.addHandler(buttons[i], "click", func);
          }

          var nm = 1;
          alert(nm);
          var nm = 2;
          alert(nm);
      </script>
      <%=Response.Cookies["wei"].Value %>
</body>
</html>
