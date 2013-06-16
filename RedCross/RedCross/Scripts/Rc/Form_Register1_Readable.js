/* File Created: 三月 17, 2012 */
var eventUtil = new EventUtil();
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
check_password(userPassword, userPasswordErr);

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
    if (!checkNull(userNo, userNoErr) || !flag_userNo ||
    !checkNull(userName, userNameErr) || !flag_userName ||
    !checkNull(userPassword, userPasswordErr) || !flag_userPassword ||
    !checkNull(userPasswordRepeat, userPasswordRepeatErr) || !flag_userPassword || 
    !checkNull(grdID, grdIDErr) ||
    !checkNull(collageID, collageIDErr) ||
    !checkNull(depID, depIDErr) ||
    !checkNull(roleID,roleIDErr) ||
    !checkNull(phone, phoneErr) || !flag_phone ||
    !checkNull(short_phone, short_phoneErr) || !flag_short_phone
    ) {
        var e = eventUtil.getEvent(event);
        eventUtil.preventDefault(e)
    }
});

//////////////////////////////////////////////////////////////////////////
///非空检查
function checkNull(elelment, elelmentErr) {
    var flag = false;
    if (elelment.value == "") {
        elelment.className = "ErrInput";
        elelmentErr.innerText = "* 不能为空";
        elelmentErr.style.display = "";
        flag = false;
    }
    else {
        elelment.className = "NomalInput"
        elelmentErr.innerText = "";
        elelmentErr.style.display = "none";
        flag = true;
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///只能是数字
function checkDigit(elelment, elelmentErr) {
    var flag = false;
    var digit = /[^0-9]+/;                  //匹配不在指定范围内的任意字符
    if (elelment.value != "") {
        if (digit.test(elelment.value)) {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 只能为数字";
            elelmentErr.style.display = "";
            flag = false;
        }
        else {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
    }
    return flag;
}

///只能是数字和字母
function checkDigitAbc(elelment, elelmentErr) {
    var flag = false;
    var digit = /[^0-9A-Za-z]+/;                  //匹配不在指定范围内的任意字符
    if (elelment.value != "") {
        if (digit.test(elelment.value)) {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 只能为数字和字母";
            elelmentErr.style.display = "";
            flag = false;
        }
        else {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///检验长度
function checkLength(elelment, elelmentErr,maxLen,minLen) {
    var flag = false;
    if (elelment.value != "") {
        if (elelment.value.length > maxLen || elelment.value.length < minLen) {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 长度应该在" + minLen + "-" + maxLen + "之间";
            elelmentErr.style.display = "";
            flag = false;
        }
        else {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///电话号码检查
function checkPhone(elelment, elelmentErr) {
    var flag = false,
           reg0 = /13\d{5,9}/,                      //130--139。至少7位
           reg1 = /153\d{4,8}/,                   //联通153。至少7位
           reg2 = /159\d{4,8}/,                   //移动159。至少7位
           reg3 = /158\d{4,8}/,
           reg4 = /150\d{4,8}/;

    if (elelment.value != "") {
        if (reg0.test(elelment.value) || reg1.test(elelment.value) || reg2.test(elelment.value) ||
         reg3.test(elelment.value) || reg4.test(elelment.value)) {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
        else {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 无效的电话号码";
            elelmentErr.style.display = "";
            flag = false;
        }
    }
    return flag;
}

//短号检查
function checkShortPhone(elelment, elelmentErr) {
    var flag = false;
    var reg = /6\d{5}/;
    if (elelment.value != "") {
        if (reg.test(elelment.value)) {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
        else {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 无效的短号";
            elelmentErr.style.display = "";
            flag = false;
        }
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///密码重复性检测
function checkRepeat(pwd, pwd_R, pwd_R_Err) {
    var flag = false;
    if (pwd.value != "" && pwd_R.value != "") {
        if (pwd.value != pwd_R.value) {
            pwd_R.className = "ErrInput";
            pwd_R_Err.innerText = "* 重复输入的密码和原先的不一致";
            pwd_R_Err.style.display = "";
            flag = false;
        }
        else {
            pwd_R.className = "NomalInput";
            pwd_R_Err.innerText = "";
            pwd_R_Err.style.display = "none";
            flag = true;
        }
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///只能是汉字
function checkChinese(elelment, elelmentErr) {
    var flag = false;
    var reg = /[^\u4E00-\u9FA5]/;
    if (elelment.value != "") {
        if (reg.test(elelment.value)) {
            elelment.className = "ErrInput";
            elelmentErr.innerText = "* 只能输入汉字";
            elelmentErr.style.display = "";
            flag = false;
        }
        else {
            elelment.className = "NomalInput"
            elelmentErr.innerText = "";
            elelmentErr.style.display = "none";
            flag = true;
        }
    }
    return flag;
}
//////////////////////////////////////////////////////////////////////////
///userNo
function check_userNo(elelment, elelmentErr, maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userNo = checkDigit(elelment, elelmentErr) && checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

//userName
function check_userName(elelment, elelmentErr, maxLen, minLen) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userName = checkChinese(elelment, elelmentErr) && checkLength(elelment, elelmentErr, maxLen, minLen);
    });
}

//userPassword
function check_password(elelment, elelmentErr) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_userPassword = checkDigitAbc(elelment, elelmentErr) && checkLength(elelment, elelmentErr, 16, 8);
    });
}

///userPasswordRepeat
function check_password_repeat(elelment, elelment_R, elelment_RErr) {
    eventUtil.addHandler(elelment_R, "blur", function () {
        flag_userPassword = checkRepeat(elelment, elelment_R, elelment_RErr);
    });
}

///phone
function check_phone(elelment, elelmentErr) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_phone = checkPhone(elelment, elelmentErr);
    });
}

//short_phone
function check_short_phone(elelment, elelmentErr) {
    eventUtil.addHandler(elelment, "blur", function () {
        flag_short_phone = checkShortPhone(elelment, elelmentErr);
    });
}

