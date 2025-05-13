using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC.zoo2
{
    internal class Beast
    {
        public string Name { get; set; }
        public ISpeak SpeakBehaviour { get; set; }

        public Beast(string name, ISpeak speakBehaviour)
        {
            Name = name;
            SpeakBehaviour = speakBehaviour;
        }

        public string Speak()
        {
            return SpeakBehaviour.Speak();
        }
    }
}
