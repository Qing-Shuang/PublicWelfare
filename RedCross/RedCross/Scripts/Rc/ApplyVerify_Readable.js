var userId = document.getElementById("userid");
var userIdErr = document.getElementById("useridErr");
var userName = document.getElementById("username");
var userNameErr = document.getElementById("usernameErr");
var telenumber = document.getElementById("telenumber");
var telenumberErr = document.getElementById("telenumberErr");
var applySubmit = document.getElementById("applysubmit");

var v = new Verify();
var els = new ElementSet();

eventUtil.addHandler(applySubmit, "click", function (event) {
    var e = eventUtil.getEvent(event);
    v.value = userId.value;
    v.length = 10;
    var flag = v.run([
        ["checkNull", "请填写学号"],
        ["checkDigit", "学号应该为数字"],
        ["checkLength", "学号的长度应该为10个字符"]
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

    v.value = telenumber.value;
    flag = v.checkNull();
    els.SetElm(telenumber, telenumberErr, "请填写号码", flag);
    if (flag) {
        flag = v.checkPhone() || v.checkShortPhone();
        els.SetElm(telenumber, telenumberErr, "无效号码", flag);
        if (!flag) {
            eventUtil.preventDefault(e);
            return;
        }
    }
    else {
        eventUtil.preventDefault(e);
        return;
    }

});
