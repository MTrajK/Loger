using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loger.BLL.IBusinessLogic;
using Loger.Common.ViewModels;
using System.Diagnostics;

namespace Loger.UI.Controllers
{
    public class AccountController : Controller
    {

        private IAccountBL _accountBL;

        public AccountController(IAccountBL accountBL)
        {
            _accountBL = accountBL;
        }

        public ActionResult Login()
        {
            // user is active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            Login empty = new Login
            {
                Email = "",
                Password = ""
            };

            return View(empty);
        }
        
        [HttpPost]
        public ActionResult UserLogin(Login data)
        {
            Tuple<string, int> response = _accountBL.CheckUser(data);
            if (response.Item1 == "success")
            {
                HttpContext.Session["ActiveUserID"] = response.Item2;
            }
            return Json(response.Item1);
        }


        public ActionResult Register()
        {
            // user is active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            Register empty = new Register
            {
                Email = "",
                Username = "",
                Password = "",
                ConfirmPassword = ""
            };

            return View(empty);
        }
        
        [HttpPost]
        public ActionResult UserRegister(Register data)
        {
            Tuple<string, int> response = _accountBL.RegisterUser(data);
            if (response.Item1 == "success")
            {
                HttpContext.Session["ActiveUserID"] = response.Item2;
            }
            return Json(response.Item1);
        }

        public ActionResult Logoff()
        {
            // On logoff there is no active user
            HttpContext.Session["ActiveUserID"] = null;

            return RedirectToAction("Login", "Account");
        }
    }
}