namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter bank account name:");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter initial balance:");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(name, initialBalance);

            TransactionHandler(account);

            Console.WriteLine(account.GetAccountHistory());
        }

        private static void TransactionHandler(BankAccount account)
        {
            Console.WriteLine("What kind of transaction would you like to make?");
            Console.WriteLine("Deposit or Withdrawal?");

            string transactionType = Console.ReadLine();

            Console.WriteLine("For what amount?");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please add a note with your transaction.");
            string note = Console.ReadLine();

            switch (transactionType)
            {
                case "Deposit":
                    account.MakeDeposit(amount, note);
                    break;

                case "Withdrawal":
                    account.MakeWithdrawal(amount, note);
                    break;

                default:
                    throw new ArgumentException("Invalid transaction type!");
            }

            Console.WriteLine("Transaction Completed!");
            Console.WriteLine("Make another transaction?");
            string answer = Console.ReadLine();

            if (answer == "Y")
            {
                TransactionHandler(account);
            }
        }
    }
}