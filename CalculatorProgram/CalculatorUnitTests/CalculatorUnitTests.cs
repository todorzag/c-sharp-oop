using CalculatorProgram;

namespace CalculatorUnitTests
{
    public class Tests
    {
        private Calculator _calculator = Calculator.Instance;

        [TestCase(3, 1, 4)]
        [TestCase(0, 1, 1)]
        public void CalculatorAdd_EverythingIsValid_ReturnAnswer(decimal num1, decimal num2, decimal expected)
        {
            Assert.That(_calculator.Add(num1, num2), Is.EqualTo(expected));
        }

        [TestCase(10 ,5, 5)]
        [TestCase(0, 1, -1)]
        [TestCase(1, 0, 1)]
        [TestCase(20, 50, -30)]
        public void CalculatorSubract_EverythingIsValid_ReturnAnswer(decimal num1, decimal num2, decimal expected)
        {
            Assert.That(_calculator.Subtract(num1, num2), Is.EqualTo(expected));
        }

        [TestCase(4, 4, 16)]
        [TestCase(4, 0, 0)]
        public void CalculatorMultiply_EverythingIsValid_ReturnAnswer(decimal num1, decimal num2, decimal expected)
        {
            Assert.That(_calculator.Multiply(num1, num2), Is.EqualTo(expected));
        }

        [TestCase(16, 4, 4)]
        [TestCase(2, 4, 0.5)]
        public void CalculatorDivide_EverythingIsValid_ReturnAnswer(decimal num1, decimal num2, decimal expected)
        {
            Assert.That(_calculator.Divide(num1, num2), Is.EqualTo(expected));
        }

        [TestCase(16, 0, 0)]
        [TestCase(0, 0, 0)]
        public void CalculatorDivide_DividerIsZero_ReturnAnswer(decimal num1, decimal num2, decimal expected)
        {
            Assert.That(_calculator.Divide(num1, num2), Is.EqualTo(expected));
        }
    }
}