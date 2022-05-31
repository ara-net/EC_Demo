namespace EC.Domain
{
    public class BasketDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Fee { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid BasketId { get; set; }
        public Baskets Basket { get; set; }
    }
}
