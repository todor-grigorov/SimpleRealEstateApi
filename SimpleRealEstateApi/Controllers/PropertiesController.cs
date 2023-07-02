using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleRealEstateApi.Interfaces;

namespace SimpleRealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertiesRepository propertiesRepository, IMapper mapper)
        {
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
        }
    }
}
