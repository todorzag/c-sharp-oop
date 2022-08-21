namespace OpinionPoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] split = Console.ReadLine().Split(" ");
                string name = split[0];
                int age = int.Parse(split[1]);

                people.Add(new Person(name, age));
            }

            List<Person> peopleOver30 = GetAllPeopleOver30(people);
            List<Person> orderedList = SortPeopleByName(peopleOver30);

            PrintPeople(orderedList);
        }
        public static List<Person> GetAllPeopleOver30(List<Person> people)
        {
            return people.Where(person => person.Age >= 30).ToList();
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