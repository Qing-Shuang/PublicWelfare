//跨浏览器的事件处理程序
function EventUtil(){}

EventUtil.prototype = {
    constructor:EventUtil,

    getEvent: function (event) {
        return event ? event : window.event;
    },

    addHandler: function (element, type, handler) {
        if (element.addEventListener) {    //DOM2
            element.addEventListener(type, handler, false);
        } else if (element.attachEvent) {    //IE
            element.attachEvent("on" + type, handler);
        } else {      //DOM0
            element["on" + type] = handler;
        }
        
    },

    removeHandler: function (element, type, handler) {
        if (element.removeEventListener) {      //DOM2
            element.removeEventListener(type, handler, false);
        } else if (element.detachEvent) {            //IE
            element.detachEvent("on" + type, handler);
        } else {        //DOM0
            element["on" + type] = null;
        }
    },

    preventDefault: function (event) {
        if (event.preventDefault) {
            event.preventDefault();
        } else {
            event.returnValue = false; //IE
        }
    }
};