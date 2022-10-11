using AutoMapper;
using HotelListing.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ILogger = Serilog.ILogger;
using HotelListing.Infrastructure.IRepository;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public HotelController(ILogger<HotelController> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var Hotels = await _unitOfWork.HotelRepository.GetAllAsync();
                var result = _mapper.Map <IList<HotelDTO>>(Hotels);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {(nameof(GetHotels))}");
                return StatusCode(500, "Internal server error");

            }
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int Id)
        {
            try
            {
                var Hotel = await _unitOfWork.HotelRepository.Get(s => s.Id == Id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDTO>(Hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {(nameof(GetHotel))}");
                return StatusCode(500, "Internal server error");

            }
        }
    }
}
