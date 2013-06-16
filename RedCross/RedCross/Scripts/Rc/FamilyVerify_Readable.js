/* File Created: 十二月 19, 2012 */

var userId = document.getElementById("userid");
var userIdErr = document.getElementById("useridErr");
var userName = document.getElementById("username");
var userNameErr = document.getElementById("usernameErr");
var grdId = document.getElementById("grdID");
var grdIdErr = document.getElementById("grdIDErr");
var clgId = document.getElementById("clgId");
var clgIdErr = document.getElementById("clgIdErr");
var depId = document.getElementById("depID");
var depIdErr = document.getElementById("depIDErr");
var wish = document.getElementById("wish");
var wishErr = document.getElementById("wishErr");
var familySubmit = document.getElementById("familysubmit");

var v = new Verify();
var els = new ElementSet();

eventUtil.addHandler(familySubmit, "click", function (event) {
    var e = eventUtil.getEvent(event);

    v.value = userId.value;
    v.length = 10;
    var flag = v.run([
        ["checkNull", "请填写学号"],
        ["checkDigit", "学号应该为数字"],
        ["checkLength", "学号的长度应该为10"]
    ]);
    els.SetElm(userId, userIdErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = userName.value;
    v.maxLength = 4;
    v.minLength = 2;
    flag = v.run([
        ["checkNull", "请填写姓名"],    
        ["checkChinese", "姓名应该是中文"],
        ["checkRangeLength", "姓名的长度应该在2～4个字符之间"]
    ]);
    els.SetElm(userName, userNameErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = grdId.value;
    flag = v.checkNull();
    els.SetElm(grdId, grdIdErr, "请选择年级", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = clgId.value;
    flag = v.checkNull();
    els.SetElm(clgId, clgIdErr, "请选择学院", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = depId.value;
    flag = v.checkNull();
    els.SetElm(depId, depIdErr, "请选择部门", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = wish.value;
    v.maxLength = 500;
    v.minLength = 0;
    flag = v.checkRangeLength();
    els.SetElm(wish, wishErr, "祝福留言的长度应该在0～500个字符之间", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }
});
