using NumberToWord;

namespace NumberToWordUnitTests
{
    public class Tests
    {
        private Converter _converter = Converter.GetInstance;

        [TestCase(0, "Zero")]
        [TestCase(5, "Five")]
        [TestCase(19, "Nineteen")]
        [TestCase(20, "Twenty")]
        [TestCase(68, "Sixty eight")]
        [TestCase(100, "One hundred")]
        [TestCase(404, "Four hundred and four")]
        [TestCase(420, "Four hundred and twenty")]
        [TestCase(711, "Seven hundred and eleven")]
        [TestCase(999, "Nine hundred and ninety nine")]
        public void ConvertNumber_NumberIsValid_ReturnNumberToWord(int number, string expected)
        {
            Assert.That(_converter.ConvertToWord(number), Is.EqualTo(expected));
        }
    }
}