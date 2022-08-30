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

        [TestCase(100)]
        public void SetInitialBalance_InitalBalanceIsValid_AccountIsCreated(int initalBalance)
        {
            BankAccount bankAccount = new BankAccount("Kircho", initalBalance);

            Assert.That(bankAccount.Balance, Is.EqualTo(initalBalance));
        }

        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(0)]
        public void SetInitialBalance_NegativeInitialBalance_ThrowException(int initalBalance)
        {
            Assert.Throws<ArgumentException>(() 
                => new BankAccount("Kircho", initalBalance));
        }

        [TestCase(100, 200)]
        [TestCase(50, 150)]
        public void MakeDeposit_EverythingValid_AddAmountToBalance(int amount, int expected)
        {
            _defaultBankAccount.MakeDeposit(amount, "test");

            Assert.That(_defaultBankAccount.Balance, Is.EqualTo(expected));
        }

        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(0)]
        public void MakeDeposit_AmountZeroOrLower_ThrowException(int amount)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => _defaultBankAccount.MakeDeposit(amount, "test"));
        }

        [TestCase(99, 1)]
        [TestCase(50, 50)]
        public void MakeWithdrawal_EverythingValid_RemoveAmountFromBalance(int amount, int expected)
        {
            _defaultBankAccount.MakeWithdrawal(amount, "test");

            Assert.That(_defaultBankAccount.Balance, Is.EqualTo(expected));
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