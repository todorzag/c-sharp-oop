using Bank;

namespace BankUnitTests
{
    internal class LineOfCreditAccountUnitTests
    {
        [TestCase(101)]
        [TestCase(111)]
        public void PerformEndOfMonthTransactions_BalanceIsNegative_MakeWithdrawal(int amount)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -100);
            decimal balance = 100 - amount;
            decimal expected = balance + (balance * 0.07m);

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [TestCase(199)]
        [TestCase(200)]
        public void CheckWithdrawalLimit_IsOverdrawnTrue_MakeWithdrawal(int amount)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -100);
            decimal balance = 100 - amount;
            decimal expected = balance + (balance * 0.07m) - 20;

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }

        [TestCase(201)]
        [TestCase(900)]
        public void CheckWithdrawalLimit_IsOverdrawnTrueAndBalanceIsNegative_MakeWithdrawal(int amount)
        {
            LineOfCreditAccount account = new LineOfCreditAccount("Kircho", 100, -100);
            decimal balance = 100 - amount - 20;
            decimal expected = balance + (balance * 0.07m) - 20;

            account.MakeWithdrawal(amount, "test");
            account.PerformEndOfMonthTransactions();

            Assert.That(account.Balance, Is.EqualTo(expected));
        }
    }
}
