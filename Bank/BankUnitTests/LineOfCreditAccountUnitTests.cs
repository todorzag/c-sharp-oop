using Bank;

namespace BankUnitTests
{
    internal class LineOfCreditAccountUnitTests
    {
        [TestCase(101, -1.07)]
        [TestCase(150, -53.5)]
        public void PerformEndOfMonthTransactions_BalanceIsNegative_MakeWithdrawal(int amount, decimal expected)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -200);

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [TestCase(199, -125.93)]
        [TestCase(200, -127)]
        public void CheckWithdrawalLimit_IsOverdrawnTrue_MakeWithdrawal(int amount, decimal expected)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -100);

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [TestCase(201, -149.47)]
        [TestCase(900 , -897.4)]
        public void CheckWithdrawalLimit_IsOverdrawnTrueAndBalanceIsNegative_MakeWithdrawal(int amount, decimal expected)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -100);

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }
    }
}
