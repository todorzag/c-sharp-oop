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
        [TestCase(68, "Sixty Eight")]
        [TestCase(100, "One Hundred")]
        [TestCase(404, "Four Hundred And Four")]
        [TestCase(420, "Four Hundred And Twenty")]
        [TestCase(711, "Seven Hundred And Eleven")]
        [TestCase(999, "Nine Hundred And Ninety Nine")]
        public void ConvertNumber_NumberIsValid_ReturnNumberToWord(int number, string expected)
        {
            Assert.That(_converter.ConvertToWord(number), Is.EqualTo(expected));
        }
    }
}