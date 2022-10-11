using AutoMapper;
using HotelListing.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ILogger = Serilog.ILogger;
using HotelListing.Domain.Models;
using HotelListing.Infrastructure.IRepository;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;
        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var Countries = await _unitOfWork.CountryRepository.GetAllAsync();
                var result = _mapper.Map<IList<CountryDTO>>(Countries);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server error, Please try again later");

            }

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCountry(int Id)
        {
            try
            {
                var Country = await _unitOfWork.CountryRepository.Get(c => c.Id == Id, new List<string> { "Hotels" });


                var result = _mapper.Map<CountryDTO>(Country);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server error, Please try again later");

            }

        }
    }
}
