namespace TrashTrack.Infrastructure.Interfaces
{
    public class CountriesSearchObject : BaseSearchObject
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
