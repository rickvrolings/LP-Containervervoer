using System.Collections.Generic;
using System.Linq;

namespace LP_Containervervoer_Library
{ 
    public class Slot // The word "Stack" was taken in C#. A slot is an available place to stack containers.
    {
        public int MaxHeight { get; private set; }
        public int TotalWeight => _seaContainers.Sum(c => c.Weight);
        private readonly List<ISeaContainer> _seaContainers;
        public int RelativeSlotXPostion { get; private set; } //relative to the section in wich the slot is containted within the layout, so left, middle or right. 
        public int RelativeSlotYPosition { get; private set; }
        public IEnumerable<ISeaContainer> SeaContainers { get { return _seaContainers; } }
        
        public Slot(int height, int xPosition, int yPosition)
        {
            _seaContainers = new List<ISeaContainer>();
            RelativeSlotXPostion = xPosition;
            RelativeSlotYPosition = yPosition;
            MaxHeight = height;
        }

        // ----- Function below is outdated ----
        //public void PlaceOnTop(ISeaContainer container)
        //{
        //    if (CanBePlacedOnTop(container))
        //    {
        //        _seaContainers.Add(container);
        //        container.Placed = true;
        //    }
        //}

        public void PlaceAtBottom(ISeaContainer container)
        {
            if (CanBePlacedAtBottom(container))
            {
                _seaContainers.Insert(0, container);
                container.Placed = true;
            }
        }


        // ----- Function below is outdated ----
        //public bool CanBePlacedOnTop(ISeaContainer newContainer)
        //{
        //    if (!CheckHeightLimit() || _seaContainers.FindLast(c => c.Type == ContainerType.Valuable) != null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < _seaContainers.Count; i++)
        //        {
        //            if (newContainer.Weight + CalculateTopLoadFromIndex(i) > _seaContainers[i].MaxTopLoad)
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //}

        public bool CanBePlacedAtBottom(ISeaContainer newContainer)
        {
            return CheckTopLoadFromBottom(newContainer) && CheckHeightLimit();
        }



        private bool CheckTopLoadFromBottom(ISeaContainer container)
        {
            return TotalWeight <= container.MaxTopLoad;
        }

        private int CalculateTopLoadFromIndex(int index)
        {
            int TopLoad = 0; 
            for (int x = index + 1; x < _seaContainers.Count; x++)
            {
                TopLoad += _seaContainers[x].Weight;
            }
            return TopLoad;
        }

        private bool CheckHeightLimit()
        {
            return _seaContainers.Count < MaxHeight;
        }
    }
}
