namespace LP_Containervervoer_Library.Models
{
    public class SeaContainer : ISeaContainer
    {
        public int MaxTopLoad { get; private set; }
        public int Weight { get; private set; }
        public ContainerType Type { get; private set; }
        public bool Placed { get; set; }

        public SeaContainer(int weight, int maxTopLoad, ContainerType type)
        {
            Weight = weight;
            MaxTopLoad = maxTopLoad;
            Type = type;
            Placed = false;
        }
    }
}
