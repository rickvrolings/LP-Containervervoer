using System.Collections.Generic;

namespace LP_Containervervoer_Library
{
    public interface ISlot
    {
        public int TotalWeight { get; }
        public int RelativeSlotXPostion { get; } //relative to the section in wich the slot is containted within the layout, so left, middle or right. 
        public int RelativeSlotYPosition { get; }
        public IEnumerable<ISeaContainer> SeaContainers { get; }
    }
}
