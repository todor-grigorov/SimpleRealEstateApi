using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRealEstateApi.Data;
using SimpleRealEstateApi.Dto;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest(ModelState);
            }

            var userExists = _userRepository.UserExistsByEmail(userCreate.Email);

            if (userExists != null)
            {
                ModelState.AddModelError("", "User with same email already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);
            _userRepository.CreateUser(userMap);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
