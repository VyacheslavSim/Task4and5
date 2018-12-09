using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Interfaces;


namespace ClassLib.Abstract
{
    public abstract class InsurAgent : IInsuranceService
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void DoWork(Item target);
    }
}
