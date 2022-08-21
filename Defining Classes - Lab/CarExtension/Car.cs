using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExtension
{
    internal class Car
    {
   

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double result = distance * FuelConsumption;

            if (FuelQuantity - result >= 0)
            {
                FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return  $"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {FuelQuantity:F2} L";
        }
    }
}
