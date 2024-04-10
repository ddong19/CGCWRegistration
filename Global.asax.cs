using CGCWRegistration.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.Models;
using CGCWRegistration.DAL.ResponseOptionRepository;
using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.BLL;

namespace CGCWRegistration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<RegistrationContext>()
                   .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["RegistrationContext"].ConnectionString)
                   .InstancePerRequest();

            builder.RegisterType<LanguageRepository>().As<ILanguageRepository>();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<AgeRangeRepository>().As<IAgeRangeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ResponseOptionRepository>().As<IResponseOptionRepository>();
            builder.RegisterType<RegistrationService>().As<IRegistrationService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
