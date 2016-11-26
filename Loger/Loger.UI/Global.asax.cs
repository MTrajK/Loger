using Loger.UI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Loger.DAL.Setup;
using System.Configuration;

namespace Loger.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Dependency Injection configuration
            DIConfig.RegisterContainer();
            // Entity Framework initialization (passing database connection string)
            EFConfig.RegisterDatabase(ConfigurationManager.ConnectionStrings["LogerDBConnectionString"].ConnectionString);
        }
    }
}
