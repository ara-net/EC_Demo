namespace EC.BL.Interface
{
    public interface IBasketBL:IBase
    {
        Task<ApiResultDTO> Get(Guid basketId);
        Task<ApiResultDTO> SetStatus(statusUpdateDTO data);
    }
}