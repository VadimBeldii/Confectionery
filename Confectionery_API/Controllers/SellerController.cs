using Confectionery.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confectionery.BLL.Services;
using System.Text.Json;


namespace Confectionery_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public SellerController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            return Ok(JsonSerializer.Serialize(productService.GetCategories()));
        }
    }
}
