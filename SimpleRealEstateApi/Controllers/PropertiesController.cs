using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleRealEstateApi.Dto;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;
using System.Security.Claims;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertiesRepository propertiesRepository, IUserRepository userRepository,IMapper mapper)
        {
            _propertiesRepository = propertiesRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateProperty([FromBody] PropertyDto propertyCreate)
        {
            if (propertyCreate == null)
            {
                return BadRequest(ModelState);
            }

            var property = _propertiesRepository.GetProperties()
                .Where(p => p.Address.Trim().ToUpper() == propertyCreate.Address.Trim().ToUpper())
                .FirstOrDefault();

            if (property != null)
            {
                ModelState.AddModelError("", "Property already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _userRepository.GetUser(userEmail);
            
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var propertyMap = _mapper.Map<Property>(propertyCreate);

            if (!_propertiesRepository.CreateProperty(user.Id, propertyMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
