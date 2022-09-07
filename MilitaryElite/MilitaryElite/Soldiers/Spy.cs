using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    internal class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; }

        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} CodeNumber: {CodeNumber}";
        }
    }
}