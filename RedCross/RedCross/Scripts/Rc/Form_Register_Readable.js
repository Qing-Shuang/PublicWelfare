/* File Created: 三月 17, 2012 */
var eventUtil = new EventUtil();
var verify = new Verify();
var flag_userNo = false,
      flag_userName = false,
      flag_userPassword = false,
      flag_phone = false,
      flag_short_phone = false;

var userNo = document.getElementById("userNo");
var userNoErr = document.getElementById("userNoErr");
check_userNo(userNo, userNoErr,10,10);

var userName = document.getElementById("userName");
var userNameErr = document.getElementById("userNameErr");
check_userName(userName, userNameErr, 4, 2);

var userPassword = document.getElementById("userPassword");
var userPasswordErr = document.getElementById("userPasswordErr");
check_password(userPassword, userPasswordErr,16,8);

var userPasswordRepeat = document.getElementById("userPasswordRepeat");
var userPasswordRepeatErr = document.getElementById("userPasswordRepeatErr");
check_password_repeat(userPassword,userPasswordRepeat, userPasswordRepeatErr);

var grdID = document.getElementById("grdID");
var grdIDErr = document.getElementById("grdIDErr");

var collageID = document.getElementById("collageID");
var collageIDErr = document.getElementById("collageIDErr");

var depID = document.getElementById("depID");
var depIDErr = document.getElementById("depIDErr");

var roleID = document.getElementById("roleID");
var roleIDErr = document.getElementById("roleIDErr");

var phone = document.getElementById("phone");
var phoneErr = document.getElementById("phoneErr");
check_phone(phone, phoneErr);

var short_phone = document.getElementById("phone_short");
var short_phoneErr = document.getElementById("phone_shortErr");
check_short_phone(short_phone, short_phoneErr);

var btnSubmit = document.getElementById("submit");
eventUtil.addHandler(btnSubmit, "click", function (event) {
    if (!verify.checkNull(userNo, userNoErr) || !flag_userNo ||
    !verify.checkNull(userName, userNameErr) || !flag_userName ||
    !verify.checkNull(userPassword, userPasswordErr) || !flag_userPassword ||
    !verify.checkNull(userPasswordRepeat, userPasswordRepeatErr) || !flag_userPassword || 
    !verify.checkNull(grdID, grdIDErr) ||
    !verify.checkNull(collageID, collageIDErr) ||
    !verify.checkNull(depID, depIDErr) ||
    !verify.checkNull(roleID,roleIDErr) ||
    !verify.checkNull(phone, phoneErr) || !flag_phone ||
    !verify.checkNull(short_phone, short_phoneErr) || !flag_short_phone
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

//userName
function check_userName(elelment, elelmentErr, maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userName = verify.checkChinese(elelment, elelmentErr) && verify.checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

//userPassword
function check_password(elelment, elelmentErr,maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userPassword = verify.checkDigitAbc(elelment, elelmentErr) && verify.checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

///userPasswordRepeat
function check_password_repeat(elelment, elelment_R, elelment_RErr) {
    eventUtil.addHandler(elelment_R, "blur", function () {
        flag_userPassword = verify.checkRepeat(elelment, elelment_R, elelment_RErr);
    });
}

///phone
function check_phone(elelment, elelmentErr) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_phone = verify.checkPhone(elelment, elelmentErr);
    });
}

//short_phone
function check_short_phone(elelment, elelmentErr) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_short_phone = verify.checkShortPhone(elelment, elelmentErr);
    });
}

