using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LP_Containervervoer_Library.Models.Interfaces;

namespace LP_Containervervoer_Library.Models
{
    public class Slot // The word "Stack" was taken in C#. A slot is an available place to stack containers.
    {
        public int MaxHeight { get; private set; }
        private readonly List<ISeacontainer> _seaContainers;
        public IEnumerable<ISeacontainer> Seacontainers { get { return _seaContainers; } }
        public int TotalWeight => _seaContainers.Sum(c => c.Weight);

        public Slot(int height)
        {
            _seaContainers = new List<ISeacontainer>();
            MaxHeight = height;
        }

        public void PlaceOnTop(ISeacontainer container)
        {
            if (CanBePlacedOnTop(container))
            {
                _seaContainers.Add(container);
            }
        }

        public void PlaceAtBottom(ISeacontainer container)
        {
            if (CanBePlacedAtBottom(container))
            {
                _seaContainers.Insert(0, container);
            }
        }

        public bool CanBePlacedOnTop(ISeacontainer newContainer)
        {
            if (!CheckHeightLimit())
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

        public bool CanBePlacedAtBottom(ISeacontainer newContainer)
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
