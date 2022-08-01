namespace OpinionPoll
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

            List<Person> peopleOver30 = family.GetAllPeopleOver30();
            List<Person> orderedList = SortPeopleByName(peopleOver30);

            PrintPeople(orderedList);
        }

        public static List<Person> SortPeopleByName(List<Person> people)
        {
            return people.OrderBy(person => person.Name).ToList();
        }

        public static void PrintPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}