using System.Collections.Generic;

namespace LP_Containervervoer_Library
{
    public interface ISlot
    {
        public int TotalWeight { get; }
        public int XPostion { get; } //relative to the section in wich the slot is containted within the layout, so left, middle or right. 
        public int YPosition { get; }
        public IEnumerable<ISeaContainer> SeaContainers { get; }
    }
}
