using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("car-shop")]
    public class MessageController : Controller
    {
        private readonly ICarShopService _carShopService;
        public MessageController(ICarShopService carShopService)
        {
            _carShopService = carShopService;
        }

        [HttpGet("get-all")]
        public async Task<CarShopState[]> GetCarShops()
        {
            var carShops = await _carShopService.GetCarShops();
            return carShops;
        }
        
        [HttpPost("add")]
        public async Task<IResult> AddCarShop(CarShopModel model)
        {
            return await _carShopService.AddCarShop(model);
        }
        
        [HttpPost("{carShopId}/add-car")]
        public async Task<IResult> AddCar(Guid carShopId, CarModel model)
        {
            return await _carShopService.AddCar(carShopId, model);
        }
        [HttpGet("{carShopId}/get-cars")]
        public async Task<CarState[]> GetCars(Guid carShopId)
        {
            var cars = await _carShopService.GetCars(carShopId);
            return cars;
        }
    }
}
