﻿using System.Web.Http;

namespace Beeant.Presentation.Website.Shared
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
        }
    }
}
