using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP_Containervervoer_Library
{
    internal class LayoutManager
    {
        //TODO: How to prevent 0 and negative numbers as parameters
        public int Length { get; private set; }
        public int Width { get; private set; }

        public int TotalMaxLoad { get { return Length * Width * 150000; } } //Got feedback that TotalMaxLoad doesn't have to be a set by user input. Max load per Slot = 150000
        public int TotalMinLoad { get { return TotalMaxLoad / 2; } }

        private bool EvenWidth { get; set; }

        private List<ISeaContainer> _notPlacedContainers = new List<ISeaContainer>();
        public IEnumerable<ISeaContainer> NotPlacedContainers { get { return _notPlacedContainers; } }

        public int LeftSideWeight { get { return GetWeightFromCollection(_left); } }
        public int MiddleWeight { get { return _middle.Sum(c => c.TotalWeight); } }
        public int RightSideWeight { get { return GetWeightFromCollection(_right); } }
        public int TotalWeight { get { return GetWeightFromCollection(Layout); } }

        public Slot[][] Layout { get { return GetCombinedLayout(); } }

        Slot[][] _left;
        Slot[][] _right;
        Slot[] _middle;

        public LayoutManager(int length, int width)
        {
            if(width < 1 || length < 1)
            {
                throw new ArgumentException("One of the dimensions is lower than 1", "length");
            }
            else
            {
                Length = length;
                Width = width;
                EvenWidth = width % 2 == 0;
                SetSlotsPlaces(EvenWidth);
            }
        }

        public void FillLayout(List<ISeaContainer> containers)
        {
            foreach (ISeaContainer container in containers.OrderBy(c => c.Type).ThenByDescending(c => c.Weight))
            {
                if(!TryAddContainer(container))
                { 
                    _notPlacedContainers.Add(container);
                }
            }
        }

        private bool TryAddContainer(ISeaContainer container)
        {
            if (!EvenWidth)
            {
                TryAddContainerToMiddle(container);
            }

            if (container.Placed == false && Width > 1)
            {
                TryAddContainerToSide(container, GetSideWithLeastWeight());
            }

            return container.Placed;
        }

        private void TryAddContainerToMiddle(ISeaContainer container)
        {
            TryAddContainerToEachSlotInCollection(container, _middle);
        }

        private void TryAddContainerToSide(ISeaContainer container, Slot[][] side)
        {
            foreach (Slot[] slotArray in side)
            {
                TryAddContainerToEachSlotInCollection(container, slotArray);
            }
        }

        private void TryAddContainerToEachSlotInCollection(ISeaContainer container, Slot[] colomn)
        {
            foreach (Slot indivudualSlot in colomn)
            {
                if (indivudualSlot.CanBePlacedAtBottom(container) && CheckForSpecialRulesPlaceAtBottom(container, indivudualSlot) 
                    && CheckValuablesWontBeBlockedTwoWays(container, indivudualSlot, colomn))
                {
                    indivudualSlot.PlaceAtBottom(container);
                    break;
                }
            }
        }

        private bool CheckValuablesWontBeBlockedTwoWays(ISeaContainer container, Slot currentSlot, Slot[] colomn)
        {
            if (currentSlot.RelativeSlotYPosition >= 2)
            {
                if (colomn[currentSlot.RelativeSlotYPosition - 1].SeaContainers.Any(c => c.Type == ContainerType.Valuable))
                {
                    return CompareValuableSlotForBlocking(currentSlot, colomn[currentSlot.RelativeSlotYPosition - 1], colomn[currentSlot.RelativeSlotYPosition - 2]);
                }
            }

            if(currentSlot.RelativeSlotYPosition <= Length - 3)
            {
                if (colomn[currentSlot.RelativeSlotYPosition + 1].SeaContainers.Any(c => c.Type == ContainerType.Valuable))
                {
                    return CompareValuableSlotForBlocking(currentSlot, colomn[currentSlot.RelativeSlotYPosition + 1], colomn[currentSlot.RelativeSlotYPosition + 2]);
                }
            }
            return true;
        }

        private bool CompareValuableSlotForBlocking(Slot currentSlot, Slot valuableSlot, Slot blockingSlot)
        {
            int indexValuableContainer = valuableSlot.SeaContainers.ToList().IndexOf(valuableSlot.SeaContainers.First(c => c.Type == ContainerType.Valuable));
            return indexValuableContainer >= blockingSlot.SeaContainers.Count() || indexValuableContainer >= currentSlot.SeaContainers.Count() + 1;
        }

        private bool CheckForSpecialRulesPlaceAtBottom(ISeaContainer container, Slot slot)
        {
            if(container.Type == ContainerType.Cool)
            {
                return IsSlotFrontRow(slot); //Cool container can only be placed at front row
            }
            else if(container.Type == ContainerType.Valuable)
            {
                return slot.SeaContainers.Count() == 0; // there can only be one valuable per slot. 
            }
            else
            {
                return true;
            }
        }

        private bool IsSlotFrontRow(Slot currentSlot)
        {
            return currentSlot.RelativeSlotYPosition == 0;
        }

        private Slot[][] GetSideWithLeastWeight()
        {
            return LeftSideWeight <= RightSideWeight ? _left : _right;
        }

        private Slot[][] GetCombinedLayout()
        {
            if(Width > 1)
            {
                return CombineLayouts(EvenWidth);
            } 
            else 
            {
                return MiddleAsLayout();
            }
        }

        private Slot[][] MiddleAsLayout()
        {
            Slot[][] combined = GetEmptyFullLayout();
            _middle.CopyTo(combined[0], 0);
            return combined;
        }

        private int GetWeightFromCollection(Slot[][] side)
        {
            if(side != null)
            {
                int returnWeight = 0;
                foreach (Slot[] slotArray in side)
                {
                    foreach (Slot slot in slotArray)
                    {
                        returnWeight += slot.TotalWeight;
                    }
                }
                return returnWeight;
            }
            else
            {
                return 0;
            }
        }

        private Slot[][] CombineLayouts(bool even)
        {
            Slot[][] combined = GetEmptyFullLayout();

            _left.CopyTo(combined, 0);

            if (even)
            {
                _right.CopyTo(combined, Width / 2);
            }
            else
            {
                _middle.CopyTo(combined[(Width - 1) / 2], 0);
                _right.CopyTo(combined, Width / 2 + 1);
            }            

            return combined;
        }

        private Slot[][] GetEmptyFullLayout()
        {
            Slot[][] returnLayout = new Slot[Width][];

            for (int i = 0; i < Width; i++)
            {
                returnLayout[i] = new Slot[Length];
            }
            return returnLayout;
        } 

        private void FillLeftRightLayout()
        {
            for (int x = 0; x < Width / 2; x++)
            {
                _left[x] = new Slot[Length];
                _right[x] = new Slot[Length];

                for(int y = 0; y < Length; y++)
                {
                    _left[x][y] = new Slot(x, y);

                    _right[x][y] = new Slot(x, y);
                }
            }
        }

        private void FillMiddleLayout()
        {
            for(int i = 0; i < Length; i++)
            {
                _middle[i] = new Slot(Width/2, i);
            }
        }

        private void SetSlotsPlaces(bool evenWidth)
        {
            if (!evenWidth)
            {
                _middle = new Slot[Length];
                FillMiddleLayout();
            }

            if (Width > 1)
            {
                _left = new Slot[Width / 2][];
                _right = new Slot[Width / 2][];
                FillLeftRightLayout();
            } 
        }
    }
}
