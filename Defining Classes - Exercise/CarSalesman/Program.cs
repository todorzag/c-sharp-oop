namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string line = Console.ReadLine();
                engines.Add(CreateEngine(line));
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string line = Console.ReadLine();
                cars.Add(CreateCar(line, engines));
            }

            PrintCars(cars);
        }


        // Default value of Efficiency is "n/a" and the default value of Displacment is -1 
        public static Engine CreateEngine(string line)
        {
            string[] split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = split[0];
            int power = int.Parse(split[1]);
            int displacment = -1;
            string efficiency = "n/a";

            for (int i = 2; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out _))
                {
                    displacment = int.Parse(split[i]);
                }
                else
                {
                    efficiency = split[i];
                }
            }

            return new Engine(model, power, displacment, efficiency);
        }

        // Default value of Color is "n/a" and the default value of Weight is -1
        public static Car CreateCar(string line, List<Engine> engines)
        {
            string[] split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = split[0];
            Engine engine = FindEngine(split[1], engines);
            int weight = -1;
            string color = "n/a";

            for (int i = 2; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out _))
                {
                    weight = int.Parse(split[i]);
                }
                else
                {
                    color = split[i];
                }
            }

            return new Car(model, engine, weight, color);
        }

        public static Engine FindEngine(string engineToFind ,List<Engine> engines)
        {
            return engines.Find(engine => engine.Model == engineToFind);
        }

        public static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                string displacment = car.Engine.Displacment == -1 ? "n/a" : car.Engine.Displacment.ToString();

                string weight = car.Weight == -1 ? "n/a" : car.Weight.ToString();

                Console.WriteLine($"{car.Model}:\n" +
                    $" {car.Engine.Model}:\n" +
                    $"  Power: {car.Engine.Power}\n" +
                    $"  Displacment: {displacment}\n" +
                    $"  Efficiency: {car.Engine.Efficiency}\n" +
                    $"Weight: {weight}\n" +
                    $"Color : {car.Color}");
            }
        }
    }
}