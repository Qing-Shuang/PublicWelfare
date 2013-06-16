/* File Created: 十二月 4, 2011 */

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
}

var labels = document.getElementsByTagName("label");

//alert("labels.length: " + labels.length);
for (var j = 0; j < labels.length; ++j) {
    var label_children = labels[j].innerHTML.split("|"); //取出label的各个字段，即姓名电话等，比如1*1*2*4*5 | 魏嘉鹏 | 13750057567
    var label_children_id_location = label_children[0].trim().split("*"); //取出id×节×星期，比如1*1*2*4*5 
    for (var i = 2; i < label_children_id_location.length; ++i) {
        var tableElement_location = label_children_id_location[1] + label_children_id_location[i]; //设置该元素在table的位置，如 12
        //alert(tableElement_location);
        var tableElement = document.getElementById(tableElement_location);
        //alert("i: " + i + " <p>" + label_children[1] + label_children[2] + "</p>");
        //alert(tableElement);
        var a = label_children_id_location[0] + tableElement_location + "a"; //设置链接的id，如112a
        var tel = label_children_id_location[0] + tableElement_location + "tel"; //设置tel的id，如112tel
        //比如 <a id="112a" href="/">魏嘉鹏</a><div id="112tel" style="display:none;">13750057567</div>
//        tableElement.innerHTML += "<a id='" + a + "' href='#' name='" + (Number(label_children_id_location[0]) + 10000) + "'>" + label_children[1] +
//        "</a><div id='" + tel + "' style='display:none'>" + label_children[2] + "</div>";

        tableElement.innerHTML += "<a id='" + a + "' href='#' name='" + (Number(label_children_id_location[0]) + 10000) + "'>" 
        + label_children[1] +"</a>";

        //#region If do like this,It get the result of cover

        //        var a_element = document.getElementById(a);
        //        var tel_element = document.getElementById(tel);
        //        tel_element.style.display = "none";
        //        var eventUtil = new EventUtil();
        //        var func = function (elm) {
        //            return function () {
        //                var e = eventUtil.getEvent(event);
        //                eventUtil.preventDefault(e);
        //                alert(elm.value);
        //                if (elm.style.display) {
        //                    //alert(elm.style.display == "none");
        //                    elm.style.display = "";
        //                    //alert("no");
        //                }
        //                else {
        //                    //alert(elm.style.display == "none");
        //                    elm.style.display = "none";
        //                    //alert("display");
        //                }
        //            };
        //        } (tel_element);
        //        eventUtil.addHandler(a_element, "click", func);  //end eventUtil

        //#endregion

    } //end for
} //end for

var main = document.getElementById("Result");
var a_elms = main.getElementsByTagName("a");
var eventUtil = new EventUtil();

/*
var div_elms = main.getElementsByTagName("div");
for(var i = 0;i<a_elms.length;++i) {
    var func = function (elm) {
        return function () {
            var e = eventUtil.getEvent(event);
            eventUtil.preventDefault(e);
            if (elm.style.display) {
                elm.style.display = "";
            }
            else {
                elm.style.display = "none";
            }
        };
    } (div_elms[i]);
    eventUtil.addHandler(a_elms[i], "click", func);
}
*/

var userDiv = document.getElementById("userInfo");
var div_elms = userDiv.getElementsByTagName("div");

 for (var i = 0; i < a_elms.length; ++i) {
     var func = function (elm) {
         return function () {
             var e = eventUtil.getEvent(event);
             eventUtil.preventDefault(e);

             //隐藏所有用户信息
             for (var k = 0; k < div_elms.length; ++k) {
                 div_elms[k].style.display = "none";
             }

             var name = elm.attributes["name"].value;
             //alert(name);
             var userInfo = document.getElementById(name);
             if (userInfo.style.display) {
                 userInfo.style.display = "";
             }
             else {
                 userInfo.style.display = "none";
             }
         };
     } (a_elms[i]);
    eventUtil.addHandler(a_elms[i], "click", func);
}

