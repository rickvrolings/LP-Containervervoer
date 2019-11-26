using LP_Containervervoer_Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models
{
    class CoolContainer : ISeacontainer
    {
        public int MaxTopLoad { get; private set; }
        public int MinWeight { get; private set; }
        public int MaxWeight { get; private set; }
        public int Weight { get; private set; }
        public bool Placed { get; private set; }
    }
}
