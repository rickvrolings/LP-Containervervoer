using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models.Interfaces
{
    public interface ISeaContainer
    {
        int MaxTopLoad { get; }
        int Weight { get; }
        bool Placed { get; set; }
    }
}
