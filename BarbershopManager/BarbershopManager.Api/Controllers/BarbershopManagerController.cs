using BarbershopManager.BarbershopManager.Domain.Services;
using BarbershopManager.BarbershopManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BarbershopManager.BarbershopManager.Api.Controllers
{

    [ApiController]
    [Route("api/v1/revenue")]
    public class BarbershopManagerController : ControllerBase
    {
        private readonly ILogger<BarbershopManagerController> _logger;
        private readonly IRevenueService _revenueService;

        public BarbershopManagerController(
            ILogger<BarbershopManagerController> logger,
            IRevenueService revenueService
            )
        {
            _logger = logger;
            _revenueService = revenueService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRevenue()
        {
            var response = await _revenueService.GetRevenue();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRevenueById([FromRoute] Guid id)
        {
            var revenue = await _revenueService.GetRevenueById(id);
            return Ok(revenue);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRevenue([FromBody] Revenue revenue)
        {
            var response = await _revenueService.CreateRevenue(revenue);
            return CreatedAtAction(nameof(GetRevenueById), new { id = response.Id }, response);
        }

    }
}
