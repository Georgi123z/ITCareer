﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Models.Units
{
    class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int Attack = 10; 
        public Horseman() : base(DefaultHealth, Attack)
        {
        }
    }
}
