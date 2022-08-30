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
    }
}
