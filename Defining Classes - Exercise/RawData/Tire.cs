using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
        public float Pressure { get; }
        public int Age { get; }

        public Tire(float pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}
