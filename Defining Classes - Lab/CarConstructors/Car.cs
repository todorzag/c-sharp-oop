using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructors
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;


        public string Make { get { return this.make; } set { this.make = value; } }

        public string Model { get { return this.model; } set { this.model = value; } }

        public int Year { get { return this.year; } set { this.year = value; } }

        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }

        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }

        public Car()
        {
            make = "VW";
            model = " MK3";
            year = 1992;
            fuelQuantity = 200;
            fuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

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
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {FuelQuantity:F2} L";
        }

    }
}
