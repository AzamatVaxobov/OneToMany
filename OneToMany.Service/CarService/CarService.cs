using OneToMany.DataAccess.Entites;
using OneToMany.Repository.CarRepository;
using OneToMany.Service.DTOs;

namespace OneToMany.Service.CarService
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public long AddCar(CarCreateDto carCreateDto)
        {
            var car = new Car
            {
                Name = carCreateDto.Name,
                Color = carCreateDto.Color,
                Price = carCreateDto.Price,
                PersonId = carCreateDto.PersonId // Set the foreign key
            };

            return _carRepository.PostCar(car);
        }

        public ICollection<CarDto> GetAllCars()
        {
            var cars = _carRepository.GetAll();
            var carDtos = new List<CarDto>();

            foreach (var car in cars)
            {
                carDtos.Add(new CarDto
                {
                    Id = car.Id,
                    Name = car.Name,
                    Color = car.Color,
                    Price = car.Price,
                    PersonId = car.PersonId // Include the foreign key if needed
                });
            }

            return carDtos;
        }

        public void RemoveCar(long carId)
        {
            _carRepository.Delete(carId);
        }

        public CarDto GetCarById(long carId)
        {
            var car = _carRepository.GetById(carId);
            if (car == null) return null; // Handle not found

            return new CarDto
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Price = car.Price,
                PersonId = car.PersonId // Include the foreign key if needed
            };
        }

       
    }
}