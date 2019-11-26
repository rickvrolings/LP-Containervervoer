using LP_Containervervoer_Library.Models.Interfaces;
using System;

namespace LP_Containervervoer_Library
{
    public class StandardContainer : ISeaContainer
    {
        public int MaxTopLoad { get; private set; }
        public int Weight { get; private set; }
        public bool Placed { get; set; }

        public StandardContainer(int weight, int maxTopLoad)
        {
            MaxTopLoad = maxTopLoad;
            Weight = weight;
            Placed = false;
        }
    }
}
