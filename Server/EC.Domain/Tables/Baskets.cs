using System.ComponentModel.DataAnnotations;

namespace EC.Domain.Tables
{
    public class Baskets
    {
        public Baskets()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BasketDetail> Details { get; set; }
        public ICollection<BasketHistory> History { get; set; }

    }
}
