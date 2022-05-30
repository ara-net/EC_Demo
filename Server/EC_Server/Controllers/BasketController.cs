using Microsoft.AspNetCore.Mvc;

namespace EC_Server.Controllers
{
    public class BasketController : MyController
    {
        private readonly IBasketBL basketBL;

        public BasketController(IBasketBL basketBL)
        {
            this.basketBL = basketBL;
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await basketBL.GetAll();
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpGet("{basketId}")]
        public async Task<ObjectResult> Get(Guid basketId)
        {
            var result = await basketBL.Get(basketId);
            return result.Result ? Ok(result) : NotFound(result);
        }

        [HttpPost("SetStatus")]
        public async Task<ObjectResult> SetStatus(statusUpdateDTO data)
        {
            var result = await basketBL.SetStatus(data);
            return result.Result ? Ok(result) : NotFound(result);
        }
    }
}