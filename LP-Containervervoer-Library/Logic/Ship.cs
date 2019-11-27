using LP_Containervervoer_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LP_Containervervoer_Library.Logic
{
    public class Ship
    {
        public int TotalMaxContainerWeight { get; private set; }
        public int TotalMinContainerWeight { get; private set; }
        private Layout _layout;

        public Ship(int width, int lenght, int height, int totalMaxContainerWeight)
        {
            _layout = new Layout(lenght, width, height);
            TotalMaxContainerWeight = totalMaxContainerWeight;
            TotalMinContainerWeight = totalMaxContainerWeight / 2;
        }

        public void GenerateLayout(List<ISeaContainer> inputContainers)
        {

        }


    }
}
