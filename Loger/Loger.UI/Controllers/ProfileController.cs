using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loger.BLL.IBusinessLogic;
using Loger.Common.ViewModels;
using System.Diagnostics;
using Loger.Common.Other;
using System.IO;
using System.Net.Http;

namespace Loger.UI.Controllers
{
    public class ProfileController : Controller
    {

        private IProfileBL _profileBL;

        public ProfileController(IProfileBL profileBL)
        {
            _profileBL = profileBL;
        }

        // GET: Profile
        public ActionResult Index(int Id)
        {
            // user is not active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Profile empty = _profileBL.GetProfile(Id, (int) HttpContext.Session["ActiveUserID"]);

            return View(empty);
        }

        [HttpPost]
        public ActionResult Follow(FollowingUser data)
        {
            string response = _profileBL.Follow(data);

            return Json(response);
        }

        [HttpPost]
        public ActionResult Unfollow(FollowingUser data)
        {
            string response = _profileBL.Unfollow(data);

            return Json(response);
        }

        public ActionResult Edit()
        {
            // user is not active, can't access in this view
            if (HttpContext.Session["ActiveUserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Settings empty = _profileBL.GetSettingsView((int) HttpContext.Session["ActiveUserID"]);
            return View(empty);
        }
        
        [HttpPost]
        public ActionResult EditSettings(Settings data)
        {
            
            if (data.AccountPhotoData != null)
            {
                string extension;

                // Searching for extension and remove description (unnecessary part from decoded image)
                if (data.AccountPhotoData.StartsWith("data:image/jpeg;base64,"))
                {
                    extension = "jpg";
                    data.AccountPhotoData = data.AccountPhotoData.Substring(23);
                } else if (data.AccountPhotoData.StartsWith("data:image/png;base64,"))
                {
                    extension = "png";
                    data.AccountPhotoData = data.AccountPhotoData.Substring(22);
                } else if (data.AccountPhotoData.StartsWith("data:image/gif;base64,"))
                {
                    extension = "gif";
                    data.AccountPhotoData = data.AccountPhotoData.Substring(22);
                } else
                {
                    return Json("fail");
                }

                // write picture in ~/Uploads/UserPhotos/ : format {DateTime.Now.Ticks_ActiveUser.id}
                string imageName = DateTime.Now.Ticks + "_" + HttpContext.Session["ActiveUserID"] + "." + extension;
                string imageRelativePath = @"/Uploads/UserPhotos/" + imageName;
                string imagePath = AppDomain.CurrentDomain.BaseDirectory + imageRelativePath;

                // Converting Base64 string to bytes and write in file!!!
                var photoBytes = Convert.FromBase64String(data.AccountPhotoData);
                using (var photoFile = new FileStream(imagePath, FileMode.Create))
                {
                    photoFile.Write(photoBytes, 0, photoBytes.Length);
                    photoFile.Flush();
                }

                // to write this path in DB
                data.AccountPhotoData = imageRelativePath;
            }

            string response = _profileBL.UpdateUserProfile(data);
            return Json(response);
        }

    }
}