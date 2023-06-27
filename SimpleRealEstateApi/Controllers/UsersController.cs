using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRealEstateApi.Data;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {

        }
    }
}
