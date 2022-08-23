using Bank;

namespace BankUnitTests
{
    public class BankAccountUnitTests
    {
        private BankAccount _defaultBankAccount;

        [SetUp]
        public void Setup()
        {
            _defaultBankAccount = new BankAccount("Kircho", 100);
        }

        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(0)]
        public void SetInitialBalance_NegativeInitialBalance_ThrowException(int initalBalance)
        {
            Assert.Throws<ArgumentException>(() 
                => new BankAccount("Kircho", initalBalance));
        }

        [Test]
        public void MakeDeposit_EverythingValid_AddAmountToBalance()
        {
            _defaultBankAccount.MakeDeposit(100, "test");

            Assert.That(_defaultBankAccount.Balance, Is.EqualTo(200));
        }

        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(0)]
        public void MakeDeposit_AmountZeroOrLower_ThrowException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => _defaultBankAccount.MakeDeposit(amount, "test"));
        }

        [Test]
        public void MakeWithdrawal_EverythingValid_RemoveAmountFromBalance()
        {
            _defaultBankAccount.MakeWithdrawal(99, "test");

            Assert.That(_defaultBankAccount.Balance, Is.EqualTo(1));
        }

        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(0)]
        public void MakeWithdrawal_AmountZeroOrLower_ThrowException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => _defaultBankAccount.MakeWithdrawal(amount, "test"));
        }

        [TestCase(101)]
        [TestCase(999)]
        public void MakeWithdrawal_AmountGreaterThanBalance_ThrowException(int amount)
        {
            Assert.Throws<InvalidOperationException>(() 
                => _defaultBankAccount.MakeWithdrawal(amount, "test"));
        }
    }
}