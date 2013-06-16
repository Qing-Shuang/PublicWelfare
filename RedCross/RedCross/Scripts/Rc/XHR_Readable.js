function createXHR() {
    if (typeof XMLHttpRequest != "undefined") {
        return new XMLHttpRequest();
    }
    else if (typeof ActiveXObject != "undefined") {
        if (typeof arguments.callee.activeXString != "string") {
            var versions = ["MSXML2.XMLHttp.6.0", "MSXML2.XMLHttp.3.0", "MSXML2.XMLHttp"];
            for (var i = 0, len = versions.length; i < len; ++i) {
                try {
                    var xhr = new ActiveXObject(versions[i]);
                    arguments.callee.activeXString = versions[i];
                    return xhr;
                }
                catch (ex) {
                }
            }
        }
        return new ActiveXObject(arguments.callee.activeXString);
    } 
    else {
        throw new Error("No XHR object available");
    }
}

function submitData() {
    var xhr = createXHR();
    xhr.onreadystatechange = function (event) {
        if (xhr.readystate == 4) {
            if ((xhr.status >= 200 && xhr.status < 300 || xhr.status == 304)) {
                alert(xhr.responseText);
            }
            else {
                alert("Request was unsuccessful: " + xhr.status);
            }

        }
    }
}
