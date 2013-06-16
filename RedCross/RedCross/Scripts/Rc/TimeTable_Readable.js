function checkCell(obj, name) {
    console.log(obj);
    var element = document.getElementById(name);
    console.log(obj.checked);
    if (obj.checked) {
        element.className = "blue";
        //element.style.backgroundColor = "#b7ddf2"; //b7ddf2 96C2F1(深点)
    }
    else {
        element.className = "white";
        //element.class = "white";
        //element.setAttribute("class","white");
        //console.log("white");
        //element.style.backgroundColor = "#FFFFFF";
    }
}

function checkColumn(obj, currColumn) {
    for (var i = 0; i < 13; ++i) {
        var name = "row" + i + obj.name;
        var element = document.getElementsByName(name);
        if (obj.checked) {
            element[0].checked = true;
        }
        else {
            element[0].checked = false;
        }
        checkCell(element[0], "t" + i + "d" + currColumn);
    }
}

function checkRow(obj, currRow) {
    for (var i = 0; i < 7; ++i) {
        var name = obj.name + "cell" + i;
        var element = document.getElementsByName(name);
        if (obj.checked) {
            element[0].checked = true;
        }
        else {
            element[0].checked = false;
        }
        checkCell(element[0], "t" + currRow + "d" + i);
    }
}