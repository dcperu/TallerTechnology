namespace Domain.Core
{
    public class Car
    {        

        public int Id { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Doors { get; private set; }
        public string Color { get; private set; }
        public decimal Price { get; private set; }

        public Car(int id, string make, string model, int year, int doors, string color, decimal price)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Doors = doors;
            this.Color = color;
            this.Price = price;
        }

        public void Update(string make, string model, int year, int doors, string color, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Doors = doors;
            this.Color = color;
            this.Price = price;
        }
    }
}