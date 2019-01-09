using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.Culqi;
using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using Cuponidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Cuponidad.Controllers
{
    public class ProductController : Controller
    {
        ProductDetailViewModel ProductDetailViewModel = null;
        CartVewModel CartVewModel = null;
        IConfiguration oIconfig;
        public List<Product> Products { get; set; }
        public List<Cart> Carts { get; set; }

        public ProductController(IConfiguration configration)
        {
            oIconfig = configration;
        }
        public IActionResult Index(int familyID, int categoryID = 0)
        {
            try
            {
                ProductDetailViewModel = new ProductDetailViewModel(0, familyID, categoryID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(ProductDetailViewModel);
        }
        [HttpPost]
        public IActionResult Index(SortingEnum DropDownID = 0, int familyID = 0, int categoryID = 0)
        {
            try
            {
                ProductDetailViewModel = new ProductDetailViewModel(0, familyID, categoryID, DropDownID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(ProductDetailViewModel);
        }
        public IActionResult Detail(int productID, int familyID)
        {
            try
            {
                ProductDetailViewModel = new ProductDetailViewModel(productID, familyID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(ProductDetailViewModel);
        }
        [HttpPost]
        public IActionResult Detail(int productID, int familyID, SortingEnum DropDownID = 0)
        {
            try
            {
                ProductDetailViewModel = new ProductDetailViewModel(productID, familyID, 0, DropDownID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(ProductDetailViewModel);
        }
        public IActionResult Cart()
        {
            try
            {
                if (!CuponSession.IsUserLogin(HttpContext.Session)) return RedirectToAction("Register", "Account");
                CartVewModel = new CartVewModel(CuponSession.GetUser(HttpContext.Session).UserID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(CartVewModel);
        }
        public IActionResult AddToCart(int ProductID)
        {
            try
            {
                if (!CuponSession.IsUserLogin(HttpContext.Session)) return RedirectToAction("Register", "Account");
                Cart cart = new Cart();
                cart.ProductID = ProductID;
                cart.UserID = CuponSession.GetUser(HttpContext.Session).UserID;
                CartRepository.Insert(cart);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Cart");
        }
        public IActionResult Delete(int cartID)
        {
            try
            {
                if (!CuponSession.IsUserLogin(HttpContext.Session)) return RedirectToAction("Register", "Account");
                CartRepository.Delete(cartID);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Cart");
        }
        public IActionResult Search(string term)
        {
            var products = "";
            try
            {
                Products = ProductRepository.ListBySearch(term);
                foreach (var item in Products)
                {
                    item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                    if (item.Description.Length > 77)
                    {
                        item.Description = item.Description.Substring(0, 77);
                    }
                }
                products = JsonConvert.SerializeObject(Products);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return new JsonResult(products);
        }
        public ActionResult CreateCharge(string CardToken)
        {
            Security security = new Security();
            int amountinPen;
            decimal amountInDollor;
            amountInDollor = UserRepository.ReadTotalAmount(CuponSession.GetUser(HttpContext.Session).UserID);
            amountinPen  = Convert.ToInt32(amountInDollor * 100);
            Dictionary<string, object> map = new Dictionary<string, object>
            {
                {"amount", amountinPen},
                {"capture", false},
                {"currency_code", "USD"},
                {"description", "Venta de prueba"},
                {"installments", 0},
                {"email", CuponSession.GetUser(HttpContext.Session).Email},
                {"source_id", CardToken}
            };
            new Charge(security).Create(map);
            CartRepository.DeleteByUser(CuponSession.GetUser(HttpContext.Session).UserID);
            SendEmail(CuponSession.GetUser(HttpContext.Session).Email, amountInDollor);
            return Json("success");
        }

        public void SendEmail(string Email, decimal amount)
        {
            var vContent = EmailController.ReturnHtmlContent(HttpContext, "/Email/ReturnContent?amount=" + amount);
            var vFrom = "Cupnidad@cup.com";
            var vTo = Email;
            var vSubject = "Email from The Cuponidad";
            var response = Send.SendEmail(oIconfig, vFrom, vTo, vSubject, "", vContent);
        }

        public ActionResult UpdateQuantityAndSubTotal(int cartID, int quantity, decimal subTotal)
        {
            CartRepository.UpdateQuantityAndSubtotal(cartID, quantity, subTotal);
            return Json("success");
        }
    }
}