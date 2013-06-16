var content = document.getElementById("content");
var contentErr = document.getElementById("contentErr");
var publish = document.getElementById("publish");
var publishErr = document.getElementById("publishErr");
var noticeSubmit = document.getElementById("noticesubmit");

var v = new Verify();
var els = new ElementSet();

eventUtil.addHandler(noticeSubmit, "click", function (event) {
    var e = eventUtil.getEvent(event);
 
    v.value = content.value;
    v.maxLength = 1000;
    v.minLength = 0;
    var flag = v.run([
        ["checkNull", "请填写内容"],
        ["checkRangeLength", "内容的长度应该在0～1000个字符之间"]
    ]);
    els.SetElm(content, contentErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }

    v.value = publish.value;
    flag = v.run([
        ["checkNull", "请填写时间"],
        ["checkDateTime", "时间格式不正确，参照格式:2013-01-14"]
    ]);
    els.SetElm(publish, publishErr, v.errMsg, flag);
    if (!flag) {
        eventUtil.preventDefault(e);
        return;
    }
});
