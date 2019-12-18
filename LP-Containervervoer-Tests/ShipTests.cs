using NUnit.Framework;
using System.Collections.Generic;
using LP_Containervervoer_Library;
using System.Linq;
using System;

namespace LP_Containervervoer_Tests
{
    public class ShipTests
    {
        int _okLength = 5;
        int _okWidth = 5;
        int _containerWeight = 5000;
        int _someHighNumber = 100;

        [Test]
        public void InstantiateShip()
        {
            //Arrange
            int wrongLength = 0;
            int wrongWidth = 0;

            //Act
            Ship goodShip = new Ship(_okWidth, _okLength);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Catch(() => { Ship ship = new Ship(wrongWidth, wrongLength); });

                Assert.AreEqual(_okLength, goodShip.Length);
                Assert.AreEqual(_okWidth, goodShip.Width);
            });
        }

        [Test]
        public void CorrectNumberOfSlots()
        {
            //Arrange
            int expected = _okWidth * _okLength;

            //Act
            Ship ship = new Ship(_okWidth, _okLength);

            //Assert
            Assert.AreEqual(expected, ship.Layout.Count());
        }

        [Test]
        public void CoolContainerOnlyInFrontRow()
        {
            //Arrange
            ISeaContainer coolContainer = new SeaContainer(_containerWeight, ContainerType.Cool);
            Ship ship = new Ship(1, 2);
            List<ISeaContainer> containers = new List<ISeaContainer>()
            {
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard),
                coolContainer
            };

            //Act
            ship.Load(containers);
            ISlot slotContainingCoolContainer = ship.Layout.First(slot => slot.SeaContainers.Any(c => c.Type == ContainerType.Cool));

            //Assert
            Assert.IsTrue(slotContainingCoolContainer.YPosition == 0);
        }

        [Test]
        public void ValuableContainerOnlyOnTop()
        {
            List<ISeaContainer> containers = new List<ISeaContainer>();
            for (int i = 0; i < _someHighNumber; i++)
            {
                containers.Add(new SeaContainer(_containerWeight, ContainerType.Valuable));
            }

            for (int i = 0; i < _someHighNumber; i++)
            {
                containers.Add(new SeaContainer(_containerWeight, ContainerType.Standard));
            }

            Ship ship = new Ship(_okWidth, _okLength);
            ship.Load(containers);

            Assert.Multiple(() =>
            {
                foreach (ISlot slot in ship.Layout)
                {
                    if (slot.SeaContainers.Any(c => c.Type == ContainerType.Valuable))
                    {
                        int indexOfValuable = slot.SeaContainers.ToList()
                                                .IndexOf(slot.SeaContainers.ToList()
                                                .Where(c => c.Type == ContainerType.Valuable)
                                                .FirstOrDefault());

                        int heigthOfSlot = slot.SeaContainers.Count();

                        Assert.AreEqual(heigthOfSlot, indexOfValuable + 1);
                    }
                }
            });
        }

        [Test]
        public void PlaceFiveContainers()
        {
            int NumberOfContainers = 5;
            List<ISeaContainer> seaContainers = new List<ISeaContainer>();
            for (int i = 0; i < NumberOfContainers; i++)
            {
                seaContainers.Add(new SeaContainer(_containerWeight, ContainerType.Standard));
            }

            Ship ship = new Ship(_okWidth, _okLength);
            ship.Load(seaContainers);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(NumberOfContainers, CountPlacedContainersByProperty(seaContainers));
                Assert.AreEqual(NumberOfContainers, CountAmountOfContainersInSlots(ship.Layout));
            });
        }

        [Test]
        public void TwoValuablesCanNotBePlacedOnTopOfEachOther()
        {
            int expectedNumberOfPlaced = 1;

            List<ISeaContainer> valuables = new List<ISeaContainer>()
            {
                new SeaContainer(_containerWeight, ContainerType.Valuable),
                new SeaContainer(_containerWeight, ContainerType.Valuable)
            };

            Ship ship = new Ship(1, 1);
            ship.Load(valuables);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedNumberOfPlaced, CountAmountOfContainersInSlots(ship.Layout));
                Assert.AreEqual(expectedNumberOfPlaced, CountPlacedContainersByProperty(valuables));
            });
        }

        [Test]
        public void ThreeValuableCanNotBePlacedInFrontEachOther()
        {
            int numberOfValubles = 3;
            int expectedNumberOfPlacedValuables = 2;

            List<ISeaContainer> valuables = new List<ISeaContainer>();
            for(int i = 0; i < numberOfValubles; i++)
            {
                valuables.Add(new SeaContainer(_containerWeight, ContainerType.Valuable));
            }

            Ship ship = new Ship(1, numberOfValubles);

            ship.Load(valuables);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedNumberOfPlacedValuables, CountPlacedContainersByProperty(valuables));
                Assert.AreEqual(expectedNumberOfPlacedValuables, CountAmountOfContainersInSlots(ship.Layout));
            });
        }

        [Test]
        public void RunLoadFunctionTwoTimes()
        {
            List<ISeaContainer> firstSeaContainers = new List<ISeaContainer>()
            {
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard)
            };
            List<ISeaContainer> secondSeaContainers = new List<ISeaContainer>() 
            {
                new SeaContainer(_containerWeight, ContainerType.Standard),
                new SeaContainer(_containerWeight, ContainerType.Standard)
            };

            Ship ship = new Ship(_okWidth, _okLength);
            ship.Load(firstSeaContainers);
            ship.Load(secondSeaContainers);

            List<ISeaContainer> combinedList = new List<ISeaContainer>();
            combinedList.AddRange(firstSeaContainers);
            combinedList.AddRange(secondSeaContainers);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(combinedList.Count(), CountPlacedContainersByProperty(combinedList));
                Assert.AreEqual(combinedList.Count(), CountAmountOfContainersInSlots(ship.Layout));
            });
        }

        private int CountAmountOfContainersInSlots(IEnumerable<ISlot> slots)
        {
            int numberOfPlacedByCountingContainersInSlots = 0;
            foreach (ISlot slot in slots)
            {
                foreach (ISeaContainer cont in slot.SeaContainers)
                {
                    numberOfPlacedByCountingContainersInSlots++;
                }
            }
            return numberOfPlacedByCountingContainersInSlots;
        }

        private int CountPlacedContainersByProperty(IEnumerable<ISeaContainer> containers)
        {
            int returnValue = 0;
            foreach (ISeaContainer cont in containers)
            {
                if (cont.Placed)
                {
                    returnValue++;
                }
            }
            return returnValue;
        }

    }
}