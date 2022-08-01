using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExtension
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;


        public string Make { get { return this.make; } set { this.make = value; } }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }

        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }

        public void Drive(double distance)
        {
            double result = distance * fuelConsumption;

            if (fuelQuantity - result >= 0)
            {
                fuelQuantity -= result;
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
