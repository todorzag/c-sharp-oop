using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;

        private decimal MonthlyDeposit
        {
            init
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException
                        (nameof(value), "Monthly Deposit must be positive!");
                }

                _monthlyDeposit = value;
            }
        }

        public GiftCardAccount
            (string name, decimal initialBalance, decimal monthlyDeposit)
            : base(name, initialBalance)
        {
            MonthlyDeposit = monthlyDeposit;
        }

        public override void PerformEndOfMonthTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, "Add monthly deposit");
            }
        }
    }
}
