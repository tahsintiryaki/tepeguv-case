using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeGuvCase.BLL.Repositories;
using TepeGuvCase.WebUI.App_Start;
using TepeGuvCase.WebUI.Tools;

namespace TepeGuvCase.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [CustomFilter]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _CartList()
        {
            return PartialView();
        }
        public ActionResult _CartButton()
        {
            return PartialView();
        }
        ProductRepository prd = new ProductRepository();
        public ActionResult AddToCart(int id)
        {
            //MyCart myCart = new MyCart(); bu kullanım bana sürekli yeni sepetler oluşturur.
            MyCart cart = Session["cart"] as MyCart;
            CartItem cartItem = new CartItem();
            var eklenenUrun = prd.SelectByID(id);
            cartItem.ID = eklenenUrun.ID;
            cartItem.Name = eklenenUrun.Title;
            cartItem.Price = eklenenUrun.Price;
            cartItem.Amount = 1;

            cart.Add(cartItem);
            Session["cart"] = cart;

            return PartialView("_CartButton");
        }
        public ActionResult UpdateCart(short amount, int id)
        {
            MyCart guncellenenSepet = Session["cart"] as MyCart;
            guncellenenSepet.Update(id, amount);
            Session["cart"] = guncellenenSepet;

            return RedirectToAction("_CartList", "Cart");
        }

        public ActionResult DeleteItemCart(int id)
        {
            MyCart silinecekSepet = Session["cart"] as MyCart;
            silinecekSepet.Delete(id);
            Session["cart"] = silinecekSepet;

            return RedirectToAction("_CartList", "Cart");
        }
    }
}