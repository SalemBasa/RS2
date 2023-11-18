namespace TrashTrack.Core
{
    public class VehicleModel : BaseEntity
    {
        public string Name { get; set; } = null!;
        public VehicleType VehicleType { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = null!;
    }
}
