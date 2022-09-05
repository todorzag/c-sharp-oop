using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    public class Calculator
    {
        private static Calculator _instance = null;

        public static Calculator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Calculator();

                return _instance;
            }
        }

        private Calculator()
        {
        }

        public decimal Add(decimal num1, decimal num2) 
            => num1 + num2;

        public decimal Subtract(decimal num1, decimal num2)
            => num1 - num2;

        public decimal Multiply(decimal num1, decimal num2)
            => num1 * num2;

        public decimal Divide(decimal num1, decimal num2)
        {
            try
            {
                return num1 / num2;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
