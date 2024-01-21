using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name {  get; set; }

        public IWeapon MyWeapon { get; set; }

        public HeroThatCanUseAnyWeapon()
        {
            Name = "Uncommon Hero";
            MyWeapon = null;
        }

        public HeroThatCanUseAnyWeapon(string name, IWeapon myWeapon)
        {
            Name = name;
            MyWeapon = myWeapon;
        }

        public void Attack()
        {
            Console.WriteLine(Name + " prepares for battle.");
            MyWeapon.AttackWithMe();
        }
    }
}
