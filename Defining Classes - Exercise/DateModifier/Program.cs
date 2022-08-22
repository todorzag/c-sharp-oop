namespace DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            dateModifier.GetDateDifference(date1, date2);

            Console.WriteLine(dateModifier.DayDifference);
        }
    }
}