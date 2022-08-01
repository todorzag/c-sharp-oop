namespace DefineAClassPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Shady", 41);

            Console.WriteLine(person.WhoAmI());
        }
    }
}