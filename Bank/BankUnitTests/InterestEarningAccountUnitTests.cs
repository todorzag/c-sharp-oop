using Bank;

namespace BankUnitTests
{
    public class InterestEarningAccountUnitTests
    {
        [TestCase(501)]
        [TestCase(999)]
        public void PerformEndOfMonthTransactions_BalanceOver500_MakeDeposit(int balance)
        {
            InterestEarningAccount account = new InterestEarningAccount("Kircho", balance);
            decimal expected = balance + (balance * 0.05m);

            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }
    }
}
