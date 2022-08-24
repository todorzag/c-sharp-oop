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

        public decimal Calculate(string equation)
        {
            (int num1, string operation, int num2) = ExtractInfoFromInput(equation);

            switch (operation)
            {
                case "+":
                    return num1 + num2;

                case "-":
                    return num1 - num2;

                case "*":
                    return num1 * num2;

                case "/":
                    try
                    {
                        return num1 / num2;
                    }
                    catch (DivideByZeroException)
                    {
                        return 0;
                    }  
            }

            return default;
        }

        private (int, string, int) ExtractInfoFromInput(string equation)
        {
            string[] split = equation.Split(" ");

            int num1 = int.Parse(split[0]);
            string operation = split[1];
            int num2 = int.Parse(split[2]);

            return (num1, operation, num2);
        }
    }
}
