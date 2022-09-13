namespace MilitaryElite.Other
{
    internal interface IRepair
    {
        int HoursWorked { get; }
        string PartName { get; }

        string ToString();
    }
}