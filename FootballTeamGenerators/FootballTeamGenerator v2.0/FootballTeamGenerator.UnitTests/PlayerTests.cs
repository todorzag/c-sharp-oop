namespace FootballTeamGenerator.UnitTests;

[TestFixture]
public class PlayerTests : TestData
{
    private Player _defaultPlayer;

    [SetUp]
    public void Setup()
    {
        _defaultPlayer = 
            new Player(stubPlayerName, stubEndurance, stubShooting, stubDribble, stubPassing, stubSprint);
    }

    [TestCase("Kircho")]
    public void ValidateName_NameIsValid_SetName(string mockName)
    {
        Player player = CreatePlayer(mockName);

        Assert.That(player.Name, Is.EqualTo(mockName));
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void ValidateName_NameIsFalsy_ThrowException(string mockName)
    {
        Assert.Throws<ArgumentException>(() => CreatePlayer(mockName));
    }

    [TestCase(12, 14)]
    [TestCase(0, 100)]
    public void ValidateStat_StatsAreInRange_SetStats(int mockEndurance, int mockPassing)
    {
        Player player = CreatePlayer(mockEndurance, mockPassing);

        Assert.That(player.Endurance, Is.EqualTo(mockEndurance));
        Assert.That(player.Passing, Is.EqualTo(mockPassing));
    }

    [TestCase(-1, 14)]
    [TestCase(12, -100)]
    [TestCase(999, 14)]
    [TestCase(12, 101)]
    [TestCase(-1, 999)]
    public void ValidateStat_StatsAreNotInRange_ThrowException(int mockEndurance, int mockPassing)
    {
        Assert.Throws<ArgumentException>(() => CreatePlayer(mockEndurance, mockPassing));
    }

    [Test]
    public void GetOverall_EverythingIsValid_AverageOfPlayerStats()
    {
        Assert.That(_defaultPlayer.Overall, Is.EqualTo(13));
    }
}