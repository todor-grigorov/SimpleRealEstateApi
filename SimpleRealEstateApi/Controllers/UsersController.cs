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

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (userExists != null)
            {
                return BadRequest("User with same email already exists");
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
