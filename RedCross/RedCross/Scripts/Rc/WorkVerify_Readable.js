var form = document.forms["work"];
var idSelcet = form.userId;
var nameSelect = form.userName;
var content = form.content;
var startDate = form.startdate;
var cutOffDate = form.cutoffdate;
var idErr = document.getElementById("userIdErr");
var nameErr = document.getElementById("userNameErr");
var contentErr = document.getElementById("contentErr");
var startDateErr = document.getElementById("startdateErr");
var cutOffDateErr = document.getElementById("cutoffdateErr");
var worSubmit = document.getElementById("worksubmit");

var idfunc = function () {
    if (idSelcet.selectedIndex != nameSelect.selectedIndex) {
        nameSelect.selectedIndex = idSelcet.selectedIndex;
    }
}

var namefunc = function () {
    if (idSelcet.selectedIndex != nameSelect.selectedIndex) {
        idSelcet.selectedIndex = nameSelect.selectedIndex;
    }
}

eventUtil.addHandler(idSelcet, "change", idfunc);
eventUtil.addHandler(nameSelect, "change", namefunc);

var v = new Verify();
var els = new ElementSet();

eventUtil.addHandler(worSubmit, "click", function (event) {
    var e = eventUtil.getEvent(event);
    v.value = userId.value;
    var flag = v.checkNull();
    els.SetElm(userId, userIdErr, "请选择学号", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = userName.value;
    flag = v.checkNull();
    els.SetElm(userName, userNameErr, "请选择姓名", flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = content.value;
    v.maxLength = 500;
    v.minLength = 0;
    flag = v.run([
        ["checkNull", "请填写内容"],
        ["checkRangeLength", "内容的长度应该在0～500个字符之间"]
    ]);
    els.SetElm(content, contentErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = startDate.value;
    flag = v.run([
        ["checkNull", "请填写开始时间"],
        ["checkDateTime", "时间格式不正确，参照格式:2013-01-14"]
    ]);
    els.SetElm(startDate, startDateErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = cutOffDate.value;
    flag = v.run([
        ["checkNull", "请填写截止时间"],
        ["checkDateTime", "时间格式不正确，参照格式:2013-01-14"]
    ]);
    els.SetElm(cutOffDate, cutOffDateErr, v.errMsg, flag);    
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    if (startDate.value >= cutOffDate.value) {
        els.SetElmErr(startDate, startDateErr, "起始时间不能大于结束时间");
        eventUtil.preventDefault(e);
        return;
    }
});