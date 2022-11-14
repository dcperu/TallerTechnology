using Application.Core.Interfaces;
using Domain.Core;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class CarService : ICarService
    {        
        public void Create(NewCarDTO request)
        {
            Car newCar = new Car(request.Id, request.Make, request.Model, request.Year, request.Doors, request.Color, request.Price);

            //TODO: Use auto mapper for mapping between DTO and car model
            //TODO: Data Repository Call for create a new car.
        }

        private List<Car> SimulationDBGetAll() {
        return new(){
            new Car (1, "Audi", "R8", 2018, 2, "Red", 79995),
            new Car (2, "Tesla", "3", 2018, 4, "Black", 54995),
            new Car (3, "Porsche", "911 991", 2020, 2, "White", 155000),
            new Car (4, "Mercedes-Benz", "GLE 63S", 2021, 5, "Blue", 83995),
            new Car (5, "BMW", "X6 M", 2020, 5, "Silver", 62995 ),
            };
        }

        public List<ToViewCarDTO> GetAll()
        {
            return SimulationDBGetAll().Select(s => new ToViewCarDTO {
                Id = s.Id,
                Make = s.Make,
                Model = s.Model,
                Year = s.Year,
                Doors = s.Doors,
                Color = s.Color,
            }).ToList();
        }

        public void Update(NewCarDTO request)
        {
            if (request == null)
                throw new ArgumentNullException();

            Car car = this.SimulationDBGetAll().FirstOrDefault(c => c.Id == request.Id);

            if (car == null)
                throw new Exception("Car not found");

            car.Update(request.Make, request.Model, request.Year, request.Doors, request.Color, request.Price);
                        
            //TODO: Data Repository Call for update.
        }

        public void Delete(NewCarDTO request)
        {
            if (request == null)
                throw new ArgumentNullException();

            Car car = this.SimulationDBGetAll().FirstOrDefault(c => c.Id == request.Id);

            if (car == null)
                throw new Exception("Car not found");

            //TODO: Data Repository Call for delete
        }
    }
}
