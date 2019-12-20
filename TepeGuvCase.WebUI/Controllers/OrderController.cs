using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TepeGuvCase.BLL.Repositories;
using TepeGuvCase.DAL;
using TepeGuvCase.WebUI.App_Start;
using TepeGuvCase.WebUI.Tools;

namespace TepeGuvCase.WebUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        OrderRepository or = new OrderRepository();
        public ActionResult ConfirmCart()
        {
            if (Session["cart"] != null)
            {
                MyCart cart = Session["cart"] as MyCart;
                if (cart.GetAllCartItem.Count > 0)
                {
                    User kullanici = Session["kullanici"] as User;
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    order.Phone = kullanici.Phone;
                    order.Mail = kullanici.Mail;
                    order.UserID = kullanici.ID;
                    order.Status = true;
                    order.OrderDetails = new List<OrderDetail>();
                    foreach (CartItem item in cart.GetAllCartItem)
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ProductID = item.ID;
                        orderDetail.Quantity = item.Amount;
                        orderDetail.UnitPrice = item.Price;
                        order.OrderDetails.Add(orderDetail);
                    }

                    or.Add(order);


                    Session["cart"] = new MyCart();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult CancelCart(int? id)
        {
            if (id != null)
            {
                Order canceled = or.SelectAll().Where(x => x.ID == id).SingleOrDefault();
                canceled.Status = false;
                or.Update(canceled);
               
                return RedirectToAction("_AllOrders", "Order");
            }
          
            return RedirectToAction("Index", "Home");

        }

        [CustomFilter]
        public ActionResult _AllOrders(User kullanici)
        {
            kullanici = Session["kullanici"] as User;
            if (kullanici != null)
            {
                return PartialView(or.SelectAll().Where(x => x.UserID == kullanici.ID && x.Status == true).ToList());
            }
            return PartialView(or.SelectAll());
        }
    }
}