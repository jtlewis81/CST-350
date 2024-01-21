using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    internal class Sword : IWeapon
    {
        public string SwordName { get; set; }
        public Sword(string swordName)
        {
            SwordName = swordName;
        }
        public Sword()
        {
            SwordName = "Default sword name :(";
        }

        public void AttackWithMe()
        {
            Console.WriteLine(SwordName + " cuts down the enemy!");
        }
    }
}
