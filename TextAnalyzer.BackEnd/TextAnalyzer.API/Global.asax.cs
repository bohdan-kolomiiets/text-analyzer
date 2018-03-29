using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TextAnalyzer.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //DI
            //NinjectModule orderModule = new OrderModule();
            NinjectModule serviceModule = new NinjectServiceModule("TextAnalyzerDbConnectionString");
            //var kernel = new StandardKernel(orderModule, serviceModule);
            var kernel = new StandardKernel(serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
