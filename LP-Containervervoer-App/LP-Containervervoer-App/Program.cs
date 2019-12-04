using LP_Containervervoer_Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LP_Containervervoer_App
{
    class Program
    {
        const int _defaultWeight = 30000;
        const int _defaultMaxWeight = 30000;
        const int _defaultTopLoad = 120000;
        const int _defaultMinWeight = 4000;
        
        static void Main(string[] args)
        {
            Console.WriteLine("This program serves no other purpuse than testing and showing how the referenced library works.");
            Ship ship = new Ship(5, 5, 4, 3000000);
            ship.LoadShip(FillerDataOne());
            DisplayLayout(ship.Layout);
            DisplayNonPlacedContainers(ship.NotPlacedContainers);
            Console.ReadLine();
        }

        static void DisplayLayout(Slot[][] layout)
        {;
            for (int x = 0; x < layout.Length; x++)
            {
                for (int y = 0; y < layout[x].Length; y++)
                {
                    Console.WriteLine("Slot postition: " + x.ToString() + ", " + y.ToString());
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
            return new List<ISeaContainer>()
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
        }

    }
}
