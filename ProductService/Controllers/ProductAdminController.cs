using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAdminController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductAdminController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddNewProductDto addNewProductDto)
        {
            productService.AddNewProduct(addNewProductDto);
            return Ok();
        }

    }
}
