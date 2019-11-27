using System.Collections.Generic;
using System.Linq;

namespace LP_Containervervoer_Library.Models
{
    public class Slot // The word "Stack" was taken in C#. A slot is an available place to stack containers.
    {
        public int MaxHeight { get; private set; }
        public int TotalWeight => _seaContainers.Sum(c => c.Weight);
        private readonly List<ISeaContainer> _seaContainers;
        public IEnumerable<ISeaContainer> SeaContainers { get { return _seaContainers; } }
        

        public Slot(int height)
        {
            _seaContainers = new List<ISeaContainer>();
            MaxHeight = height;
        }

        public void PlaceOnTop(ISeaContainer container)
        {
            if (CanBePlacedOnTop(container))
            {
                _seaContainers.Add(container);
                container.Placed = true;
            }
        }

        public void PlaceAtBottom(ISeaContainer container)
        {
            if (CanBePlacedAtBottom(container))
            {
                _seaContainers.Insert(0, container);
                container.Placed = true;
            }
        }


        public bool CanBePlacedOnTop(ISeaContainer newContainer)
        {
            if (!CheckHeightLimit() || _seaContainers.FindLast(c => c.Type == ContainerType.Valuable) != null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < _seaContainers.Count; i++)
                {
                    if (newContainer.Weight + CalculateTopLoadFromIndex(i) > _seaContainers[i].MaxTopLoad)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool CanBePlacedAtBottom(ISeaContainer newContainer)
        {
            return TotalWeight <= newContainer.MaxTopLoad && CheckHeightLimit();
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
