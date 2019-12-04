using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library
{
    public class Ship
    {
        public int TotalMaxContainerWeight { get; private set; }
        public int TotalMinContainerWeight { get { return TotalMaxContainerWeight / 2; } }
        public bool Sailable { get; private set; }
        public string Reason { get; private set; }
        public Slot[][] Layout { get { return _layoutManager.Layout; } }
        private LayoutManager _layoutManager;

        public Ship(int width, int lenght, int height, int totalMaxContainerWeight)
        {
            _layoutManager = new LayoutManager(lenght, width, height);
            TotalMaxContainerWeight = totalMaxContainerWeight;
            Sailable = false;
            Reason = "Ship not loaded yet";
        }

        public IEnumerable<ISeaContainer> NotPlacedContainers { get { return _layoutManager.NotPlacedContainers; } }

        public void LoadShip(List<ISeaContainer> containers)
        {
            _layoutManager.GenerateLayout(containers);
            UpdateSailable();
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

            if(_layoutManager.TotalWeight < TotalMinContainerWeight)
            {
                if(Sailable = false)
                {
                    reasonBuilder += ", ";
                }
                Sailable = false;
                reasonBuilder += "Total weight of placed containers is lower than minimum needed Weight";
            }

            if(_layoutManager.TotalWeight > TotalMaxContainerWeight)
            {
                if (Sailable = false)
                {
                    reasonBuilder += ", ";
                }
                Sailable = false;
                reasonBuilder += "Total weight of placed containers is higher than allowed maximum weight";
            }

            if (Sailable)
            {
                reasonBuilder += "Everything is in order";
            }
            reasonBuilder += ".";
            Reason = reasonBuilder;
        }

    }
}
