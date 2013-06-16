
var eventUtil = new EventUtil();
var verify = new Verify();
var flag_userNo = false,
      flag_userPassword = false;

var userNo = document.getElementById("userID");
var userNoErr = document.getElementById("userIDErr");
check_userNo(userNo, userNoErr,10,10);

var userPassword = document.getElementById("pwd");
var userPasswordErr = document.getElementById("pwdErr");
check_password(userPassword, userPasswordErr,16,8);

var btnSubmit = document.getElementById("submit");
eventUtil.addHandler(btnSubmit, "click", function (event) {
    if (!verify.checkNull(userNo, userNoErr) || !flag_userNo ||
    !verify.checkNull(userPassword, userPasswordErr) || !flag_userPassword 
    ) {
        var e = eventUtil.getEvent(event);
        eventUtil.preventDefault(e)
    }
});

//////////////////////////////////////////////////////////////////////////
///userNo
function check_userNo(elelment, elelmentErr, maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userNo = verify.checkDigit(elelment, elelmentErr) && verify.checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

//userPassword
function check_password(elelment, elelmentErr,maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userPassword = verify.checkDigitAbc(elelment, elelmentErr) && verify.checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

