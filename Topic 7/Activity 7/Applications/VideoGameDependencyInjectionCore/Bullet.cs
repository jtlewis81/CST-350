using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionCore
{
    class Bullet
    {
        public string Name { get; set; }
        public int GramsOfPowder { get; set; }

        public Bullet (string name, int gramsOfPowder)
        {
            Name = name;
            GramsOfPowder = gramsOfPowder;
        }
    }
}
