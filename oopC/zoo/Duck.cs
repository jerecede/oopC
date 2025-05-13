using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC.zoo
{
    internal class Duck: Animal
    {
        public Duck(string name) : base(name){}

        public override string Speak()
        {
            return "Quack Quack!";
        }
    }
}
