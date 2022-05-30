using EC.Common.Tools;

namespace EC.Common.DTO
{
    public class BasketDTO
    {
        public UnitType Unit { get; set; }
        public DateTime CreateDateEn { get; set; }
        public decimal Price => Quantity * Fee;
        public decimal Fee { get; set; }
        public DateTime StatusDateTimeEn { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string UnitType => Unit.ToUnitText();
        public Guid basketId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalPrice { get; set; }
        public string CreateDate => CreateDateEn.ToPersianDateTime();
        public string StatusDateTime => StatusDateTimeEn.ToPersianDateTime();
        public BasketStatus Status { get; set; }
    }

    public class BasketDetailDTO
    {
        public UnitType UnitType { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit => UnitType.ToUnitText();
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
