namespace CarAndEngine
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> tiresList = AddTires();

            List<Engine> engines = AddEngines();

            List<Car> cars = AddCars(tiresList, engines);

            List<Car> specialCars = GetSpecialCarsList(cars);

            DriveCars(specialCars);

            PrintCars(specialCars);

        }

        public static List<Tire[]> AddTires()
        {
            string line = Console.ReadLine();

            List<Tire[]> tiresList = new List<Tire[]>();

            while (line != "No more tires")
            {
                string[] split = line.Split(" ");

                Tire[] tires = new Tire[4];

                for (int i = 0; i < split.Length; i += 2)
                {
                    int year = int.Parse(split[i]);
                    double pressure = double.Parse(split[i + 1]);

                    int counter = i / 2;
                    tires[counter] = new Tire(year, pressure);
                }

                tiresList.Add(tires);

                line = Console.ReadLine();
            }

            return tiresList;
        }

        public static List<Engine> AddEngines()
        {
            List<Engine> engines = new List<Engine>();

            string line = Console.ReadLine();

            while (line != "Engines done")
            {
                string[] split = line.Split(" ");
                int horsePower = int.Parse(split[0]);
                double cubicCapacity = double.Parse(split[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));

                line = Console.ReadLine();
            }

            return engines;
        }

        public static List<Car> AddCars(List<Tire[]> tiresList, List<Engine> engines)
        {
            string line = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (line != "Show special")
            {
                string[] split = line.Split(" ");

                string make = split[0];
                string model = split[1];
                int year = int.Parse(split[2]);
                int fuelQuantity = int.Parse(split[3]);
                int fuelConsumption = int.Parse(split[4]);

                int engineIndex = int.Parse(split[5]);
                int tiresIndex = int.Parse(split[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tiresList[tiresIndex]);

                cars.Add(car);

                line = Console.ReadLine();
            }

            return cars;
        }

        public static List<Car> GetSpecialCarsList(List<Car> cars)
        {
            List<Car> specialCars = new List<Car>();

            foreach (Car car in cars)
            {
                bool checkYear = CheckYearOver2017(car);
                bool checkPower = CheckPowerOver330(car);
                bool checkPressure = CheckTirePressureBetween9And10(car);

                if (checkYear && checkPower && checkPressure)
                {
                    specialCars.Add(car);
                }
            }

            return specialCars;
        }

        public static bool CheckYearOver2017(Car car)
        {
            return car.Year >= 2017;
        }

        public static bool CheckPowerOver330(Car car)
        {
            return car.Engine.HorsePower >= 330;
        }

        public static bool CheckTirePressureBetween9And10(Car car)
        {
            double sum = car.Tires.Sum(t => t.Pressure);
            return 9 <= sum && sum <= 10;
        }

        public static void DriveCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                car.Drive(20);
            }
        }

        public static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}