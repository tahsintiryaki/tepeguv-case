using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeGuvCase.BLL.Repositories;
using TepeGuvCase.DAL;

namespace TepeGuvCase.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        UserRepository userRepository = new UserRepository();
        [HttpPost]
        public ActionResult Login(User item)
        {
            var gelenkullanici = userRepository.SelectAll().Where(x => x.UserName == item.UserName && x.Password == item.Password).FirstOrDefault();
            if (gelenkullanici != null)
            {
                Session["kullanici"] = gelenkullanici;
                ViewBag.Error = "Giriş başarılı";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Kullanıcı Bulunamadı...";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("kullanici");
            return RedirectToAction("Index", "Home");
        }
    }
}