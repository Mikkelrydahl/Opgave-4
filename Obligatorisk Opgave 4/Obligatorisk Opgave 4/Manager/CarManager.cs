using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave_4.Manager
{
    public class CarManager
    {
        private static int _nextId = 1;
        private static readonly List<Car> data = new List<Car>

        {
            new Car {Id = _nextId++, Model = "BMVV", Price = 1000000, LicensePlate = "BMVV123"},
            new Car {Id = _nextId++, Model = "Audi", Price = 2000000, LicensePlate = "Audi123"},
            new Car {Id = _nextId++, Model = "Mercedes", Price = 3000000, LicensePlate = "Merce123"}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<Car> GetAll(string modelFilter, int? priceFilter, string? licenseplateFilter)
        {
            List<Car> result = new List<Car>(data);
            if (!string.IsNullOrWhiteSpace(modelFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter != null)
            {
                result = result.FindAll(filterCar =>
                    filterCar.Price <= priceFilter);
            }

            if (!string.IsNullOrWhiteSpace(licenseplateFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.LicensePlate.Contains(licenseplateFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Car GetById(int id)
        {
            return data.Find(car => car.Id == id);
        }

        public Car AddCars(Car newCar)
        {
            newCar.Id = _nextId;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = data.Find(car => car.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }
    }
}
