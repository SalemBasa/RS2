namespace TrashTrack.Core
{
    public class GarbageDto : BaseDto
    {
        public string Address { get; set; } = null!;
        public GarbageType GarbageType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Occupancy { get; set; }
    }
}
