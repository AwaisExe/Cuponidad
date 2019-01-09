using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.Culqi;
using Cuponidad.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Cuponidad.Controllers
{
    public class CreditCardController : Controller
    {
        Security security = null;

        public CreditCardController()
        {
            security = new Security();
            security.public_key = "pk_test_FkUpVmAZycXE7aE7";
            security.secret_key = "sk_test_ajUsPyiP1xKZxG0S";
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChargeCard(string CardToken)
        {

            if (CardToken != null)
            {
               var response = CreateCharge(CardToken);
            }
            return View();
        }
        protected string CreateToken()
        {
            Dictionary<string, object> map = new Dictionary<string, object>
            {
                {"card_number", "4111111111111111"},
                {"cvv", "123"},
                {"expiration_month", 9},
                {"expiration_year", 2020},
                {"email", "wmuro@me.com"}
            };
            return new Token(security).Create(map);
        }
        public string CreateCharge(string CardToken)
        {

            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"order_id", "777"}
            };

            Dictionary<string, object> map = new Dictionary<string, object>
            {
                {"amount", 1000},
                {"capture", false},
                {"currency_code", "USD"},
                {"description", "Venta de prueba"},
                {"email", "iamawais2@gmail.com"},
                {"installments", 0},
                //{"metadata", metadata},
                {"source_id", CardToken}
            };

            return new Charge(security).Create(map);

        }
    }
}