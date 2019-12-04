using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library
{
    public class Ship
    {
        public int TotalMaxContainerWeight { get; private set; }
        public int TotalMinContainerWeight { get; private set; }
        public bool Sailable { get; private set; }
        public string Reason { get; private set; }
        public Slot[][] Layout { get { return _layoutManager.Layout; } }
        private LayoutManager _layoutManager;

        public Ship(int width, int lenght, int height, int totalMaxContainerWeight)
        {
            _layoutManager = new LayoutManager(lenght, width, height);
            TotalMaxContainerWeight = totalMaxContainerWeight;
            TotalMinContainerWeight = totalMaxContainerWeight / 2;
        }

        public IEnumerable<ISeaContainer> NotPlacedContainers { get { return _layoutManager.NotPlacedContainers; } }

        public void LoadShip(List<ISeaContainer> containers)
        {
            _layoutManager.GenerateLayout(containers);
        }

    }
}
