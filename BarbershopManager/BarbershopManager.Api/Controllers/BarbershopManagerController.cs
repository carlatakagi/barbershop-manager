using BarbershopManager.BarbershopManager.Domain.Services;
using BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;
using BarbershopManager.BarbershopManager.Application.UseCases.CreateRevenue;
using Microsoft.AspNetCore.Mvc;
using BarbershopManager.BarbershopManager.Communication.Requests;

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
        public async Task<IActionResult> GetRevenue(
            [FromServices] IGetAllRevenue useCase
        )
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRevenueById(
            [FromServices] IGetRevenueById useCase,
            [FromRoute] Guid id
        )
        {
            var revenue = await useCase.Execute(id);
            return Ok(revenue);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRevenue(
            [FromServices] ICreateRevenue useCase,
            [FromBody] RequestCreate revenue
        )
        {
            var response = await useCase.Execute(revenue);
            return CreatedAtAction(nameof(GetRevenueById), new { id = response.Id }, response);
        }

    }
}
