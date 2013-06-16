function Verify() {
}

Verify.prototype = {
    constructor: Verify,

    ///非空检查
    checkNull: function (elelment, elelmentErr) {
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
    },

    ///只能是数字
    checkDigit: function (elelment, elelmentErr) {
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
    },

    ///只能是数字和字母
    checkDigitAbc: function (elelment, elelmentErr) {
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
    },

    ///检验长度
    checkLength: function (elelment, elelmentErr, maxLen, minLen) {
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
    },

    ///电话号码检查
    checkPhone: function (elelment, elelmentErr) {
        var flag = false,
               reg0 = /13\d{5,9}$/,                      //130--139。至少7位
               reg1 = /153\d{4,8}$/,                   //联通153。至少7位
               reg2 = /159\d{4,8}$/,                   //移动159。至少7位
               reg3 = /158\d{4,8}$/,
               reg4 = /150\d{4,8}$/;

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
    },

    //短号检查
    checkShortPhone: function (elelment, elelmentErr) {
        var flag = false;


        var reg = /6\d{5}$/;
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
    },

    ///密码重复性检测
    checkRepeat: function (pwd, pwd_R, pwd_R_Err) {
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
    },

    //只能是汉字
    checkChinese: function (elelment, elelmentErr) {
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
};

var verify = new Verify();
var map = [
    ["checkNull", verify.checkNull],
    ["checkDigit", verify.checkDigit],
    ["checkDigitAbc",verify.checkDigitAbc],
    ["checkLength",verify.checkLength],
    ["checkPhone",verify.checkPhone],
    ["checkShortPhone",verify.checkShortPhone],
    ["checkRepeat",verify.checkRepeat],
    ["checkChinese",verify.checkChinese]
];

function intersection(m_rules) {
    if (m_rules.length > map.length) return;    //destory,out!
    var map_copy = new Array();      //let's game!!!
    for (var n = 0; n < map.length; ++n) {
        map_copy[n] = map[n].concat();
    }
    var i=0,j=0,
          z=m_rules.length,
          flag = false;
    for(;i<m_rules.length;){
        for (j = i; j < map_copy.length; ++j) {
            if (map_copy[j][0] == m_rules[i]) {
                map_copy[i] = map_copy[j];
                flag = true;
                break;
            }
        }
        if (!flag) {
            if(i == z) break;
            m_rules[i] = m_rules[z];
            z--;
        } else {
            ++i;
        }
    }
    if (i == 0) return;  //you lose~
    var achieve = map_copy.slice(0, i);
    return achieve;    //you get a nice achievement !!!
}