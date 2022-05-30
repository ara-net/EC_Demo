using EC_Server.BL.Interface;
using EC_Server.DTO;
using EC_Server.Model;
using EC_Server.Tools;
using EI_Server.DTO;
using static EC_Server.Tools.Extension;

namespace EC_Server.BL.Business
{
    public class ProductBL : BlBase, IProductBL
    {
        private readonly EiContext db;

        public ProductBL(EiContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<ApiResultDTO> GetAll(ProductType type)
        {
            var data = from p in db.Products.Where(m => m.ProductType == type)
                       from u in db.Users.Where(m => m.UserId == p.UserId)
                       select new ProductDTO
                       {
                           Id = p.Id,
                           Title = p.Title,
                           Quantity = p.Quantity,
                           CreateDateEn = p.CreateDate,
                           Price = p.Price,
                           ImageUrl = p.ImageUrl,
                           Description = p.Description,
                           UserName = u.FullName,
                           CriticalQuantity = p.CriticalQuantity,
                           UnitType = p.UnitType,
                           IsExist = p.IsExist
                       };
            return GetResult("", true, await data.ToListAsync());
        }

        public async Task<ApiResultDTO> AddNew(Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    db.Products.Add(product);

                    return await db.SaveChangesAsync() > 0 ?
                        GetResult("محصول جدید با موفقیت اضافه شد", true) :
                        GetResult("خطا در ثبت محصول جدید", false);
                }
                var prdt = db.Products.Find(product.Id);
                prdt.IsExist = product.IsExist ? product.Quantity > 0 : product.IsExist;
                prdt.ImageUrl = product.ImageUrl ?? "";
                prdt.Quantity = product.Quantity;
                prdt.CriticalQuantity = product.CriticalQuantity;
                prdt.Title = product.Title;
                prdt.UnitType = product.UnitType;
                prdt.Price = product.Price;
                prdt.Description = product.Description ?? "---";
                return await db.SaveChangesAsync() > 0 ?
                    GetResult("محصول با موفقیت ویرایش شد", true) :
                    GetResult("خطا در ویرایش محصول", false);
            }
            catch (Exception ex)
            {
                return GetResult(ex.Message, false);
            }
        }

        public async Task<ApiResultDTO> UpdateExistStatus(int id)
        {
            var prdt = db.Products.Find(id);
            prdt.IsExist = !prdt.IsExist;

            return await db.SaveChangesAsync() > 0 ?
                GetResult("وضعیت موجودی با موفقیت ویرایش شد", true) :
                GetResult("خطا در ویرایش وضعیت موجودی", false);
        }

        public async Task<ApiResultDTO> Delete(int id)
        {
            var prdt = db.Products.Find(id);
            if (db.BasketDetail.Any(m => m.ProductId == id))
                return GetResult("این کالا در سبد خرید موجود می باشد و شما قادر به حذف آن نیستید", false);
            db.Products.Remove(prdt);

            return await db.SaveChangesAsync() > 0
                ? GetSuccessResult(prdt)
               : GetFailResult();
        }
    }
}