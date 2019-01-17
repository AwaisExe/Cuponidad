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
                ProductDetailViewModel.Products = ProductDetailViewModel.Products.Where(x => x.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
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
                ProductDetailViewModel.Products = ProductDetailViewModel.Products.Where(x => x.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
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
                ProductDetailViewModel.Products = ProductDetailViewModel.Products.Where(x => x.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
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
                ProductDetailViewModel.Products = ProductDetailViewModel.Products.Where(x => x.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(ProductDetailViewModel);
        }
        public IActionResult Cart(int FamilyID)
        {
            try
            {
                if (!CuponSession.IsUserLogin(HttpContext.Session)) return RedirectToAction("Register", "Account");
                CartVewModel = new CartVewModel(CuponSession.GetUser(HttpContext.Session).UserID);
                CartVewModel.FamilyID = FamilyID;
                CartVewModel.Products = CartVewModel.Products.Where(x => x.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(CartVewModel);
        }
        public IActionResult AddToCart(int ProductID, int FamilyID)
        {
            Product product = new Product();
            Cart cart = new Cart();
            try
            {
                if (!CuponSession.IsUserLogin(HttpContext.Session)) return RedirectToAction("Register", "Account");
                product = ProductRepository.Read(ProductID);
                product.DiscountAmount = string.Format("{0:0.##}", (product.Prize - ((product.Prize * product.Discount) / 100)));
                cart.Quantity = 1;
                cart.Total = Convert.ToDecimal(product.DiscountAmount);
                cart.ProductID = ProductID;
                cart.UserID = CuponSession.GetUser(HttpContext.Session).UserID;
                CartRepository.Insert(cart);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Cart", new { FamilyID });
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
            amountinPen = Convert.ToInt32(amountInDollor * 100);
            Dictionary<string, object> map = new Dictionary<string, object>
            {
                {"amount", amountinPen},
                {"capture", false},
                {"currency_code", "PEN"},
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
            //var vContent = EmailController.ReturnHtmlContent(HttpContext, "/Email/ReturnContent?amount=" + amount);
            ////var vContent = "Your Order is successful and you paid Amount:" + amount;
            //var vFrom = "Cupnidad@cup.com";
            //var vTo = Email;
            //var vSubject = "Email from The Cuponidad";
            //var response = Send.SendEmail(oIconfig, vFrom, vTo, vSubject, "", vContent);
        }

        public ActionResult UpdateQuantityAndSubTotal(int cartID, int quantity, decimal subTotal)
        {
            CartRepository.UpdateQuantityAndSubtotal(cartID, quantity, subTotal);
            return Json("success");
        }
    }
}