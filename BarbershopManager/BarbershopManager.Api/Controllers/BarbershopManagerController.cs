using BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;
using BarbershopManager.BarbershopManager.Application.UseCases.CreateRevenue;
using Microsoft.AspNetCore.Mvc;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Application.UseCases.UpdateRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.DeleteRevenue;

namespace BarbershopManager.BarbershopManager.Api.Controllers
{

    [ApiController]
    [Route("api/v1/revenue")]
    public class BarbershopManagerController : ControllerBase
    {
        private readonly ILogger<BarbershopManagerController> _logger;

        public BarbershopManagerController(
            ILogger<BarbershopManagerController> logger
            )
        {
            _logger = logger;
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
            if (response == null || !response.Any())
            {
                return NotFound("No revenue records found.");
            }
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRevenue(
            [FromServices] IUpdateRevenue useCase,
            [FromBody] RequestUpdate revenue
        )
        {
            var response = await useCase.Execute(revenue);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRevenue(
            [FromServices] IGetRevenueById getRevenueByIdUseCase,
            [FromServices] IDeleteRevenue deleteRevenueUseCase,
            [FromRoute] Guid id
        )
        {
            var revenue = await getRevenueByIdUseCase.Execute(id);
            if (revenue == null)
            {
                return NotFound();
            }

            await deleteRevenueUseCase.Execute(id);
            return NoContent();
        }
    }
}
