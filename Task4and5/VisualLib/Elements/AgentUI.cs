using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib;

namespace VisualLib.Elements
{
    public class AgentUI : ElementUI<Agent>
    {
        Size s = new Size(40, 80);
        Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\agent.png");
        Image iconPaying = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\agentMoney.png");

        public AgentUI(SynchronizationContext context) : base(context)
        {
            LogicObj = new Agent();
            VisualElement = new Bitmap(icon, s);
            LogicObj.Y = 650;
        }

        public void DoWork(Rocket target)
        {
            VisualElement = new Bitmap(iconPaying, s);
            LogicObj.X = target.X;
            LogicObj.DoWork(target);
            VisualElement = new Bitmap(icon, s);
        }
    }
}
