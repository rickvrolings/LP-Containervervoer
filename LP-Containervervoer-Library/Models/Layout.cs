using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Models
{
    public class Layout
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool EvenWidth { get; private set; }

        Slot[][] Left;
        Slot[][] Right;
        Slot[] Middle;

        public Layout(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
            EvenWidth = width % 2 == 0;
            SetSlotsPlaces(EvenWidth);
        }

        public int GetWeightFromCollection(Slot[][] side)
        {
            int returnWeight = 0;
            foreach(Slot[] slotArray in side)
            {
                foreach(Slot slot in slotArray)
                {
                    returnWeight += slot.TotalWeight;
                }
            }
            return returnWeight;
        }

        private void FillLeftRightLayout()
        {
            for (int i = 0; i < Width / 2; i++)
            {
                Left[i] = new Slot[Length];
                Right[i] = new Slot[Length];

                for(int y = 0; y < Length; y++)
                {
                    Left[i][y] = new Slot(Height);
                    Right[i][y] = new Slot(Height);
                }
            }
        }

        private void FillMiddleLayout()
        {
            for(int i = 0; i < Length; i++)
            {
                Middle[i] = new Slot(Height);
            }
        }

        private void SetSlotsPlaces(bool evenWidth)
        {
            if (evenWidth)
            {
                Middle = new Slot[Length];
                FillMiddleLayout();
            }

            Left = new Slot[Width / 2][];
            Right = new Slot[Width / 2][];
            FillLeftRightLayout();
        }




    }
}
