using System.Web.Mvc;

namespace Lesson1.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                name: "admin",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"Lesson1.Areas.Admin.Controllers"}
                );
        }
    }
}