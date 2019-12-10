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
            Console.WriteLine(" ");

            Ship ship = new Ship(1, 5, 4, 6000000);
            DisplayShipInformation(ship);
            Console.WriteLine("Loading Ship...");
            ship.LoadShip(FillerDataOne());

            Console.WriteLine("Loading complete:");
            DisplayShipInformation(ship);
            DisplayLayout(ship.Layout);
            DisplayNonPlacedContainers(ship.NotPlacedContainers);
            Console.ReadLine();
        }

        static void DisplayShipInformation(Ship ship)
        {
            Console.WriteLine("Ship information:");
            Console.WriteLine($"Is Ship Sailable: {ship.Sailable}");
            Console.WriteLine($"Reason: {ship.Reason}");
            Console.WriteLine("");
        }

        static void DisplayLayout(Slot[][] layout)
        {;
            for (int x = 0; x < layout.Length; x++)
            {
                Console.WriteLine("---------------------------------------");
                for (int y = 0; y < layout[x].Length; y++)
                {
                    Console.WriteLine("Slot postition: " + x.ToString() + ", " + y.ToString() + $" , relative: {layout[x][y].RelativeSlotXPostion}, {layout[x][y].RelativeSlotYPosition}");
                    for (int c = layout[x][y].SeaContainers.Count() - 1; c >= 0; c--)
                    {
                        Console.WriteLine(layout[x][y].SeaContainers.ToList()[c]);
                    }
                    Console.WriteLine("");
                }
            }
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
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard)
            };

            return returnList;
        }

        static List<ISeaContainer> FillerDataValuabe()
        {
            List<ISeaContainer> returnList = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Valuable),
            };

            return returnList;
        }

        static List<ISeaContainer> FillerDataCool()
        {
            List<ISeaContainer> returnList = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Cool)
            };

            return returnList;
        }

        static List<ISeaContainer> FillerDataStandard()
        {
            List<ISeaContainer> returnList = new List<ISeaContainer>()
            {
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),
                new SeaContainer(_defaultWeight, _defaultTopLoad, ContainerType.Standard),

            };

            return returnList;
        }

    }
}
