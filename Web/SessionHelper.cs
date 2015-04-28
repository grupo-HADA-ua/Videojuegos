using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class SessionHelper
    {
        public string GetUsuarioActual()
        {
            string UserId = (string) HttpContext.Current.Session["UserId"];
            return UserId;
        }
    }
}