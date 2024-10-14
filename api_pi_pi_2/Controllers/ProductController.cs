﻿using api_pi_pi_2.Models;
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

        //[HttpGet("{article}")]
        //public ActionResult<Product> Get(string article)
        //{
        //    Product? product = Program.context.Products.Where((product) => product.ProductArticleNumber == article).FirstOrDefault();
        //    return product == null ? NotFound("Товар не найден.") : Ok(product);
        //}
    }
}
