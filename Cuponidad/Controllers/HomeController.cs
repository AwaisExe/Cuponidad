using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cuponidad.Models;
using Cuponidad.DataAccessLayer.Repository;
using Cuponidad.DataAccessLayer.Model;

namespace Cuponidad.Controllers
{
    public class HomeController : Controller
    {
        ProductViewModel ProductViewModel = null;
        List<Product> Products = new List<Product>();
        public IActionResult Index(int departmentID = 2)
        {
            if (departmentID > 0)
            {
                ViewData["IsDepartment"] = "Departmet";
                CuponSession.SetDepartmentID(HttpContext.Session, departmentID);
            }
            ProductViewModel = new ProductViewModel(departmentID);
            return View(ProductViewModel);
        }
        public IActionResult SearchList(string searchText = "", int departmentID = 0)
        {

            if (departmentID > 0)
            {
                //Products = ProductRepository.ListByDepartment(departmentID);
                CuponSession.SetDepartmentID(HttpContext.Session, departmentID);
                return RedirectToAction("Index", new { departmentID });
            }
            else
            {
                Products = ProductRepository.ListBySearch(searchText);
                foreach (var item in Products)
                {
                    item.DiscountAmount = string.Format("{0:0.##}", (item.Prize - ((item.Prize * item.Discount) / 100)));

                    if (item.Description.Length > 77)
                    {
                        item.Description = item.Description.Substring(0, 77);
                    }
                }
                Products = Products.Where(X => X.DepartmentID == CuponSession.GetDepartmentID(HttpContext.Session)).ToList();
            }
            return View(Products);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
