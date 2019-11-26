﻿using LP_Containervervoer_Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models
{
    public class ValuableContainer : ISeaContainer
    {
        public int MaxTopLoad { get; private set; }
        public int Weight { get; private set; }
        public bool Placed { get; set; }

        public ValuableContainer(int weight, int maxTopLoad)
        {
            MaxTopLoad = maxTopLoad;
            Weight = weight;
            Placed = false;
        }
    }
}
