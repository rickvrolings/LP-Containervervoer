using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using LP_Containervervoer_Library.Models;
using LP_Containervervoer_Library.Models.Interfaces;
using System;

namespace LP_Containervervoer_Tests
{
    public class SlotTests
    {
        private const int _defaultMaxTopLoad = 120000;
        private const int _defaultWeight = 30000;

        List<ISeaContainer> _containers;

        [SetUp]
        public void ResetContainerList()
        {
            _containers = new List<ISeaContainer>()
            {
                new CoolContainer(_defaultWeight, _defaultMaxTopLoad),
                new StandardContainer(_defaultWeight, _defaultMaxTopLoad),
                new ValuableContainer(_defaultWeight, _defaultMaxTopLoad)
            };
        }


        [Test]
        public void PlaceOnTop()
        {
            //Arrange
            Slot slot = new Slot(_containers.Count);
            //Act
            for(int i = 0; i < _containers.Count; i++)
            {
                slot.PlaceOnTop(_containers[i]);
            }

            List<ISeaContainer> result = new List<ISeaContainer>(slot.SeaContainers);

            //Assert
            Assert.Multiple(() =>
            {
                for(int i = 0; i < _containers.Count; i++)
                {
                    Assert.AreEqual(_containers[i], result[i]);
                }
            });
        }

        [Test]
        public void PlaceAtBottom()
        {
            //Arrange
            Slot slot = new Slot(_containers.Count);

            List<ISeaContainer> expectedResult = new List<ISeaContainer>();
            for (int i = _containers.Count - 1; i >= 0; i--)
            {
                expectedResult.Add(_containers[i]);
            }

            //Act
            for (int i = 0; i < _containers.Count; i++)
            {
                slot.PlaceAtBottom(_containers[i]);
            }

            List<ISeaContainer> result = new List<ISeaContainer>(slot.SeaContainers);

            //Assert
            Assert.Multiple(() =>
            {
                for (int i = 0; i < _containers.Count; i++)
                {
                    Assert.AreEqual(expectedResult[i], result[i]);
                }
            });
        }

        [Test]
        public void CheckForHeightLimitRestriction()
        {
            //Arrange
            Slot slot = new Slot(_containers.Count - 1);
            for(int i = 0; i < _containers.Count - 1; i++)
            {
                slot.PlaceOnTop(_containers[i]);
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(slot.CanBePlacedAtBottom(_containers[_containers.Count - 1]));
                Assert.IsFalse(slot.CanBePlacedOnTop(_containers[_containers.Count - 1]));
            });
        }

        [Test]
        public void CheckForTopLoadLimit()
        {
            //Arrange
            Random rnd = new Random();
            int weight = rnd.Next(1, 9999); //some random value, as the function should work with any input.
            Slot slot = new Slot(99); //write high value to height limit because we assert the top load value in this function.
            ISeaContainer sContainer1 = new StandardContainer(weight, weight);
            ISeaContainer sContainer2 = new StandardContainer(weight + 1, weight - 1);
            ISeaContainer sContainer3 = new StandardContainer(weight - 1, weight + 1);

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
    }
}