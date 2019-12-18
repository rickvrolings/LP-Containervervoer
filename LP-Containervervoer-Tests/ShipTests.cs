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
            for(int i = 0; i < _someHighNumber; i++)
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
                foreach(ISlot slot in ship.Layout)
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
    }
}