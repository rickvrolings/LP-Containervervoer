using System.Collections.Generic;
using System.Linq;

namespace LP_Containervervoer_Library
{ 
    public class Slot : ISlot // The word "Stack" was taken in C#. A slot is an available place to stack containers.
    {
        public int TotalWeight { get { return _seaContainers.Sum(c => c.Weight); } }
        private readonly List<ISeaContainer> _seaContainers;
        public int XPostion { get; private set; } //relative to the section in wich the slot is containted within the layout, so left, middle or right. 
        public int YPosition { get; private set; }
        public IEnumerable<ISeaContainer> SeaContainers { get { return _seaContainers; } }

        public Slot(int xPosition, int yPosition)
        {
            _seaContainers = new List<ISeaContainer>();
            XPostion = xPosition;
            YPosition = yPosition;
        }

        public void PlaceAtBottom(ISeaContainer container)
        {
            if (CanBePlacedAtBottom(container))
            {
                _seaContainers.Insert(0, container);
                container.Placed = true;
            }
        }

        public bool CanBePlacedAtBottom(ISeaContainer newContainer)
        {
            return CheckTopLoadFromBottom(newContainer);
        }

        private bool CheckTopLoadFromBottom(ISeaContainer container)
        {
            return TotalWeight <= container.MaxTopLoad;
        }
    }
}
