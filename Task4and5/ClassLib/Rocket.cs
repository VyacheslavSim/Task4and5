using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Abstract;

namespace ClassLib
{
    public class Rocket : Item
    {
        public delegate void RocketEventHandler(Rocket sender);
        public event RocketEventHandler Broken;
       
        public event RocketEventHandler Succeed;
        public bool IsWorking { get; set; }
        private readonly double _brokeChance = 0.02;
        private readonly Random _rnd = new Random();
        private static object lockObj = new object();


        public void StartWork()
        {
            IsWorking = true;
            while (IsWorking)
            {
                Y -= 10;
                if (Y <= 100)
                {
                    Succeed?.Invoke(this);
                    SignalizeAboutSuccess(TimeSpan.FromSeconds(3));
                    return;
                }
                if (_rnd.NextDouble() <= _brokeChance && !IsBroken)
                {
                    IsBroken = true;
                    Broken?.Invoke(this);
                    return;
                }
                Thread.Sleep(200);
            }

        }

        public void StopWork()
        {
            IsWorking = false;
        }

        public override void RecieveMoneyForInsurance(TimeSpan time)
        {
            lock (lockObj)
            {
                Thread.Sleep(time);
                Broken?.Invoke(this);
                StopWork();
            }
            
        }

        public void SignalizeAboutSuccess(TimeSpan time)
        {
           
                Thread.Sleep(time);
                Succeed?.Invoke(this);
                StopWork();
            
           
        }
    }
}
