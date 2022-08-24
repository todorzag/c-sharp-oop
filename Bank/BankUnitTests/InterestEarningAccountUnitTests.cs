using Bank;

namespace BankUnitTests
{
    public class InterestEarningAccountUnitTests
    {
        [TestCase(501, 526.05)]
        [TestCase(999, 1048.95)]
        public void PerformEndOfMonthTransactions_BalanceOver500_MakeDeposit(int balance, decimal expected)
        {
            InterestEarningAccount account = new InterestEarningAccount("Kircho", balance);

            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }
    }
}
