using LP_Containervervoer_Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LP_Containervervoer_App
{
    class Program
    {
        const int _defaultWeight = 30000;
        const int _defaulShiptMaxWeight = 60000;
        const int _defaultTopLoad = 120000;
        
        static void Main(string[] args)
        {
            Console.WriteLine("This program serves no other purpuse than testing and showing how the referenced library works.");

            Ship ship = new Ship(6, 5);
            DisplayShipInformation(ship);

            Console.WriteLine("Loading Ship...");
            ship.LoadShip(FillerDataOne());
            Console.WriteLine("Loading complete:");
            DisplayShipInformation(ship);

            DisplayLayoutFromList(ship.Layout);
            DisplayNonPlacedContainers(ship.NotPlacedContainers);

            Console.ReadLine();
        }

        static void DisplayLayoutFromList(IEnumerable<ISlot> slots)
        {
            foreach(ISlot slot in slots)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"relative: {slot.RelativeSlotXPostion}, {slot.RelativeSlotYPosition}");
                List <ISeaContainer> containers = slot.SeaContainers.ToList();

                for (int i = slot.SeaContainers.Count() - 1; i >= 0; i--)
                {
                    Console.WriteLine(containers[i]);
                }
            }
            Console.WriteLine("");
        }

        static void DisplayShipInformation(Ship ship)
        {
            Console.WriteLine("Ship information:");
            Console.WriteLine($"Is Ship Sailable: {ship.Sailable}");
            Console.WriteLine($"Reason: {ship.Reason}");
            Console.WriteLine("");
        }

        static void DisplayNonPlacedContainers(IEnumerable<ISeaContainer> nonContainers)
        {
            Console.WriteLine("Here are the containers that are not placed:");
            Console.WriteLine($"Number of containers input: {FillerDataOne().Count}, Numer of containers left over: {nonContainers.Count()}");
            foreach(ISeaContainer container in nonContainers)
            {
                Console.WriteLine(container);
            }
        }

        static List<ISeaContainer> FillerDataOne()
        {
            List<ISeaContainer> returnList = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Cool),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard),
                new SeaContainer(_defaultWeight, ContainerType.Standard)
            };

            return returnList;
        }
    }
}
