using api_pi_pi_2.DTOs;
using api_pi_pi_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_pi_pi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var products = Program.context.Products
                .Include(p => p.ProductType).ToList();

            return Ok(products);
        }

        [HttpPost("adding")]
        public ActionResult<Product> Adding([FromBody] ProductDTO productDTO)
        {
            var existingArticle = Program.context.Products.FirstOrDefault(p => p.ProductArticleNumber == productDTO.ProductArticleNumber);
            if (existingArticle != null) { return Conflict("Товар с таким артиклем уже существует."); }

            var newProduct = new Product
            {
                ProductArticleNumber = productDTO.ProductArticleNumber,
                Name = productDTO.Name,
                Measure = "шт.",
                Cost = productDTO.Cost,
                Description = productDTO.Description,
                ProductTypeId = productDTO.ProductTypeId,
                Photo = productDTO.Photo,
                SupplierId = productDTO.SupplierId,
                ManufacturerId = productDTO.ManufacturerId,
                QuantityInStock = productDTO.QuantityInStock,
                Status = "В наличии"
            };

            Program.context.Products.Add(newProduct);
            Program.context.SaveChanges();
            return StatusCode(201, newProduct);
        }
        //[HttpGet("{article}")]
        //public ActionResult<Product> Get(string article)
        //{
        //    Product? product = Program.context.Products.Where((product) => product.ProductArticleNumber == article).FirstOrDefault();
        //    return product == null ? NotFound("Товар не найден.") : Ok(product);
        //}
    }
}
