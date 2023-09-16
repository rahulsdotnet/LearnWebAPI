using LearnWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeaController : ControllerBase
    {
        private readonly ITeaService _teaService;
        private readonly IRestaurantService _restaurantService;

        public TeaController(ITeaService teaService, IRestaurantService restaurantService)
        {
            _teaService = teaService;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tea = _teaService.GetTea();
            var teaFromRestra = _restaurantService.GetTea();

            return Ok($"From TeaService : {tea} \nFrom RestaurantService : {teaFromRestra}");
        }
       
    }
}
