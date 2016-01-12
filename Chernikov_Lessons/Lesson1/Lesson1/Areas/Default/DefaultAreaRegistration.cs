using System.Web.Mvc;

namespace Lesson1.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Default";

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"Lesson1.Areas.Default.Controllers"}
                );
        }
    }
}