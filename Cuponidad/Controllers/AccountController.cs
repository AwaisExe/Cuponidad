using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuponidad.DataAccessLayer.Model;
using Cuponidad.DataAccessLayer.Repository;
using Cuponidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Cuponidad.Controllers
{
    public class AccountController : Controller
    {
        IConfiguration oIconfig;
        public AccountController(IConfiguration configration)
        {
            oIconfig = configration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string LoginMessage = "")
        {
            if (LoginMessage != "") ViewData["ErrorMessageLogin"] = LoginMessage;
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user, string repeatPassword)
        {
            try
            {
                if (user.Password != repeatPassword) throw new Exception("Password Does not match");
                UserRepository.Insert(user);
                ViewData["SuccessMessageRegister"] = "Your Account has been created successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessageRegister"] = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            string Message = "";
            try
            {
                User user = null;
                user = UserRepository.VerifyLogin(Email, Password);
                if (user != null) CuponSession.Login(HttpContext.Session, user);
                else throw new Exception("Email or password is incorect");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return RedirectToAction("Register", new { LoginMessage = Message });
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            CuponSession.Stop(HttpContext.Session);
            return RedirectToAction("Register");
        }
        public async Task<IActionResult> FacebookLogin(string pFBID, string pAccessToken)
        {
            try
            {
                User user = null;
                string email;
                string name;
                var oUser = await Facebook.GetAccountAsync(pAccessToken);

                email = oUser["email"];
                name = oUser["first_name"] + " " + oUser["last_name"];
                user = UserRepository.VerifyEmail(email);
                if (user == null)
                {
                    user = new User();
                    user.Email = email;
                    user.FullName = name;
                    user.Gender = UserGender.Male;
                    user = UserRepository.Insert(user);
                    CuponSession.Login(HttpContext.Session, user);
                }
                else
                {
                    CuponSession.Login(HttpContext.Session, user);
                }
                return StatusCode(200, "User is successfully Login");
            }
            catch (Exception ex)
            {
                return StatusCode(403, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Change(string ChangeEmail)
        {
            //SendEmail(ChangeEmail);
            return RedirectToAction("Register");
        }
        public void SendEmail(string Email)
        {
            var vContent = EmailController.ReturnHtmlContent(HttpContext, "/Email/ReturnContent?amount=" + 110);
            //var vContent = "Your Order is successful and you paid Amount:" + amount;
            var vFrom = "Cupnidad@cup.com";
            var vTo = Email;
            var vSubject = "Email from The Cuponidad";
            var response = Send.SendEmail(oIconfig, vFrom, vTo, vSubject, "", vContent);
        }
    }
}