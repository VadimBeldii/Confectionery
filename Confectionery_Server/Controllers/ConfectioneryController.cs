using Microsoft.AspNetCore.Mvc;
using Confectionery_Data;
using System.Text.Json;


namespace Confectionery_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfectioneryController : ControllerBase
    {
        private ConfectioneryDbContext dbContext;

        ConfectioneryController() => dbContext = new ConfectioneryDbContext();

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(JsonSerializer.Serialize(dbContext.Categories));
        }
    }
}
