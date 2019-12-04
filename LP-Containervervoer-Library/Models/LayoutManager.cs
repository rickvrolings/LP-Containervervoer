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
                    if (slot.CanBePlacedAtBottom(container) && CheckIfContainerWillBlockValuable(slot) && CheckForSpecialRulesPlaceAtBottom(container, slot))
                    {
                        slot.PlaceAtBottom(container);
                        break;
                    }
                }
            }
            
        }

        private bool CheckForSpecialRulesPlaceAtBottom(ISeaContainer container, Slot slot)
        {
            if(container.Type == ContainerType.Cool)
            {
                return IsSlotFrontRow(slot); //Cool container can only be placed at front row
            }
            else if(container.Type == ContainerType.Valuable)
            {
                return slot.SeaContainers.Count() == 0 && CheckForAdjecentContainersPlaceAtBottom(slot);
            }
            else
            {
                return true;
            }

        }

        private bool CheckForAdjecentContainersPlaceAtBottom(Slot slot)
        {
            bool anyAdjecent = false;
            if (slot.RelativeSlotYPosition > 0)
            {
                if(Layout[slot.RelativeSlotXPostion][slot.RelativeSlotYPosition - 1].SeaContainers.Count() > 0)
                {
                    anyAdjecent = true;
                }
            }

            if (slot.RelativeSlotYPosition < Length - 2)
            {
                if (Layout[slot.RelativeSlotXPostion][slot.RelativeSlotYPosition + 1].SeaContainers.Count() > 0)
                {
                    anyAdjecent = true;
                }
            }
            return anyAdjecent;
        }
        private bool CheckIfContainerWillBlockValuable(Slot currentSlot)
        {
            bool frontSave = true;
            bool backSave = true;

            if(currentSlot.RelativeSlotYPosition > 0)
            {
                frontSave = CompareTwoSlotsIfValuableWillBeBlocked(currentSlot, Layout[currentSlot.RelativeSlotXPostion][currentSlot.RelativeSlotYPosition - 1]);
            }

            if (currentSlot.RelativeSlotYPosition < Length - 2)
            {
                backSave = CompareTwoSlotsIfValuableWillBeBlocked(currentSlot, Layout[currentSlot.RelativeSlotXPostion][currentSlot.RelativeSlotYPosition + 1]);
            }

            return frontSave && backSave ; 
               
        }

        private bool CompareTwoSlotsIfValuableWillBeBlocked(Slot currentSlot, Slot otherSlot)
        {
            if (otherSlot.SeaContainers.Any(c => c.Type == ContainerType.Valuable))
            {
                int indexValuable = otherSlot.SeaContainers.ToList().IndexOf(otherSlot.SeaContainers.First(c => c.Type == ContainerType.Valuable));
                return indexValuable > currentSlot.SeaContainers.Count();
            }
            return true;
        }

        private bool IsSlotFrontRow(Slot currentSlot)
        {
            return currentSlot.RelativeSlotYPosition == 0;
        }

        private void TryAddContainerToSide(ISeaContainer container, Slot[][] side)
        {
            
            foreach (Slot[] slotArray in side)
            {
                if (!container.Placed)
                {
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
