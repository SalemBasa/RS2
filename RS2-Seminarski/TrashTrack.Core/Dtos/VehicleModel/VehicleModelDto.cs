namespace TrashTrack.Core
{
    public class VehicleModelDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public VehicleType VehicleType { get; set; }
    }
}
