using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using System;

namespace LP_Containervervoer_Tests
{
    public class SlotTests
    {
        private const int _defaultWeight = 30000;

        List<ISeaContainer> _containersStandard;

        [SetUp]
        public void ResetContainerList()
        {
            _containersStandard = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard)
            };
        }
        
        [Test]
        public void PlaceAtBottom()
        {
            //Arrange
            Slot slot = new Slot(0, 0);

            List<ISeaContainer> expectedResult = new List<ISeaContainer>();
            for (int i = _containersStandard.Count - 1; i >= 0; i--)
            {
                expectedResult.Add(_containersStandard[i]);
            }

            //Act
            for (int i = 0; i < _containersStandard.Count; i++)
            {
                slot.PlaceAtBottom(_containersStandard[i]);
            }

            List<ISeaContainer> result = new List<ISeaContainer>(slot.SeaContainers);

            //Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < _containersStandard.Count; i++)
                {
                    Assert.AreEqual(expectedResult[i], result[i]);
                }
            });
        }

        [Test]
        public void CheckForTopLoadLimit()
        {
            //Arrange
            Slot slot = new Slot(0, 0); //write high value to height limit because we assert the top load value in this function.
            ISeaContainer sContainer1 = new SeaContainer(_defaultWeight, ContainerType.Standard);
            ISeaContainer sContainer2 = new SeaContainer(_defaultWeight, ContainerType.Standard);
            ISeaContainer sContainer3 = new SeaContainer(_defaultWeight, ContainerType.Standard);
            ISeaContainer sContainer4 = new SeaContainer(_defaultWeight, ContainerType.Standard);
            ISeaContainer sContainer5 = new SeaContainer(_defaultWeight, ContainerType.Standard);
            ISeaContainer sContainer6 = new SeaContainer(_defaultWeight, ContainerType.Standard);



            //Act
            slot.PlaceAtBottom(sContainer1);
            slot.PlaceAtBottom(sContainer2);
            slot.PlaceAtBottom(sContainer3);
            slot.PlaceAtBottom(sContainer4);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(slot.CanBePlacedAtBottom(sContainer5));
                slot.PlaceAtBottom(sContainer5);
                Assert.IsFalse(slot.CanBePlacedAtBottom(sContainer6));
            });

        }

        [Test]
        public void TotalWeight()
        {
            //Arrange
            Slot slot = new Slot(0, 0);
            slot.PlaceAtBottom(new SeaContainer(_defaultWeight, ContainerType.Standard));
            slot.PlaceAtBottom(new SeaContainer(_defaultWeight, ContainerType.Standard));
            slot.PlaceAtBottom(new SeaContainer(_defaultWeight, ContainerType.Standard));

            //Act
            int result = slot.TotalWeight;
            int expected = _defaultWeight * 3;

            //Assert
            Assert.AreEqual(expected, result);
        }

        

    }
}