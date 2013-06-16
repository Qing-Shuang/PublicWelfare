var depname = document.getElementById("depname");
var depnameErr = document.getElementById("depnameErr");
var introduce = document.getElementById("introduce");
var introduceErr = document.getElementById("introduceErr");
var depSubmit = document.getElementById("depsubmit");

var v = new Verify();
var els = new ElementSet();

eventUtil.addHandler(depSubmit, "click", function (event) {
    var e = eventUtil.getEvent(event);

    v.value = depname.value;
    v.maxLength = 50;
    v.minLength = 0;
    var flag = v.run([
        ["checkNull", "请填写名称"],
        ["checkRangeLength", "名称的长度应该在0～50个字符之间"]
    ]);
    els.SetElm(depname, depnameErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = introduce.value;
    v.maxLength = 1000;
    v.minLength = 0;
    flag = v.run([
        ["checkNull", "请填写介绍"],
        ["checkRangeLength", "介绍的长度应该在0～1000个字符之间"]
    ]);
    els.SetElm(introduce, introduceErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }
});
