namespace LP_Containervervoer_Library
{
    public interface ISeaContainer
    {
        int MaxTopLoad { get; }
        int Weight { get; }
        ContainerType Type { get; }
        bool Placed { get; set; }
    }
}
