using System.ComponentModel;

namespace TrashTrack.Core
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public bool isCanceled { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<OrderDetails> OrderDetails { get; set; } = null!;
    }
}
