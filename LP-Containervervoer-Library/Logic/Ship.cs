using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library
{
    public class Ship
    {        
        public bool Sailable { get; private set; }
        public string Reason { get; private set; }
        public IEnumerable<ISlot> Layout { get { return Convert2DSLotArrayToIEnumerable(_layoutManager.Layout); } }
        private LayoutManager _layoutManager;

        public int Width { get; private set; }
        public int Length { get; private set; }

        public IEnumerable<ISeaContainer> NotPlacedContainers { get { return _layoutManager.NotPlacedContainers; } }

        public Ship(int width, int length)
        {
            if(width < 1 || length < 1)
            {
                throw new ArgumentException("One of the dimensions is lower than 1", "width, length");
            }
            _layoutManager = new LayoutManager(length, width);
            Width = width;
            Length = length;
            Sailable = false;
            Reason = "Ship not loaded yet";
        }

        public void Load(List<ISeaContainer> containers)
        {
            _layoutManager.FillLayout(containers);
            UpdateSailable();
        }

        private IEnumerable<ISlot> Convert2DSLotArrayToIEnumerable(ISlot[][] slots)
        {
            List<ISlot> returnIEnum = new List<ISlot>();
            foreach (ISlot[] subArray in slots)
            {
                foreach(ISlot individualSlot in subArray)
                {
                    returnIEnum.Add(individualSlot);
                }
            }
            return returnIEnum;
        }

        private void UpdateSailable()
        {
            string reasonBuilder = "";
            Sailable = true;
            double leftSidePercentage = (double)_layoutManager.LeftSideWeight / ((double)_layoutManager.LeftSideWeight + (double)_layoutManager.RightSideWeight);
            if(leftSidePercentage < 0.4 || leftSidePercentage > 0.6)
            {
                Sailable = false;
                reasonBuilder += "Ship not in balance"; 
            }

            if(_layoutManager.TotalWeight < _layoutManager.TotalMinLoad)
            {
                if(Sailable == false)
                {
                    reasonBuilder += ", ";
                }
                Sailable = false;
                reasonBuilder += "Total weight of placed containers is lower than minimum needed Weight";
            }

            if(_layoutManager.TotalWeight > _layoutManager.TotalMaxLoad)
            {
                if (Sailable == false)
                {
                    reasonBuilder += ", ";
                }
                Sailable = false;
                reasonBuilder += "Total weight of placed containers is higher than allowed maximum weight";
            }

            if (Sailable)
            {
                reasonBuilder = "Everything is in order";
            }
            reasonBuilder += ".";
            Reason = reasonBuilder;
        }

    }
}
