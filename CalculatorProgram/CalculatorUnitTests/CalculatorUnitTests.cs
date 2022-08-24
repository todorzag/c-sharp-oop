using CalculatorProgram;

namespace CalculatorUnitTests
{
    public class Tests
    {
        private Calculator _calculator = Calculator.Instance;

        [TestCase("3 + 1", 4)]
        [TestCase("0 + 1", 1)]
        [TestCase("10 - 5", 5)]
        [TestCase("0 - 1", -1)]
        [TestCase("20 - 50", -30)]
        [TestCase("1 - 0", 1)]
        [TestCase("4 * 4", 16)]
        [TestCase("0 * 4", 0)]
        [TestCase("16 / 4", 4)]
        [TestCase("16 / 0", 0)]
        [TestCase("0 / 16", 0)]
        public void CalculatorAdd_EverythingIsValid_ReturnAnswer(string equation, decimal expected)
        {
            Assert.That(_calculator.Calculate(equation), Is.EqualTo(expected));
        }
    }
}