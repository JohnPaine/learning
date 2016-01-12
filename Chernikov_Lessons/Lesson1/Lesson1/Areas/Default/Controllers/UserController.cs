using System.Linq;
using System.Web.Mvc;
using Lesson1.Controllers;

namespace Lesson1.Areas.Default.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index() {
            var users = Repository.Users.ToList();
            return View(users);
        }
    }
}