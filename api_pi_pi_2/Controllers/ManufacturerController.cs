using api_pi_pi_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_pi_pi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Manufacturer>> GetManufacturers()
        {
            var manufacturers = Program.context.Manufacturers.ToList();
            return Ok(manufacturers);
        }
    }
}
