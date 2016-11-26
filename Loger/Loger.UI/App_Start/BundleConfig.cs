using System.Web;
using System.Web.Optimization;

namespace Loger.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* JS */
            // JQuery js
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                        "~/Scripts/jquery.js"));

            // Bootstrap js
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // Loger js
            bundles.Add(new ScriptBundle("~/Scripts/loger").Include(
                      "~/Scripts/loger.js"));

            // Knockoit js
            bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
                      "~/Scripts/knockout.js",
                      "~/Scripts/knockout.mapping.js"));

            ///// ViewModels

            // Login js
            bundles.Add(new ScriptBundle("~/ViewModels/Login").Include(
                     "~/Scripts/ViewModels/Login.js"));

            // Register js
            bundles.Add(new ScriptBundle("~/ViewModels/Register").Include(
                     "~/Scripts/ViewModels/Register.js"));

            // Settings js
            bundles.Add(new ScriptBundle("~/ViewModels/Settings").Include(
                     "~/Scripts/ViewModels/Settings.js"));

            // Cards js
            bundles.Add(new ScriptBundle("~/ViewModels/Cards").Include(
                     "~/Scripts/ViewModels/Cards.js"));

            // Profile js
            bundles.Add(new ScriptBundle("~/ViewModels/Profile").Include(
                     "~/Scripts/ViewModels/Profile.js"));

            // UploadLogo js
            bundles.Add(new ScriptBundle("~/ViewModels/UploadLogo").Include(
                     "~/Scripts/ViewModels/UploadLogo.js"));

            // LogoDetails js
            bundles.Add(new ScriptBundle("~/ViewModels/LogoDetails").Include(
                     "~/Scripts/ViewModels/LogoDetails.js"));


            /* CSS */
            // Bootstrap css
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            // Loger css 
            bundles.Add(new StyleBundle("~/Content/loger").Include(
                      "~/Content/loger.css"));
        }
    }
}
