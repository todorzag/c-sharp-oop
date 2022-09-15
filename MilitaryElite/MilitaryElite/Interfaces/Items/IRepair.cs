namespace MilitaryElite.Models.Interfaces
{
    internal interface IRepair
    {
        int HoursWorked { get; }
        string PartName { get; }

        string ToString();
    }
}