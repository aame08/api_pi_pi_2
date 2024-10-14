using api_pi_pi_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_pi_pi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Producttype>> GetProductTypes()
        {
            var productTypes = Program.context.Producttypes.ToList();
            return Ok(productTypes);
        }
    }
}
