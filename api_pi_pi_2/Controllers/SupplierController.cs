using api_pi_pi_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_pi_pi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Supplier>> GetSuppliers()
        {
            var suppliers = Program.context.Suppliers.ToList();
            return Ok(suppliers);
        }
    }
}
