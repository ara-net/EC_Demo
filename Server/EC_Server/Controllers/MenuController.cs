using Microsoft.AspNetCore.Mvc;

namespace EC_Server.Controllers
{
    public class MenuController : MyController
    {
        private readonly IMenuBL menuBL;

        public MenuController(IMenuBL menuBL)
        {
            this.menuBL = menuBL;
        }
        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await menuBL.GetAll();
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] Menu menu)
        {
            var result = await menuBL.Add(menu);
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpPut("change-order")]
        public async Task<ObjectResult> ChangeOrder([FromBody] OrderUpdateDTO input)
        {
            var result = await menuBL.ChangeOrder(input);
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpPut("toggle-active/{menuId}")]
        public async Task<ObjectResult> ToggleActive(int menuId)
        {
            var result = await menuBL.ToggleActive(menuId);
            return result.Result ? Ok(result) : NotFound(result);
        }
    }
}