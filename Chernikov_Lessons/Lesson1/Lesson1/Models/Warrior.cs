using System;
using Ninject;
using Ninject.Modules;

namespace Lesson1.Models
{
    public class WeaponNinjectModule : NinjectModule
    {
        public override void Load() {
            Bind<IWeapon>().To<Sword>();
        }
    }

    public interface IWeapon
    {
        string Kill();
    }

    internal class Bazooka : IWeapon
    {
        public string Kill() {
            Console.WriteLine("Badaboom!!!");
            return "Badaboom!!!";
        }
    }

    internal class Sword : IWeapon
    {
        public string Kill() {
            Console.WriteLine("Chuck-chuck");
            return "Chuck-chuck";
        }
    }

    public class Warrior
    {
        [Inject]
        public IWeapon Weapon { get; set; }

        public string Kill() {
            return Weapon.Kill();
        }
    }
}