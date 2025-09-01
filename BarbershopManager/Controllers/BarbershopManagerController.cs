using Microsoft.AspNetCore.Mvc;

namespace BarbershopManager.Controllers
{
    [ApiController]
    [Route("api/v1/revenue")]
    public class BarbershopManagerController : ControllerBase
    {
        private readonly ILogger<BarbershopManagerController> _logger;

        public BarbershopManagerController(ILogger<BarbershopManagerController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string GetRevenue()
        {

            return "Barbershop Manager is running!";
        }
    }
}
