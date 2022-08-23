using Bank;

namespace BankUnitTests
{
    public class TransactionUnitTests
    {
        [TestCase(" ")]
        [TestCase(null)]
        public void SetNote_NoteIsFalsy_ThrowExcception(string note)
        {
            Assert.Throws<ArgumentNullException>(()
                => new Transaction(100, DateTime.Now, "deposit", note));
        }

        [TestCase(" ")]
        [TestCase("IsFalse")]
        [TestCase(null)]
        public void SetType_TypeIsFalsy_ThrowExcception(string type)
        {
            Assert.Throws<InvalidOperationException>(()
                => new Transaction(100, DateTime.Now, type, "test"));
        }
    }
}
