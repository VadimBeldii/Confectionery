using Confectionery.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Confectionery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public TestController(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;
        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok(unitOfWork.Orders.GetOrders());
        }
    }
}
