using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using System;

namespace LP_Containervervoer_Tests
{
    public class SlotTests
    {
        private const int _defaultMaxTopLoad = 120000;
        private const int _defaultWeight = 30000;

        List<ISeaContainer> _containersStandard;

        [SetUp]
        public void ResetContainerList()
        {
            _containersStandard = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultMaxTopLoad, ContainerType.Standard)
            };
        }


        [Test]
        public void PlaceOnTop()
        {
            //Arrange
            Slot slot = new Slot(_containersStandard.Count);
            //Act
            for (int i = 0; i < _containersStandard.Count; i++)
            {
                slot.PlaceOnTop(_containersStandard[i]);
            }

            List<ISeaContainer> result = new List<ISeaContainer>(slot.SeaContainers);

            //Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < _containersStandard.Count; i++)
                {
                    Assert.AreEqual(_containersStandard[i], result[i]);
                }
            });
        }

        [Test]
        public void PlaceAtBottom()
        {
            //Arrange
            Slot slot = new Slot(_containersStandard.Count);

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
        public void CheckForHeightLimitRestriction()
        {
            //Arrange
            Slot slot = new Slot(_containersStandard.Count - 1);
            for (int i = 0; i < _containersStandard.Count - 1; i++)
            {
                slot.PlaceOnTop(_containersStandard[i]);
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(slot.CanBePlacedAtBottom(_containersStandard[_containersStandard.Count - 1]));
                Assert.IsFalse(slot.CanBePlacedOnTop(_containersStandard[_containersStandard.Count - 1]));
            });
        }

        [Test]
        public void CheckForTopLoadLimit()
        {
            //Arrange
            Random rnd = new Random();
            int weight = rnd.Next(1, 9999); //some random value, as the function should work with any input.
            Slot slot = new Slot(99); //write high value to height limit because we assert the top load value in this function.
            ISeaContainer sContainer1 = new SeaContainer(weight, weight, ContainerType.Standard);
            ISeaContainer sContainer2 = new SeaContainer(weight + 1, weight - 1, ContainerType.Standard);
            ISeaContainer sContainer3 = new SeaContainer(weight - 1, weight + 1, ContainerType.Standard);

            //Act
            slot.PlaceOnTop(sContainer1);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(slot.CanBePlacedOnTop(sContainer2));
                Assert.IsFalse(slot.CanBePlacedAtBottom(sContainer2));

                Assert.IsTrue(slot.CanBePlacedOnTop(sContainer3));
                Assert.IsTrue(slot.CanBePlacedAtBottom(sContainer3));
            });

        }

        [Test]
        public void TotalWeight()
        {
            //Arrange
            int weight = 1000;
            Slot slot = new Slot(3);
            slot.PlaceAtBottom(new SeaContainer(weight, weight * 3, ContainerType.Standard));
            slot.PlaceOnTop(new SeaContainer(weight, weight * 3, ContainerType.Standard));
            slot.PlaceAtBottom(new SeaContainer(weight, weight * 3, ContainerType.Standard));

            //Act
            int result = slot.TotalWeight;
            int expected = weight * 3;

            //Assert
            Assert.AreEqual(expected, result);
        }

        

    }
}