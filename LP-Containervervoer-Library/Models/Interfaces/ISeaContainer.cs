using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models.Interfaces
{
    public interface ISeacontainer
    {
        int MaxTopLoad { get; }
        int MinWeight { get; }
        int MaxWeight { get; }
        int Weight { get; }
        bool Placed { get; }
    }
}
