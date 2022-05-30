using EC.Common.Tools;
using Microsoft.AspNetCore.Mvc;

namespace EC_Server.Controllers
{
    public class ProductController : MyController
    {
        private readonly IProductBL bL;
        public ProductController(IProductBL bL)
        {
            this.bL = bL;
        }

        [HttpGet("{type}")]
        public async Task<ObjectResult> Get(ProductType type)
        {
            var result = await bL.GetAll(type);
            if (result.Result)
                return Ok(result);
            return NotFound(result);
        }

        [HttpPost]
        public async Task<ObjectResult> Post(Product product)
        {
            var result = await bL.Add(product);
            if (result.Result)
                return Ok(result);
            return NotFound(result);
        }

        [HttpPut("toggle-exist")]
        public async Task<ObjectResult> ChangeExistStatus(int id)
        {
            var result = await bL.UpdateExistStatus(id);
            if (result.Result)
                return Ok(result);
            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<ObjectResult> Delete(int id)
        {
            var result = await bL.Delete(id);
            if (result.Result)
                return Ok(result);
            return NotFound(result);
        }
    }
}