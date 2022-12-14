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
                string input = Console.ReadLine();
                string[] split = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngineFromInput(split);
                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string line = Console.ReadLine();
                string[] split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCarFromInput(split, engines);
                cars.Add(car);
            }

            PrintCars(cars);
        }


        // Default value of Efficiency is "n/a" and the default value of Displacment is -1 
        public static Engine CreateEngineFromInput(string[] split)
        {
            string model = split[0];
            int power = int.Parse(split[1]);

            (int displacment, string efficiency) = CheckForOptionalArguments(split);

            return new Engine(model, power, displacment, efficiency);
        }

        // Default value of Color is "n/a" and the default value of Weight is -1
        public static Car CreateCarFromInput(string[] split, List<Engine> engines)
        {
            string model = split[0];
            Engine engine = FindEngine(split[1], engines);
            
            (int weight, string color) = CheckForOptionalArguments(split);

            return new Car(model, engine, weight, color);
        }

        private static (int, string) CheckForOptionalArguments(string[] split)
        {
            int intArgument = -1;
            string stringArgument = "n/a";

            for (int i = 2; i < split.Length; i++)
            {
                if (int.TryParse(split[i], out _))
                {
                    intArgument = int.Parse(split[i]);
                }
                else
                {
                    stringArgument = split[i];
                }
            }

            return (intArgument, stringArgument);
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