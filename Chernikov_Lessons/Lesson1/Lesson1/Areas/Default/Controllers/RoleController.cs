using System.Linq;
using System.Web.Mvc;
using Lesson1.Controllers;

namespace Lesson1.Areas.Default.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index() {
            var roles = Repository.Roles.ToList();
            return View(roles);
        }
    }
}