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

        [TestCase(20, 120)]
        [TestCase(100, 200)]
        public void PerformEndOfMonthTransactions_MonthlyDepositIsValid_MakeDeposit(int amount, int expected)
        {
            GiftCardAccount account = new GiftCardAccount("Kircho", 100, amount);

            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }
    }
}
