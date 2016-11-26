using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loger.BLL.IBusinessLogic;
using Loger.Common.ViewModels;
using Loger.Common.Other;
using System.Diagnostics;
using System.IO;

namespace Loger.UI.Controllers
{
    public class HomeController : Controller
    {

        private IHomeBL _homeBL;

        public HomeController(IHomeBL homeBL)
        {
            _homeBL = homeBL;
        }
        
        public ActionResult Index()
        {
            // user is not active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Main model = _homeBL.getAllLogos((int)HttpContext.Session["ActiveUserID"]);
            return View(model);
        }

        // get all logos from user which are followed by active user
        public ActionResult Following()
        {
            // user is not active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Main model = _homeBL.getAllFollowingLogos((int)HttpContext.Session["ActiveUserID"]);
            return View(model);
        }

        // get all liked logos
        public ActionResult Favorites()
        {
            // user is not active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Main model = _homeBL.getAllFavoriteLogos((int)HttpContext.Session["ActiveUserID"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult Like(LikedLogo data)
        {
            string response = _homeBL.LikeLogo(data);

            return Json(response);
        }

        [HttpPost]
        public ActionResult Comment(CommentedLogo data)
        {
            string response = _homeBL.CommentLogo(data);

            return Json(response);
        }

        [HttpPost]
        public ActionResult UploadLogo(UploadedLogo data)
        {
            string extension;

            // Searching for extension and remove description (unnecessary part from decoded image)
            if (data.LogoData.StartsWith("data:image/jpeg;base64,"))
            {
                extension = "jpg";
                data.LogoData = data.LogoData.Substring(23);
            }
            else if (data.LogoData.StartsWith("data:image/png;base64,"))
            {
                extension = "png";
                data.LogoData = data.LogoData.Substring(22);
            }
            else if (data.LogoData.StartsWith("data:image/gif;base64,"))
            {
                extension = "gif";
                data.LogoData = data.LogoData.Substring(22);
            }
            else
            {
                return Json("fail");
            }

            // write picture in ~/Uploads/Logos/ : format {DateTime.Now.Ticks_ActiveUser.id}
            string imageName = DateTime.Now.Ticks + "_" + HttpContext.Session["ActiveUserID"] + "." + extension;
            string imageRelativePath = @"/Uploads/Logos/" + imageName;
            string imagePath = AppDomain.CurrentDomain.BaseDirectory + imageRelativePath;

            // Converting Base64 string to bytes and write in file!!!
            var photoBytes = Convert.FromBase64String(data.LogoData);
            using (var photoFile = new FileStream(imagePath, FileMode.Create))
            {
                photoFile.Write(photoBytes, 0, photoBytes.Length);
                photoFile.Flush();
            }

            // to write this path in DB
            data.LogoData = imageRelativePath;

            string response = _homeBL.UploadLogo(data);
            return Json(response);
        }

        [HttpGet]
        public ActionResult GetLastestUpload()
        {
            Card data = _homeBL.GetLastestUploadById((int) HttpContext.Session["ActiveUserID"]);

            return Json(data, JsonRequestBehavior.AllowGet); ;
        }

        [HttpGet]
        public ActionResult LogoDetails(int logoId)
        {
            LogoDetails data = _homeBL.GetLogoDetails(logoId, (int)HttpContext.Session["ActiveUserID"]);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}