using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeGuvCase.DAL;
using TepeGuvCase.BLL.Repositories;
using TepeGuvCase.BLL;

namespace TepeGuvCase.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        ProductRepository prd = new ProductRepository();
        public ActionResult Index()
        {

          
            return View();
        }
        public ActionResult _AllProducts()
        {
            return PartialView(prd.SelectAll());
        }
       

    }
}