using Microsoft.AspNetCore.Mvc;

namespace EC_Server.Controllers
{
    public class UserController : MyController
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await userBL.GetAll();
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> Get(int id)
        {
            var result = await userBL.Get(id);
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpGet("toggle-ban/{id}")]
        public async Task<ObjectResult> ToggleBan(int id)
        {
            var result = await userBL.ToggleBan(id);
            return result.Result ? Ok(result) : NotFound(result);
        }
        [HttpPost]
        public async Task<ObjectResult> Post(UserDTO user)
        {
            var result = await userBL.Add(user);
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<ObjectResult> Delete(int id)
        {
            var result = await userBL.Delete(id);
            return result.Result ? Ok(result) : NotFound(result);
        }
    }
}