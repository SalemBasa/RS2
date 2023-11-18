namespace TrashTrack.Core
{
    public class OrderDto : BaseDto
    {
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public bool isCanceled { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; } = null!;
        
        public ICollection<OrderDetailsDto> OrderDetails { get; set; } = null!;
    }
}
