using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
        public int Age { get; }
        public float Pressure { get; }

        public Tire(int age, float pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
