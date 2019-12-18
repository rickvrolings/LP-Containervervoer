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

        static List<ISeaContainer> _currentInput;

        static void Main(string[] args)
        {
            _currentInput = new List<ISeaContainer>()
            {
               new SeaContainer(_defaultWeight, ContainerType.Standard)
            };

            Console.WriteLine("This program serves no other purpuse than testing and showing how the referenced library works.");

            Ship ship = new Ship(15, 1);
            DisplayShipInformation(ship);

            Console.WriteLine("Loading Ship...");
            ship.Load(_currentInput);
            Console.WriteLine("Loading complete:");
            DisplayShipInformation(ship);

            DisplayLayoutFromList(ship.Layout);
            DisplayNonPlacedContainers(ship.NotPlacedContainers);
            
            Console.ReadLine();
        }

        //static string GenerateLink(Ship ship) 
        //{
        //    //System.Diagnostics.Process.Start("http://www.google.com");

        //    string url = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html" + $"?length={ship.Length}&width={ship.Width}";
        //    string stacks = "&stacks=";
        //    string weight = "&weights=";

        //    List<ISlot> layout = ship.Layout.ToList();
        //    int lastRow = 0;
        //    foreach(ISlot slot in layout)
        //    {
        //        foreach (ISeaContainer cont in slot.SeaContainers)
        //        {
        //            if (cont.Type == ContainerType.Standard)
        //            {
        //                stacks += ",1";
        //            }else if (cont.Type == ContainerType.Valuable)
        //            {
        //                stacks += ",2";
        //            }
        //            else if(cont.Type == ContainerType.Cool)
        //            {
        //                stacks += ",3";
        //            }
        //        }
        //    }
        //    return url;
        //}


        static void DisplayLayoutFromList(IEnumerable<ISlot> slots)
        {
            foreach(ISlot slot in slots)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Position (X, Y): {slot.XPostion}, {slot.YPosition}");
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
            Console.WriteLine($"Number of containers input: {_currentInput.Count}, Numer of containers left over: {nonContainers.Count()}");
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
