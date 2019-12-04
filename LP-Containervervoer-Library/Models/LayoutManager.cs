using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP_Containervervoer_Library
{
    public class LayoutManager
    {
        //TODO: How to prevent 0 and negative numbers as parameters
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool EvenWidth { get; private set; }

        private List<ISeaContainer> _notPlacedContainers = new List<ISeaContainer>();
        public IEnumerable<ISeaContainer> NotPlacedContainers { get { return _notPlacedContainers; } }

        public int LeftSideWeight { get { return GetWeightFromCollection(_left); } }
        public int RightSideWeight { get { return GetWeightFromCollection(_right); } }
        public int MiddleWeight { get { return _middle.Sum(c => c.TotalWeight); } }
        public Slot[][] Layout { get { return GetCombinedLayout(); } }

        Slot[][] _left;
        Slot[][] _right;
        Slot[] _middle;

        public LayoutManager(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
            EvenWidth = width % 2 == 0;
            SetSlotsPlaces(EvenWidth);
        }

        public void GenerateLayout(List<ISeaContainer> containers)
        {
            foreach (ISeaContainer container in containers)
            {
                if (_middle != null)
                {
                    TryAddContainerToMiddle(container);
                }

                TryAddContainerToSide(container, GetSideWithLeastWeight());
                
                if (!container.Placed)
                {
                    _notPlacedContainers.Add(container);
                }
            }
        }

        private void TryAddContainerToMiddle(ISeaContainer container)
        {
            if (!container.Placed)
            {
                foreach (Slot slot in _middle)
                {
                    Slot slotInFront = _middle[slot.RelativeSlotYPosition - 1];
                    Slot slotBehind = _middle[slot.RelativeSlotYPosition + 1];
                    if (slot.CanBePlacedAtBottom(container) && CheckForSpecialRulesPlaceAtBottom(container, slot, slotInFront, slotBehind))
                    {
                        slot.PlaceAtBottom(container);
                        break;
                    }
                }
            }
            
        }

        private bool CheckForSpecialRulesPlaceAtBottom(ISeaContainer newContainer, Slot currentSlot, Slot slotInFrontOfThis, Slot slotBehindThis)
        {
            if (newContainer.Type == ContainerType.Cool)
            {
                //Cool containers may only be placed at front row.
                return IsSlotFrontRow(currentSlot);
            }
            else if (newContainer.Type == ContainerType.Valuable)
            {
                //there can only be one valuable per slot and it has to be on top.
                return (currentSlot.SeaContainers.Count() == 0) && CheckIfContainersAreInAdjecentSlots(slotInFrontOfThis, slotBehindThis);
            }
            else if (newContainer.Type == ContainerType.Standard)
            {
                CheckifContainerWillBlockValuable(currentSlot, slotInFrontOfThis, slotBehindThis);
            }

            return true;
        }

        private bool CheckifContainerWillBlockValuable(Slot currentSlot, Slot slotInFrontOfThis, Slot slotBehindThis)
        {
            bool frontSave = true;
            bool backSave = true;

            if (slotInFrontOfThis.SeaContainers.Any(c => c.Type == ContainerType.Valuable))
            {
                int indexValuableFrontSlot = slotInFrontOfThis.SeaContainers.ToList().IndexOf(slotInFrontOfThis.SeaContainers.First(c => c.Type == ContainerType.Valuable));
                frontSave = indexValuableFrontSlot < currentSlot.SeaContainers.Count();
            }

            if (slotBehindThis.SeaContainers.Any(c => c.Type == ContainerType.Valuable))
            {
                int indexValuableBackSlot = slotBehindThis.SeaContainers.ToList().IndexOf(slotBehindThis.SeaContainers.First(c => c.Type == ContainerType.Valuable));
                backSave = indexValuableBackSlot < currentSlot.SeaContainers.Count();
            }

            return frontSave && backSave;
        }

        private bool CheckIfContainersAreInAdjecentSlots(Slot slotInFrontOfthis, Slot slotBehindThis)
        {
            return (slotInFrontOfthis == null || slotInFrontOfthis.SeaContainers.Count() > 0) && (slotBehindThis == null || slotBehindThis.SeaContainers.Count() > 0);
        }

        private bool IsSlotFrontRow(Slot currentSlot)
        {
            return currentSlot.RelativeSlotYPosition == 0;
        }

        private void TryAddContainerToSide(ISeaContainer container, Slot[][] side)
        {
            foreach (Slot[] slotArray in side)
            {
                if(container.Placed)
                {
                    break;
                }

                foreach (Slot indivudualSlot in slotArray)
                {
                    if (indivudualSlot.CanBePlacedAtBottom(container))
                    {
                        indivudualSlot.PlaceAtBottom(container);
                        break;
                    }
                }
            }
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
                    _left[x][y] = new Slot(Height, x, y);

                    _right[x][y] = new Slot(Height, x, y);
                }
            }
        }

        private void FillMiddleLayout()
        {
            for(int i = 0; i < Length; i++)
            {
                _middle[i] = new Slot(Height, Width/2, i);
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
