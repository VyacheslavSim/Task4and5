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
    public class RocketUI : ElementUI<Rocket>
    {
        Size s = new Size(80, 80);
        int Delta = 150;
        Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\rocket.png");
        Image iconBroken = Image.FromFile(@"C:\2 курс\ЯиСП\Task4and5\Task4\Resources\rocketBroken.png");

        public AstronautUI Astronaut { get; set; }
        public RocketUI(int n, AstronautUI astronaut, SynchronizationContext context) : base(context)
        {
            VisualElement = new Bitmap(icon, s);
            LogicObj = new Rocket();
            LogicObj.Broken += Rocket_Broken;
            LogicObj.Succeed += Rocket_Succeed;
            LogicObj.X = Delta * n;
            LogicObj.Y = 650;
            Astronaut = astronaut;
        }

        public void Start()
        {
            VisualElement = new Bitmap(icon, s);
            Thread rocketTread = new Thread(LogicObj.StartWork);
            rocketTread.Start();
        }

        public void Stop()
        {
            LogicObj.StopWork();
        }

        private void Rocket_Succeed(Rocket sender)
        {
            Astronaut.VisualElement = new Bitmap(Astronaut.iconSucceed, Astronaut.succ);
            VisualElement = new Bitmap(icon, s);
            Astronaut.LogicObj.DoWork(sender);
            Stop();
        }

        private void Rocket_Dead(Rocket sender)
        {
            VisualElement = new Bitmap(iconBroken, s);
            
        }
        private void Rocket_Broken(Rocket sender)
        {
            VisualElement = new Bitmap(iconBroken, s);
            Stop();
        }
    }
}
