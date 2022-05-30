using EC.Common.Tools;

namespace EC.Common.DTO
{
    public class statusUpdateDTO
    {
        public int UserId { get; set; }
        public Guid BasketId { get; set; }
        public BasketStatus Status { get; set; }
    }
}
