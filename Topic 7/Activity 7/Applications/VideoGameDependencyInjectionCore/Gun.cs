using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    class Gun : IWeapon
    {
        public string Name { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Gun(string name, List<Bullet> bullets)
        {
            Name = name;
            Bullets = bullets;
        }

        public void AttackWithMe()
        {
            if(Bullets.Count > 0)
            {
                Console.WriteLine(Name + " fires the " + Bullets[0].Name + ", creating a hole in the target.");
                Bullets.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Click. The gun is empty.");
            }
        }
    }
}
