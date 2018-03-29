using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextAnalyzer.DAL;
using TextAnalyzer.DAL.Interfaces;

namespace TextAnalyzer.API.Infrastructure
{
    public class NinjectServiceModule: NinjectModule
    {
        private string connectionString;
        public NinjectServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}