using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Abstract;

namespace ClassLib
{
    public class Agent : InsurAgent
    {
        public TimeSpan TimeToGiveMoney { get; private set; } = TimeSpan.FromSeconds(3);

        public delegate void AgentEventHandler(Agent sender);
        public event AgentEventHandler IsFree;

        public static Semaphore Semaphore = new Semaphore(2, 2);
        public static int SemCount { get; private set; } = 2;

        public override void DoWork(Item target)
        {
            PayMoney(target);
        }

        private void PayMoney(Item obj)
        {
            Semaphore.WaitOne();
            obj.RecieveMoneyForInsurance(TimeToGiveMoney);
            SemCount = Semaphore.Release();
            IsFree?.Invoke(this);
        }
    }
}
