using System.Web.Mvc;
using Lesson1.Controllers;
using Lesson1.Models;
using Ninject;

namespace Lesson1.Areas.Default.Controllers
{
    public class HomeController : BaseController
    {
        //private static readonly IKernel AppKernel = new StandardKernel(new WeaponNinjectModule());

        [Inject]
        public IWeapon Weapon { get; set; }

        // GET: Home
        public ActionResult Index() {
            //var warrior = AppKernel.Get<Warrior>();
            //ViewBag.WarriorMessage = warrior.Kill();

            return View(Weapon);
        }
    }
}