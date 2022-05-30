
namespace EC.BL.Interface
{
    public interface IMenuBL:IBase
    {
        Task<ApiResultDTO> Add(Menu menu);
        Task<ApiResultDTO> ChangeOrder(OrderUpdateDTO input);
        Task<ApiResultDTO> ToggleActive(int menuId);
    }
}