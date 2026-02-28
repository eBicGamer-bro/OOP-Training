namespace Assignment_7
{
    public abstract class Vehicles
    {
        protected string _brand;
        protected string _model;
        protected int _year;

        public Vehicles(string brand, string model, string year)
        {
            if (string.IsNullOrEmpty(brand) || string.IsNullOrWhiteSpace(brand))
                throw new InvalidOperationException("brand can't be empty");
            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(model))
                throw new InvalidOperationException("model can't be empty");
            if (string.IsNullOrWhiteSpace(year) || string.IsNullOrWhiteSpace(year))
                throw new InvalidOperationException("year can't be empty");
            if(!int.TryParse(year, out int temp) || temp < 2000 || temp > 2026)
                throw new InvalidOperationException("Invalid Year");
            _year = temp;
            _brand = brand;
            _model = model;
        }
        public abstract void Start();
        public abstract void Stop();
        public abstract void Drive();
        public abstract void Fuel();
        public abstract void Refuel();
        public string Brand
        {
            get
            {
                return _brand;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
        }
    }
    public class Car : Vehicles
    {
        public Car(string brand, string model, string year) : base(brand, model, year)
        {
        }

        public override void Drive()
        {
            Console.WriteLine("Driving Car...");
        }

        public override void Fuel()
        {
            Console.WriteLine("Fueling Car...");
        }

        public override void Refuel()
        {
            Console.WriteLine("Refueling Car...");
        }

        public override void Start()
        {
            Console.WriteLine("Starting Car...");
        }

        public override void Stop()
        {
            Console.WriteLine("Stoping Car...");
        }
    }
    public class MotorCycle : Vehicles
    {
        public MotorCycle(string brand, string model, string year) : base(brand, model, year)
        {
        }

        public override void Drive()
        {
            Console.WriteLine("Driving MotorCycle...");
        }

        public override void Fuel()
        {
            Console.WriteLine("Fueling MotorCycle...");
        }

        public override void Refuel()
        {
            Console.WriteLine("Refueling MotorCycle...");
        }

        public override void Start()
        {
            Console.WriteLine("Starting MotorCycle...");
        }

        public override void Stop()
        {
            Console.WriteLine("Stoping MotorCycle...");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Toyota", "Cameron", "2020");
            MotorCycle motorCycle = new MotorCycle("Honda", "NT1100", "2019");
            Console.WriteLine($"Car Brand: {car.Brand}      Car Model: {car.Model}      Car Year: {car.Year}");
            car.Start();
            car.Fuel();
            car.Drive();
            car.Refuel();
            car.Stop();
            Console.WriteLine($"\nMotorcycle Brand: {motorCycle.Brand}      Motorcycle Model: {motorCycle.Model}      Motorcycle Year: {motorCycle.Year}");
            motorCycle.Start();
            motorCycle.Fuel();
            motorCycle.Drive();
            motorCycle.Refuel();
            motorCycle.Stop();

        }
    }
}
