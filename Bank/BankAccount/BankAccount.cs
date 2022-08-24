using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1;
        private readonly decimal _minimumBalance;
        private List<Transaction> _allTransactions = new List<Transaction>();

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in _allTransactions)
                {
                    balance += transaction.Amount;
                }

                return balance;
            }
        }
        private decimal InitialBalance
        {
            init
            {
                ValidateInitialBalanceThrowException(value);
                MakeDeposit(value, "Initial balance");
            }
        }

        public BankAccount(string name, decimal initialBalance)
            : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            accountNumberSeed++;
            Number = accountNumberSeed.ToString();

            Owner = name;
            _minimumBalance = minimumBalance;
            InitialBalance = initialBalance;
        }

        public void MakeDeposit(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException
                    (nameof(amount), "Amount of deposit must be positive");
            }

            Transaction deposit = new Transaction
                (amount, DateTime.Now, "deposit", note);

            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    "Amount of withdrawal must be positive");
            }

            Transaction? overdraftTransaction =
                CheckWithdrawalLimit(Balance - amount < _minimumBalance);

            Transaction withdrawal = new Transaction
                (-amount, DateTime.Now, "withdrawal", note);

            if (overdraftTransaction != null)
            {
                _allTransactions.Add(overdraftTransaction);
            }

            _allTransactions.Add(withdrawal);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException
                    ("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            StringBuilder accountHistory = new StringBuilder();

            foreach (var transaction in _allTransactions)
            {
                decimal transactionAmount =
                    transaction.Amount < 0
                    ? transaction.Amount * -1
                    : transaction.Amount;

                accountHistory.AppendLine($"A {transaction.Type} was made on: {transaction.Date}");
                accountHistory.AppendLine($"For: {transactionAmount}");
                accountHistory.AppendLine($"Note: {transaction.Note}");
            }

            return accountHistory.ToString();
        }

        public virtual void PerformEndOfMonthTransactions() { }

        private void ValidateInitialBalanceThrowException(decimal initialBalance)
        {
            if (initialBalance <= _minimumBalance)
            {
                throw new ArgumentException("Initial Balance must be greater than 0!");
            }
        }
    }
}
