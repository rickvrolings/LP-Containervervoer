namespace LP_Containervervoer_Library 
{ 
    public class SeaContainer : ISeaContainer
    {
        public int MaxTopLoad { get { return 120000; } } // given in casus
        public int Weight { get; private set; }
        public ContainerType Type { get; private set; }
        public bool Placed { get; set; }

        public SeaContainer(int weight, ContainerType type)
        {
            if(weight < 4000 || weight > 30000)
            {
                throw new System.ArgumentException("weight is either to low or to high", "weight");
            }
            else
            {
                Weight = weight;
                Type = type;
                Placed = false;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.Type}. Weight: {this.Weight}. MaxTopLoad: {this.MaxTopLoad}. Placed: {this.Placed}.";
        }
    }
}
