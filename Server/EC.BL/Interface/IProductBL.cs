using EC.Domain.Tables;

namespace EC.BL.Interface
{
    public interface IProductBL
    {
        Task<ApiResultDTO> Add(Product product);
        Task<ApiResultDTO> Delete(int id);
        Task<ApiResultDTO> UpdateExistStatus(int id);
        Task<ApiResultDTO> GetAll(ProductType type);
    }
}