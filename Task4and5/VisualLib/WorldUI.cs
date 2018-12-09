using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using VisualLib.Elements;
using ClassLib;
using System.Threading;

namespace VisualLib
{
    public class WorldUI
    {
        public List<RocketUI> RocketList { get; set; } 
        public List<AgentUI> AgListForDrawing { get; set; }
        public Graphics G { get; set; }
        public Bitmap Bitmap { get; set; }
        public BufferBlock<AgentUI> Agents { get; set; }
        public Rectangle Size { get; set; }
        public WorldUI(Graphics g, Bitmap bitmap, Rectangle rect)
        {
            G = g;
            Bitmap = bitmap;
            RocketList = new List<RocketUI>();
            AgListForDrawing = new List<AgentUI>();
            Agents = new BufferBlock<AgentUI>();
            Size = rect;
        }

        public void Rocket_Broken(Rocket sender)
        {
            ThreadPool.QueueUserWorkItem(PayFactory, sender);
        }
        public void Rocket_Dead(Rocket sender)
        {
            var ui = RocketList.Find(x => x.LogicObj.Equals(sender));
            if (ui != null)
            {
                Thread.Sleep(200);
                RocketList.Remove(ui);
            }

        }

        public void Rocket_Succeed(Rocket sender)
        {
            sender.SignalizeAboutSuccess(TimeSpan.FromSeconds(2));
        }

        public async void PayFactory(object o)
        {
            while (true)
            {
                if (RocketList.Count == 0)
                    return;

                if (Agents.Count > 0)
                {
                    var r = o as Rocket;
                    var rocket = RocketList.Find(x => x.LogicObj.Equals(r));

                    var m = await Agents.ReceiveAsync();

                    if (m != null && rocket != null)
                    {

                        Thread.Sleep(1500);
                        if (RocketList.Contains(rocket))
                        {
                            m.DoWork(rocket.LogicObj);
                            Rocket_Dead(r);
                        }


                    }
                    Agents.Post(m);
                    return;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void DrawAgent(AgentUI agent)
        {
            G.DrawImage(agent.VisualElement, agent.LogicObj.X, agent.LogicObj.Y);
        }
        public void DrawRocket(RocketUI rocket)
        {
            G.DrawImage(rocket.Astronaut.VisualElement, rocket.LogicObj.X + 27, rocket.LogicObj.Y + 20);

            G.DrawImage(rocket.VisualElement, rocket.LogicObj.X, rocket.LogicObj.Y);

        }

        public Bitmap GetBitmap()
        {
            Bitmap?.Dispose();
            Bitmap = new Bitmap(Size.Width, Size.Height);
            G = Graphics.FromImage(Bitmap);
            G.Clear(Color.White);
            foreach (var item in RocketList)
            {
                DrawRocket(item);
            }
            foreach (var item in AgListForDrawing)
            {
                DrawAgent(item);
            }
            return Bitmap;
        }
    }
}
