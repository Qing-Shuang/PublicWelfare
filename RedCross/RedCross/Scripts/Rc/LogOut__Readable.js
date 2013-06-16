/* File Created: 十月 7, 2012 */

var aElm = document.getElementById("logout");
var name = document.getElementById("name");
var domain = document.getElementById("Domain");
var path = document.getElementById("Path");
var expires = document.getElementById("Expires");
var secure = document.getElementById("Secure");

var eventUtil = new EventUtil();
var cookieUtil = new CookieUtil();
var afunc = function () {
    var e = eventUtil.getEvent(event);
    eventUtil.preventDefault(e);
    cookieUtil.unset('ACY0', " ", expires.innerHTML, path.innerHTML, domain.innerHTML, secure.innerHTML);
    cookieUtil.unset('SRI', " ", expires.innerHTML, path.innerHTML, domain.innerHTML, secure.innerHTML);
    cookieUtil.unset('UAE', " ", expires.innerHTML, path.innerHTML, domain.innerHTML, secure.innerHTML);
    cookieUtil.unset('BDG', " ", expires.innerHTML, path.innerHTML, domain.innerHTML, secure.innerHTML);
    cookieUtil.unset('DPM', " ", expires.innerHTML, path.innerHTML, domain.innerHTML, secure.innerHTML);

    //    for (var i = 0; i < 5; ++i) {
    //        cookieUtil.unset('ACY',"",expires.nodeValue,path.nodeValue,domain.nodeValue,secure.nodeValue);
    //        cookieUtil.unset('SRI');
    //        cookieUtil.unset('UAE');
    //        cookieUtil.unset('BDG');
    //        cookieUtil.unset('DPM');
    //    }

    var url = document.getElementById("otherIndex").childNodes[0].href;
    console.log(url);
    location.href = url;
}

eventUtil.addHandler(aElm,"click",afunc);
