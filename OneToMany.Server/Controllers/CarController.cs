using Microsoft.AspNetCore.Mvc;
using OneToMany.Service.CarService;
using OneToMany.Service.DTOs;

namespace OneToMany.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public long PostCar(CarCreateDto carCreateDto)
        {
            var carId = _carService.AddCar(carCreateDto);
            return carId;
        }

        [HttpDelete("{carId}")]
        public void DeleteCar(long carId)
        {
            _carService.RemoveCar(carId);
        }

        [HttpGet]
        public ICollection<CarDto> GetAllCars()
        {
            var cars = _carService.GetAllCars();
            return cars;
        }

        [HttpGet("{carId}")]
        public CarDto GetCarById(long carId)
        {
            var car = _carService.GetCarById(carId);
            return car;
        }
    }
}
