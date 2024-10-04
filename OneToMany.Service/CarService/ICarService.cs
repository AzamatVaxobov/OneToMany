using OneToMany.Service.DTOs;

namespace OneToMany.Service.CarService
{
    public interface ICarService
    {
        long AddCar(CarCreateDto carCreateDto);
        ICollection<CarDto> GetAllCars();
        void RemoveCar(long carId);
        CarDto GetCarById(long carId);
    }
}