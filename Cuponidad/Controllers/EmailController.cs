using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuponidad.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ReturnContent(decimal amount)
        {
            ViewData["Amount"] = amount;
            return View();
        }
        public static string ReturnHtmlContent(HttpContext pContext, string Url)
        {
            var vClient = new HttpClient();
            Uri address = new Uri(pContext.Request.Scheme + "://" + pContext.Request.Host + Url);
            var response = vClient.GetAsync(address).Result;
            var vContent = response.Content;
            return vContent.ReadAsStringAsync().Result;
        }
    }
}