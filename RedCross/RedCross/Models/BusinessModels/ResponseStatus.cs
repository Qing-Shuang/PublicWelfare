using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.BusinessModels
{
    public enum ResponseStatus
    {
        NONE,
        SUCCESS,
        FAILED,
        NOT_PASS,
        NOT_REGISTER,
        NOT_PERMIS_NEWUSER,
        REGISTER_FAILED,
        LOGIN_FAILED,
        REQFORM_COUNT_ISZERO,
        HAVE_NO_TIMETABLE,
        HAVE_TIMETABLE,
        INVALID_BEHAVIOUS,
        ALLOW_NONE_USER,
        ALLOW_ALL_USER,
        ALLOW_SPECIFY_USER,
        ALLOW_SPECIFY_USER_PASS,
        NOALLOW,
        NOT_LOGIN,
        NOT_DATA,
        HAVEREG
    }
}