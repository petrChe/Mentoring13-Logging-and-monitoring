using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger logger;

        public MvcApplication()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        protected void Application_Start()
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(_ => LogManager.GetLogger("ControllersLogger")).As<ILogger>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            logger.Info("Application_Start");
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            logger.Error(exception.ToString());
        }
    }
}
