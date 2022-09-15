using MilitaryElite.Models.Interfaces;
using MilitaryElite.Models.Items;
using MilitaryElite.Models.Soldiers;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitInput = input.Split(" ");

                string soldierType = splitInput[0];
                int id = int.Parse(splitInput[1]);
                string firstName = splitInput[2];
                string lastName = splitInput[3];
                decimal salary;
                string corps;

                switch (soldierType)
                {
                    case "Private":
                        salary = decimal.Parse(splitInput[4]);

                        AddPrivateToArmy(id, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(splitInput[4]);
                        string[] privateIds = splitInput[5..splitInput.Length];

                        AddLieutenantGeneralToArmy(id, firstName, lastName, salary, privateIds);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(splitInput[4]);
                        corps = splitInput[5];
                        string[] repairInfo = splitInput[6..splitInput.Length];

                        AddEngineerToArmy(id, firstName, lastName, salary, corps, repairInfo);
                        break;

                    case "Commando":
                        salary = decimal.Parse(splitInput[4]);
                        corps = splitInput[5];
                        string[] missionInfo = splitInput[6..splitInput.Length];

                        AddCommandoToArmy(id, firstName, lastName, salary, corps, missionInfo);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(splitInput[4]);

                        AddSpyToArmy(id, firstName, lastName, codeNumber);
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

        private static void AddLieutenantGeneralToArmy(int id, string firstName, string lastName, decimal salary, string[] privateIds)
        {
            LieutenantGeneral lieutenant = new LieutenantGeneral(id, firstName, lastName, salary);
            AddPrivatesFromInput(lieutenant, privateIds);
            Army.Add(lieutenant);
        }

        private static void AddEngineerToArmy(int id, string firstName, string lastName, decimal salary, string corps, string[] repairInfo)
        {
            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            AddRepairsFromInput(engineer, repairInfo);

            Army.Add(engineer);
        }

        private static void AddCommandoToArmy(int id, string firstName, string lastName, decimal salary, string corps, string[] missionInfo)
        {
            Commando commando = new Commando(id, firstName, lastName, salary, corps);
            AddMissionsFromInput(commando, missionInfo);

            Army.Add(commando);
        }

        private static void AddSpyToArmy(int id, string firstName, string lastName, int codeNumber)
        {
            Army.Add(new Spy(id, firstName, lastName, codeNumber));
        }


        private static void AddPrivatesFromInput(LieutenantGeneral lieutenant, string[] privateIds)
        {
            foreach (string id in privateIds)
            {
                ISoldier privateSoldier = Army.GetPrivateById(int.Parse(id));

                if (privateSoldier != null)
                {
                    lieutenant.AddToCommandingPrivates(privateSoldier);
                }
            }
        }

        private static void AddMissionsFromInput(Commando commando, string[] missionsInfo)
        {
            for (int i = 1; i < missionsInfo.Length - 1; i += 2)
            {
                string codeName = missionsInfo[i];
                string state = missionsInfo[i + 1];

                commando.AddMissions(new Mission(codeName, state));
            }
        }

        private static void AddRepairsFromInput(Engineer engineer, string[] repairsInfo)
        {
            for (int i = 1; i < repairsInfo.Length - 1; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                engineer.AddRepairs(new Repair(partName, hoursWorked));
            }
        }
    }
}