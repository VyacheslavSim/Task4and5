﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Abstract
{
    public abstract class AstronautAbstract
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void DoWork(Item target);
    }
}
