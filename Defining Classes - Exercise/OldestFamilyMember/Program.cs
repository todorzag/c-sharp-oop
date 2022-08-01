namespace OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] split = Console.ReadLine().Split(" ");
                string name = split[0];
                int age = int.Parse(split[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldestFamilyMember = family.GetOldestMember();

            Console.WriteLine(oldestFamilyMember.WhoAmI());
        }
    }
}