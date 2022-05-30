using EC_Server.DTO;

namespace EC_Server.BL.Interface
{
    public interface IBasketBL
    {
        Task<ApiResultDTO> Get();
        Task<ApiResultDTO> Get(Guid basketId);
        Task<ApiResultDTO> SetStatus(statusUpdateDTO data);
    }
}