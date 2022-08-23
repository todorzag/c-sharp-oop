using Bank;

namespace BankUnitTests
{
    public class GiftCardAccountUnitTests
    {

        [TestCase(-1)]
        [TestCase(-999)]
        public void MonthlyDeposit_NegativeNumber_ThrowException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => new GiftCardAccount("Kircho", 100, amount));
        }

        [Test]
        public void PerformEndOfMonthTransactions_MonthlyDepositIsNotZero_MakeDeposit()
        {
            GiftCardAccount account = new GiftCardAccount("Kircho", 100, 20);

            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(120));
        }
    }
}
