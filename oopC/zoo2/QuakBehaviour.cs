using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC.zoo2
{
    internal class QuakBehaviour: ISpeak
    {
        public string Speak()
        {
            return "Quack Quack!";
        }
    }
}
