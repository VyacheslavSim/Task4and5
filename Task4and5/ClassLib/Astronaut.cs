using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Abstract;

namespace ClassLib
{
    public class Astronaut : AstronautAbstract
    {
        public TimeSpan TimeToSignalize { get; private set; } = TimeSpan.FromSeconds(2);
        public override void DoWork(Item target)
        {
            if (target is Rocket)
            {
                Thread.Sleep(TimeToSignalize);
                (target as Rocket).SignalizeAboutSuccess(TimeToSignalize);
            }

        }
    }
}
