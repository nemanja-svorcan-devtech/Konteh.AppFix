using System.Web.Http;
using AppFixAPI.Controllers;
using AppFixAPI.Services;
using CustomMessageHandler;
using DependencyResolver;
using KontehAppFix;

namespace AppFixAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services

			var container = new IoCContainer();

			//dependencies registration
			container.RegisterType<KontehChallengeController>();
			container.RegisterType<IGuidProvider, GuidProvider>();
			container.RegisterType<IKonteh, Konteh>();

			config.DependencyResolver = new DependencyResolver.DependencyResolver(container);
			config.MessageHandlers.Add(new ClientMessageHandler());

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
