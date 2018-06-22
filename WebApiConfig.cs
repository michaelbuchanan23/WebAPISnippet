using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MVCWebAPITutorial {
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			//adds routing which doesn't include API
			config.Routes.MapHttpRoute(
				name: "RegularApi",
				routeTemplate: "{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			//allows us to see the data in our browser as JSON without Postman
			config.Formatters.JsonFormatter.SupportedMediaTypes
				.Add(new MediaTypeHeaderValue("text/html"));
		}
	}
}