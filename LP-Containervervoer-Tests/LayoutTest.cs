using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using System;

namespace LP_Containervervoer_Tests
{
    public class LayoutTest
    {
        private const int _defaultMaxTopLoad = 120000;
        private const int _defaultWeight = 30000;

        [Test]
        public void ReturnLayout()
        {
            int width = 5;
            int height = 4;
            int length = 6;

            LayoutManager layoutManager = new LayoutManager(length, width, height);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(width, layoutManager.Layout.Length);
                Assert.AreEqual(length, layoutManager.Layout[0].Length);
            });
        }

        [Test]
        public void OneWidthInstantiate()
        {
            int width = 1;
            int height = 1;
            int length = 1;

            LayoutManager layoutManager = new LayoutManager(length, width, height);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(width, layoutManager.Layout.Length);
                Assert.AreEqual(length, layoutManager.Layout[0].Length);
                Assert.AreEqual(height, layoutManager.Layout[0][0].MaxHeight);
            });
        }

        [Test]
        public void OneByOnePlaceAContainer()
        {
            //Arrange
            int weight = 1;
            int width = 1; 
            int lenght = 1;
            int height = 1; 
            Ship ship = new Ship(1, 1, weight, weight);
            ISeaContainer con = new SeaContainer(weight, weight, ContainerType.Standard);
            LayoutManager layMan = new LayoutManager(lenght, width, height);

            //Act
            layMan.GenerateLayout(new List<ISeaContainer>() { con });

            //Assert
            Assert.IsTrue(con.Placed);
        }

        //[Test]
        //public void ThreeValuablesCanNotBePlaced()
        //{
        //    //Arrange
        //    int length = 3;
        //    int width = 1;
        //    int height = 1;
        //    List<ISeaContainer> threeValuables = new List<ISeaContainer>() // one shoud not be able to be placed, because they can't be blocked from the front or the back. 
        //    {
        //        new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Valuable),
        //        new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Valuable),
        //        new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Valuable)
        //    };
        //    LayoutManager layout = new LayoutManager(length, width, height);

        //    //Act
        //    layout.GenerateLayout(threeValuables);
        //    int expectedNumberPlaced = threeValuables.Count - 1;
        //    int numerberPlaced = 0;

        //    foreach(ISeaContainer con in threeValuables)
        //    {
        //        if (con.Placed)
        //        {
        //            numerberPlaced++;
        //        }
        //    }
        //    //Assert
        //    Assert.AreEqual(expectedNumberPlaced, numerberPlaced);


        //}

        
    }
}