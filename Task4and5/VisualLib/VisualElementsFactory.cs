using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisualLib.Elements;

namespace VisualLib
{
    public class VisualElementsFactory
    {
        public SynchronizationContext Context { get; set; }
        public VisualElementsFactory(SynchronizationContext context)
        {
            Context = context;
        }

        public RocketUI createRocketUI(int n)
        {
            return new RocketUI(n, new AstronautUI(Context), Context);
        }

        public AgentUI CreateAgentUI(int n)
        {
            return new AgentUI(Context);
        }
    }
}
