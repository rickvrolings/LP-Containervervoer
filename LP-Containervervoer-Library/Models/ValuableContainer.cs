using LP_Containervervoer_Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models
{
    class ValuableContainer : ISeacontainer
    {
        public int MaxTopLoad { get; private set; }
        public int MinWeight { get; private set; }
        public int MaxWeight { get; private set; }
        public int Weight { get; private set; }
        public bool Placed { get; set; }

        public ValuableContainer(int maxTopLoad, int minWeight, int maxWeight, int weight)
        {
            MaxTopLoad = maxTopLoad;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            Weight = weight;
            Placed = false;
        }
    }
}
