using DevFramework.Core.Utilities.Mvc.Infrastructure;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MemberRegistration.WebMvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            //FluentValidationModelValidatorProvider.Configure(provider =>
            //{
            //    provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            //});
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 80;
            //TimeOut özelliðine aktarýlacak deðer dakika olarak aktarýlmaktadýr.
        }
    }
}
