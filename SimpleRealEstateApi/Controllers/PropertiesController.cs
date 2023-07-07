using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleRealEstateApi.Dto;
using SimpleRealEstateApi.Interfaces;
using SimpleRealEstateApi.Models;
using System.Security.Claims;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertiesRepository propertiesRepository, IUserRepository userRepository, IMapper mapper)
        {
            _propertiesRepository = propertiesRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{categoryId}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Property>))]
        public IActionResult GetPropertiesByCategory(int categoryId)
        {
            var propertiesResult = _mapper.Map<ICollection<PropertyDto>>(_propertiesRepository.GetPropertiesByCategory(categoryId));

            if (propertiesResult == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(propertiesResult);
        }

        [HttpGet("{propertyId}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(Property))]
        public IActionResult GetProperty(int propertyId)
        {
            var property = _mapper.Map<PropertyDto>(_propertiesRepository.GetProperty(propertyId));

            if (property == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(property);
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

        [HttpPut("{propertyId}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProperty(int propertyId, [FromBody] PropertyDto updateProperty)
        {
            if (updateProperty is null)
                return BadRequest(ModelState);

            if (propertyId != updateProperty.Id)
                return BadRequest(ModelState);

            if (!_propertiesRepository.PropertyExists(propertyId))
                return NotFound();

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

            var propertyMap = _mapper.Map<Property>(updateProperty);

            if (!_propertiesRepository.UpdateProperty(user.Id, propertyMap))
            {
                ModelState.AddModelError("", "Something went wrong updating property!");
                return StatusCode(500, ModelState);
            }

            return Ok("Record updated successfully!");
        }

        [HttpDelete("{propertyId}")]
        [Authorize]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProperty(int propertyId)
        {
            if (!_propertiesRepository.PropertyExists(propertyId))
            {
                return NotFound();
            }

            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = _userRepository.GetUser(userEmail);

            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var propertyToDelete = _propertiesRepository.GetProperty(propertyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (propertyToDelete.UserId != user.Id)
                return NotFound();

            if (!_propertiesRepository.DeleteProperty(propertyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting property");
            }

            return Ok("Recodr deleted successfully");
        }
    }
}
