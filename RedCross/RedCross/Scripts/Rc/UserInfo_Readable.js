/* File Created: 十一月 27, 2011 */

//var cookies = new CookieUtil();
var elm = document.getElementById("hello");
//var tabwrapper = document.getElementById("tabwrapper");
var d = new Date();
var h = d.getHours();
var regard = null;
if (h >= 3 && h < 11) {
    elm.innerText = "早上好";
    regard = ",努力学习,日积月累. ^_^";
} else if (h>=11 && h < 15) {
    elm.innerText = "中午好";
    regard = ",饭后可以小休一下. ^_^";
} else if (h>=15 && h < 19) {
    elm.innerText = "下午好";
    regard = ",努力学习,日积月累. ^_^";
} else if (h >= 19 || h < 3) {
    elm.innerText = "晚上好";
    regard = ",劳累一天,记得休息. ^_^";
}
//if (cookies.get("SRI") != null) {
//    elm.innerText += "," + cookies.get("SRI") + " " + cookies.get("UAE");

//    var link_person = document.getElementById("personLink");
//    link_person.innerText = " | 个人中心 |";
//    link_person.href = "/User/PersonalHome";

//    var link_change = document.getElementById("changePerson");
//    link_change.innerText = " 切换用户 |";
//    link_change.href = "/User/Login";

//    tabwrapper.innerText = "";
////    var la = document.createElement("a");
////    tabwrapper.appendChild(la);
//}

elm.innerText += regard;

//function getCookie(name) {

//    for (var b = [], d = document.cookie.split(/; */), c = 0; c < d.length; c++) {
//        var e = d[c].split("=");
//        e[0] == name && b.push(decodeURIComponent(e[1]));
//    }
//    return b[0];
//}

/*
ACY ## activity
SRI ## userId
UAE ## userName
BDG ## id ## baseDistinguish
DPM ## depid
*/