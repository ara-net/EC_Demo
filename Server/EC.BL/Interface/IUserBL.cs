
namespace EC.BL.Interface
{
    public interface IUserBL : IBase
    {
        Task<ApiResultDTO> Delete(int id);
        Task<ApiResultDTO> Get(int id);
        Task<ApiResultDTO> Add(UserDTO user);
        Task<ApiResultDTO> ToggleBan(int id);
    }
}