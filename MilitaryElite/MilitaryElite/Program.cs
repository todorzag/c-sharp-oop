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
            List<ISoldier> privates = GetPrivatesFromInput(secondaryInformation);
            Army.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
        }

        private static void AddEngineerToArmy(int id, string firstName, string lastName, decimal salary, string[] secondaryInformation)
        {
            string corp = secondaryInformation[0];
            List<Repair> repairs = GetRepairsFromInput(secondaryInformation);
            Army.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
        }

        private static List<ISoldier> GetPrivatesFromInput(string[] privateIds)
        {
            List<ISoldier> privates = new List<ISoldier>();

            foreach (string id in privateIds)
            {
                privates.Add(Army.GetPrivateById(int.Parse(id)));
            }

            return privates;
        }

        private static List<Repair> GetRepairsFromInput(string[] repairsInfo)
        {
            List<Repair> repairs = new List<Repair>();

            // Zero is Corp
            for (int i = 1; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                repairs.Add(new Repair(partName, hoursWorked));
            }

            return repairs;
        }
    }
}