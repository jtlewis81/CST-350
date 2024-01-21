using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    class HeroThatOnlyUsesSwords : IHero
    {
        public string Name { get; set; }

        public HeroThatOnlyUsesSwords(string name)
        {
            Name = name;
        }
        public HeroThatOnlyUsesSwords()
        {
            Name = "Weak starter hero";
        }

        public void Attack()
        {
            Sword sword = new Sword("Wooden Sword");
            Console.WriteLine(Name + " prepares for battle, drawing his " + sword.SwordName);
            sword.AttackWithMe();
        }
    }
}
