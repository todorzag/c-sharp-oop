using MilitaryElite.Soldiers;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] split = input.Split(" ");

                string soldierType = split[0];
                int id = int.Parse(split[1]);
                string firstName = split[2];
                string lastName = split[3];
                decimal salary = decimal.Parse(split[4]);


                string[] secondaryInformation = split[5..split.Length];

                switch (soldierType)
                {
                    case "Private":
                        AddPrivateToArmy(id, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        AddLieutenantGeneralToArmy(id, firstName, lastName, salary, secondaryInformation);
                        break;

                    case "Engineer":
                        AddEngineerToArmy(id, firstName, lastName, salary, secondaryInformation);
                        break;

                    case "Commando":
                        AddCommandoToArmy(id, firstName, lastName, salary, secondaryInformation);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(split[4]);
                        AddSpyToArmy(id, firstName, lastName, codeNumber);
                        break ;
                }

                input = Console.ReadLine();
            }

            Army.PrintArmy();
        }

        private static void AddPrivateToArmy(int id, string firstName, string lastName, decimal salary)
        {
            Army.Add(new Private(id, firstName, lastName, salary));
        }

        private static void AddLieutenantGeneralToArmy(int id, string firstName, string lastName, decimal salary, string[] secondaryInformation)
        {
            LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
            lieutenant.AddPrivates(secondaryInformation);
            Army.Add(lieutenant);
        }

        private static void AddEngineerToArmy(int id, string firstName, string lastName, decimal salary, string[] secondaryInformation)
        {
            string corps = secondaryInformation[0];

            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            engineer.AddRepairs(secondaryInformation.Skip(1).ToArray());

            Army.Add(engineer);
        }

        private static void AddCommandoToArmy(int id, string firstName, string lastName, decimal salary, string[] secondaryInformation)
        {
            string corps = secondaryInformation[0];

            Commando commando = new Commando(id, firstName, lastName, salary, corps);
            commando.AddMissions(secondaryInformation);

            Army.Add(commando);
        }

        private static void AddSpyToArmy(int id, string firstName, string lastName, int codeNumber)
        {
            Army.Add(new Spy(id, firstName, lastName, codeNumber));
        }
    }
}