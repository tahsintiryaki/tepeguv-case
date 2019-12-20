using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TepeGuvCase.WebUI.App_Start
{
    public class CustomFilter: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            //Kullanıcı girişi varken nasıl davranacağını belirtiriz.
            if (System.Web.HttpContext.Current.Session["kullanici"] != null)
            {

                return true;
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Kullanıcı Girişi Yokken Nasıl Davranacağını belirtiriz.
            filterContext.Result = new RedirectResult("/Account/Login");
        }
    }
}