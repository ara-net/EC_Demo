using EC_Server.DTO;
using EC_Server.Model;
using EC_Server.Tools;

namespace EC_Server.BL.Interface
{
    public interface IProductBL
    {
        Task<ApiResultDTO> AddNew(Product product);
        Task<ApiResultDTO> Delete(int id);
        Task<ApiResultDTO> GetAll(ProductType type);
        Task<ApiResultDTO> UpdateExistStatus(int id);
    }
}