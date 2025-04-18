using OneToMany.DataAccess.Entites;

namespace OneToMany.Repository.CarRepository
{
    public interface ICarRepository
    {
        public long InsertCar(Car car);
        public ICollection<Car> GetAll();
        public void Delete(long carId);
        public Car GetById(long carId);
    }
}