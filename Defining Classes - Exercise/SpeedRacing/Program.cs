namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] split = Console.ReadLine().Split(" ");

                string model = split[0];
                double fuelAmount = double.Parse(split[1]);
                double fuelConsumptionPerKilometer = double.Parse(split[2]);


                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] split = line.Split(" ");

                string model = split[1];
                double travelDistance = double.Parse(split[2]);

                Car car = FindCar(model, cars);
                car.Drive(travelDistance);

                line = Console.ReadLine();
            }

            PrintCars(cars);
        }

        public static Car FindCar(string model, List<Car> cars)
        {
            return cars.Find(car => car.Model == model);
        }

        public static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}