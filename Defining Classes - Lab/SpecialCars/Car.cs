using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndEngine
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        private Engine engine;
        private Tire[] tires;


        public string Make { get { return make; } set { make = value; } }

        public string Model { get { return model; } set { model = value; } }

        public int Year { get { return year; } set { year = value; } }

        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public Engine Engine { get { return engine; } set { engine = value; } }

        public Tire[] Tires { get { return tires; } set { tires = value; } }

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

        public Car(string make, string model, int year, int fuelQuantity, int fuelConsumption) : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, int fuelQuantity, int fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.engine = engine;
            this.tires = tires;
        }

        public void Drive(double distance)
        {
            double result = distance * (fuelConsumption / 100);

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
            return $"Make: {Make}\n" +
                $"Model: {Model}\n" +
                $"Year: {Year}\n" +
                $"HorsePowers: {Engine.HorsePower}\n" +
                $"Fuel: {FuelQuantity:F2} L";
        }

    }
}
