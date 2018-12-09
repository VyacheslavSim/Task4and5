using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using ClassLib;
using VisualLib;
using VisualLib.Elements;

namespace Task4
{
    public partial class MainWindow : Form
    {
        Graphics g;
        Bitmap bitmap;
        private VisualElementsFactory _uiFactory = new VisualElementsFactory(SynchronizationContext.Current);
        WorldUI world;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            bitmap?.Dispose();
            bitmap = world.GetBitmap();
            pictureBox.Image = bitmap;
        }
        
        private void rocketAdd_btn_Click(object sender, EventArgs e)
        {
            var rocket = _uiFactory.createRocketUI(world.RocketList.Count);
            rocket.LogicObj.Broken += world.Rocket_Broken;
            rocket.LogicObj.Succeed += world.Rocket_Succeed;
            rocket.Start();
            world.RocketList.Add(rocket);
        }

        private void agentAdd_btn_Click(object sender, EventArgs e)
        {
            AgentUI agent = new AgentUI(SynchronizationContext.Current);
            world.AgListForDrawing.Add(agent);
            world.Agents.Post(agent);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            g = pictureBox.CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            world = new WorldUI(g, bitmap, ClientRectangle);
            updateTimer.Start();
            Thread payFactoryThread = new Thread(world.PayFactory);
            payFactoryThread.Start();
        }
    }
}
