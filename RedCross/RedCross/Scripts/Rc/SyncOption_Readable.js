/* File Created: 十一月 3, 2012 */

var form = document.forms["userInfoForTimeTable"];
var idSelcet = form.xuehao;
var nameSelect = form.xinming;
var idErr = document.getElementById("xuehaoErr");
var nameErr = document.getElementById("xinmingErr");

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

var eventUtil = new EventUtil();
var verify_func = intersection(["checkNull"]);
eventUtil.addHandler(idSelcet, "change", idfunc);
eventUtil.addHandler(idSelcet, "blur", function (event) {
    if (verify_func) {
        if (verify_func[0][1](idSelcet, idErr)) {
            return;
        }
    }
});
eventUtil.addHandler(nameSelect, "change", namefunc);
eventUtil.addHandler(form.btnSearch, "click", function (event) {

    if (verify_func) {
        if (verify_func[0][1](idSelcet, idErr)) {
            return;
        }
    }
    var e = eventUtil.getEvent(event);
    eventUtil.preventDefault(e);
});