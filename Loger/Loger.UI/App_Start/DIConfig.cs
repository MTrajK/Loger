using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Loger.BLL.IBusinessLogic;
using Loger.BLL.BusinessLogic;
using Loger.DAL.IDataAccess;
using Loger.DAL.DataAccess;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Loger.DAL.Setup;

namespace Loger.UI.App_Start
{
    public class DIConfig
    {
        // This is for Dependency Injection Configuration
        // And this gonna be called when application will start
        // IOC (Inversion of control) with Auotfac framework
        public static void RegisterContainer()
        {
            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (Register dependencies in controllers)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            /*
            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase. 
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages. (Register dependencies in custom views)
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters. (Register dependencies in filter attributes)
            builder.RegisterFilterProvider();
            */

            // Types of instances
            // http://docs.autofac.org/en/latest/lifetime/instance-scope.html

            // Register our DAL dependencies
            /* 
             * builder.RegisterType< CLASS >().As< INTERFACE >();
             */
            builder.RegisterType<LogerContext>().As<ILogerContext>();  // database context
            builder.RegisterType<ProfileDA>().As<IProfileDA>();
            builder.RegisterType<HomeDA>().As<IHomeDA>();
            builder.RegisterType<AccountDA>().As<IAccountDA>();

            // Register our BLL dependencies
            /* 
            * builder.RegisterType< CLASS >().As< INTERFACE >();
            */
            builder.RegisterType<AccountBL>().As<IAccountBL>();
            builder.RegisterType<HomeBL>().As<IHomeBL>();
            builder.RegisterType<ProfileBL>().As<IProfileBL>();

            // Set the dependency resolver to be Autofac. (Set MVC DI resolver to use our Autofac container)
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}