using Ninject;
using Ninject.Modules;
using System.Web.Http;
using System.Web.Mvc;
using TextAnalyzer.API.APIInfrastructure;

namespace TextAnalyzer.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
