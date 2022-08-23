namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter bank account name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter initial balance:");
            decimal initialBalance = ValidateAmount();

            BankAccount account = new BankAccount(name, initialBalance);

            TransactionHandler(account);

            Console.WriteLine(account.GetAccountHistory());
        }


        private static decimal ValidateAmount()
        {
            while (true)
            {
                try
                {
                    decimal amount = decimal.Parse(Console.ReadLine());
                    return amount;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a numeric value!");
                }
            }
        }

        private static void TransactionHandler(BankAccount account)
        {
            Console.WriteLine("What kind of transaction would you like to make?");
            Console.WriteLine("Deposit or Withdrawal?");

            string transactionType = Console.ReadLine();
            ValidateTransactionType(transactionType);

            Console.WriteLine("For what amount?");
            decimal amount = ValidateAmount();
            string note = AddNote();

            switch (transactionType)
            {
                case "Deposit":
                    account.MakeDeposit(amount, note);
                    break;

                case "Withdrawal":
                    account.MakeWithdrawal(amount, note);
                    break;
            }

            Console.WriteLine("Transaction Completed!");
            Console.WriteLine("Make another transaction?");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Yes":
                    TransactionHandler(account);
                    break;
            }
        }

        private static string AddNote()
        {
            Console.WriteLine("Please add a note with your transaction.");
            string note = Console.ReadLine();

            return note;
        }

        private static string ValidateTransactionType(string transactionType)
        {
            while (true)
            {
                if (transactionType != "Deposit" && transactionType != "Withdrawal")
                {
                    Console.WriteLine("Please enter valid transaction type!");
                    Console.WriteLine("Deposit or Withdrawal");

                    transactionType = Console.ReadLine();
                }
                else
                {
                    return transactionType;
                }
            }
        }
    }
}