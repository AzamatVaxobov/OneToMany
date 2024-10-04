using OneToMany.DataAccess.Entites;
using OneToMany.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.Repository.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly MainContext _context;

        public CarRepository(MainContext context)
        {
            _context = context;
        }

        // Method to add a new car
        public long PostCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car.Id; // Return the ID of the newly created car
        }

        // Method to get all cars
        public ICollection<Car> GetAll()
        {
            return _context.Cars.ToList(); // Returns a list of all cars
        }

        // Method to delete a car by ID
        public void Delete(long carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                throw new Exception($"Car with id {carId} not found to delete");
            }

            _context.Cars.Remove(car);
            _context.SaveChanges(); // Save changes to the database
        }

        // Method to get a car by ID
        public Car GetById(long carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);

            if (car == null)
            {
                throw new Exception($"Car with id {carId} not found");
            }

            return car; // Return the found car
        }
    }
}
