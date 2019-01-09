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
        public IActionResult Index()
        {
            ProductViewModel = new ProductViewModel();
            return View(ProductViewModel);
        }
        public IActionResult SearchList(string searchText = "", int departmentID = 0)
        {
            if (departmentID > 0) Products = ProductRepository.ListByDepartment(departmentID);
            else Products = ProductRepository.ListBySearch(searchText);
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
