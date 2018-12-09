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
    public class AstronautUI : ElementUI<Astronaut>
    {
        public Size s = new Size(30, 30);
        public Size succ = new Size(250,250);
        public Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\astronaut.png");
        public Image iconSucceed = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\astronautSuceeded.png");

        public AstronautUI(SynchronizationContext context) : base(context)
        {
            LogicObj = new Astronaut();
            VisualElement = new Bitmap(icon, s);
        }

    }
}
