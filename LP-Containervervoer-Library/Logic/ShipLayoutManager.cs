using LP_Containervervoer_Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Logic
{
    class ShipLayoutManager
    {
        public int MaxWidth { get; private set; }
        public int MaxLength { get; private set; }
        public int MaxHeight { get; private set; }
        
        public ShipLayoutManager(int width, int lenght, int height)
        {
            MaxWidth = width;
            MaxLength = lenght;
            MaxLength = height;
        }
    }
}
