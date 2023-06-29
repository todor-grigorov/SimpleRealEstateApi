using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleRealEstateApi.Data;
using SimpleRealEstateApi.Dto;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsersController(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
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

            var userExists = _userRepository.GetUser(userCreate.Email);

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

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            var currentUser = _userRepository.GetUserByEmailAndPassword(user.Email, user.Password);

            if (currentUser != null)
            {
                return NotFound();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);
        }
    }
}
