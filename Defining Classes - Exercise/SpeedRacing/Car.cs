using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    internal class Car
    {
        public string Model { get; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; }

        private double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public void Drive(double distanceToDrive)
        {
            double fuelNeeded = FuelConsumptionPerKilometer * distanceToDrive;

            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += distanceToDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:0.00} {TravelledDistance}";
        }
    }
}
