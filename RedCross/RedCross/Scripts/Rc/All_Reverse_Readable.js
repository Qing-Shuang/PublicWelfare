/* File Created: 六月 9, 2012 */

function checkAllorInverse(obj,elmId) {
    var flag;
    if (obj.checked) {
        flag = true;
    }
    else
    {
        flag = false;
    }
    var elems = document.getElementById(elmId);
    var checkboxs = elems.getElementsByTagName("input");
    for(var i = 0;i<checkboxs.length;++i) {
        if (checkboxs[i].type == "checkbox") {
            checkboxs[i].checked = flag;    
        }
    }
}