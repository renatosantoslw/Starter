using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using PDV.RETAGUARDA.WEB.AppContext;
using System.Web.Http;
using System.Web.Optimization;

namespace PDV.RETAGUARDA.ANDROID
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultRoute",
                routeTemplate: "api/{controller}/{id}", 
                defaults: new {
                    id = RouteParameter.Optional,                    
                }
            );

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}