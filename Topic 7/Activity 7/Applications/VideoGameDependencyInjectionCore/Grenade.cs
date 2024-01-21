using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    class Grenade : IWeapon
    {
        public string WeaponName { get; set; }
        
        public Grenade()
        {
            WeaponName = "Frag Grenade";
        }

        public Grenade(string weaponName)
        {
            WeaponName = weaponName;
        }

        public void AttackWithMe()
        {
            Console.WriteLine(WeaponName + " just caused someone to have a bad day!");
        }
    }
}
