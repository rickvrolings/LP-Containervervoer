namespace LP_Containervervoer_Library 
{ 
    public class SeaContainer : ISeaContainer
    {
        public int countTest { get; set; }
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

        public override string ToString()
        {
            return $"Id: {this.countTest}, Type: {this.Type}. Weight: {this.Weight}. MaxTopLoad: {this.MaxTopLoad}. Placed: {this.Placed}.";
        }
    }
}
