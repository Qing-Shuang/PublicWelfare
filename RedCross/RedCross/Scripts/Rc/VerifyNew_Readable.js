function Verify() {
}

Verify.prototype = {
    constructor: Verify,
    name: "Verify",
    value: "",
    errMsg: "",
    minLength: 0,
    maxLength: 0,
    length: 0,
    digit: /[0-9]+$/,
    digitAbc: /[0-9A-Za-z]+/,
    telFirst: /13\d{5,9}/,
    telSecond: /153\d{4,8}/,
    telThird: /159\d{4,8}/,
    telFour: /158\d{4,8}/,
    telFifth: /150\d{4,8}/,
    shortTel: /6\d{5}/,
    rPwd: "",
    chinese: /[\u4E00-\u9FA5]/,
    m_datetime:/^(\d{1,4})(-)(\d{1,2})\2(\d{1,2})$/,

    ///非空检查
    checkNull: function () {
        var flag = true;
        if (this.value === "") {
            flag = false;
        }
        return flag;
    },

    ///只能是数字
    checkDigit: function () {
        return this.digit.test(this.value);
    },

    ///只能是数字和字母
    checkDigitAbc: function () {
        var flag = true;
        if (this.value) {
            if (this.digitAbc.test(this.value)) {
                flag = false;
            }
        }
        else {
            flag = false;
        }
        return flag;
    },

    ///检验长度
    checkRangeLength: function () {
        var flag = true;
        if (this.minLength !== this.maxLength) {
            if (this.value.length > this.maxLength || this.value.length < this.minLength) {
                flag = false;
            }
        }
        else {
            flag = false;
        }
        return flag;
    },

    checkLength: function () {
        var flag = true;
        if (this.value.length !== this.length) {
            flag = false;
        }
        return flag;
    },

    ///电话号码检查
    checkPhone: function () {
        return this.telFirst.test(this.value) || this.telSecond.test(this.value) || this.telThird.test(this.value) ||
		this.telFour.test(this.value) || this.telFifth.test(this.value);
    },

    //短号检查
    checkShortPhone: function () {
        return this.shortTel.test(this.value);
    },

    ///密码重复性检测
    checkRepeat: function () {
        var flag = true;
        if (this.rPwd) {
            if (this.value != this.rPwd) {
                flag = false;
            }
        }
        else {
            flag = false;
        }
        return flag;
    },

    //只能是汉字
    checkChinese: function () {
        return this.chinese.test(this.value);
    },

    checkDateTime:function () {
        var r = this.value.match(this.m_datetime); 
        if(r==null)return false; 
        var d= new Date(r[1], r[3]-1, r[4]); 
        return (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]); 
    },

    mapArray: [
             ["checkNull", console.log(this)],
             ["checkDigit", this.constructor.checkDigit],
             ["checkDigitAbc", this.checkDigitAbc],
             ["checkLength", this.checkLength],
             ["checkPhone", this.checkPhone],
             ["checkShortPhone", this.checkShortPhone],
             ["checkRepeat", this.checkRepeat],
             ["checkChinese", this.checkChinese]
    ],

    testObj: this,

    getMap: function () {
        return [
             ["checkNull", this.checkNull],
             ["checkDigit", this.checkDigit],
             ["checkDigitAbc", this.checkDigitAbc],
             ["checkLength", this.checkLength],
             ["checkPhone", this.checkPhone],
             ["checkShortPhone", this.checkShortPhone],
             ["checkRepeat", this.checkRepeat],
             ["checkChinese", this.checkChinese],
             ["checkRangeLength", this.checkRangeLength],
             ["checkDateTime", this.checkDateTime]
            ];
    },

    intersection: function (m_rules) {
        var map = this.getMap();

        if (m_rules.length > map.length) return;    //destory,out!
        var map_copy = new Array();      //let's game!!!
        for (var n = 0; n < map.length; ++n) {
            map_copy[n] = map[n].concat();
        }

        var i = 0, j = 0,
      	      z = m_rules.length,
              flag = false;
        for (; i < m_rules.length; ) {
            for (j = i; j < map_copy.length; ++j) {
                if (map_copy[j][0] == m_rules[i][0]) {
                    var tmp = map_copy[i];
                    map_copy[i] = map_copy[j];
                    map_copy[j] = tmp;
                    flag = true;
                    map_copy[i][0] = m_rules[i][1];
                    break;
                }
            }
            if (!flag) {
                if (i == z) break;
                m_rules[i] = m_rules[z];
                z--;
            } else {
                ++i;
            }
        }
        if (i == 0) return;  //you lose~
        var achieve = map_copy.slice(0, i);
        return achieve;    //you get a nice achievement !!!
    },

    run: function (m_rules) {
        var m_verify = this.intersection(m_rules);
        var flag = true;
        for (var i = 0; i < m_verify.length; ++i) {
            if (!m_verify[i][1].apply(this)) {
                this.errMsg = m_verify[i][0];
                flag = false;
                break;
            }
        }
        return flag;
    },

    a: function () {
        return [
            function () { console.log(this); },
            this.run
        ];
    },
    b: function () {
        console.log("name : " + this.name);                       //output: Verify

        var suba = this.a();
        console.log("suba : " + (typeof suba));                   //output: object
        console.log("suba[0] : " + (typeof suba[0]));             //output: function

        suba[0]();                                                //output: [function () { console.log(this); },this.run#summary#]
        console.log(suba[1]);                                     //output: this.run#summary#
        console.log("b's this : " + this);                        //output: [object Object] 
        console.log(this);                                        //output: Verify

        var subc = this.c();
        console.log("subc : " + (typeof subc));                   //output: function
        subc();                                                   //output: windows

        console.log(this.e[0]());                                 //output: [function () { console.log(this); }, undefined]    out:put:undefined 
    },

    c: function () {
        return function () { console.log(this); };
    },

    d: function () {
        console.log(this);
    },

    e: [
            function () { console.log(this); }, //windows
            this.run
    ]
};

function ElementSet() {
}

ElementSet.prototype = {
    constructor: ElementSet,

    SetElmRight: function (elm, elmErr) {
        elm.className = "NomalInput";
        elmErr.innerText = "";
        elmErr.style.display = "none";
    },

    SetElmErr: function (elm, elmErr, errmsg) {
        elm.className = "ErrInput";
        elmErr.innerText = errmsg;
        elmErr.style.display = "";
    },

    SetElm: function (elm, elmErr, errmsg, flag) {
        if (flag) {
            this.SetElmRight(elm, elmErr);
        }
        else {
            this.SetElmErr(elm, elmErr, errmsg);
        }
    }
}





