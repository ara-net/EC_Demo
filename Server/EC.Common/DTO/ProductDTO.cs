using EC.Common.Tools;

namespace EC.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public DateTime CreateDateEn { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int CriticalQuantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool IsExist { get; set; }
        public string Unit => UnitType.ToUnitText();
        public string CreateDate => CreateDateEn.ToPersian();
        public UnitType UnitType { get; set; }
    }
}