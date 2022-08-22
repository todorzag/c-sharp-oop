namespace FootballTeamGenerator.UnitTests;

[TestFixture]
public class TeamTests : TestData
{
    private Player _defaultPlayer;
    private Team _defaultTeam;

    [SetUp]
    public void Setup()
    {
        _defaultPlayer =
            new Player(stubPlayerName, stubEndurance, stubShooting, stubDribble, stubPassing, stubSprint);

        _defaultTeam = new Team(stubTeamName);
    }

    [TestCase("Spartak Shturkovo")]
    public void ValidateName_NameIsValid_SetTeamName(string mockName)
    {
        Team team = new Team(mockName);
        Assert.That(team.Name, Is.EqualTo(mockName));
    }

    [TestCase(" ")]
    public void ValidateName_NameIsEmpty_ThrowException(string mockName)
    {
        Assert.Throws<ArgumentException>(() => new Team(mockName));
    }

    [TestCase(null)]
    public void ValidateName_NameIsNull_ThrowException(string mockName)
    {
        Assert.Throws<ArgumentException>(() => new Team(mockName));
    }

    [Test]
    public void AddPlayer_PlayerIsValid_PlayerIsAddedToTeam()
    {
        _defaultTeam.AddPlayer(_defaultPlayer);
        Assert.That(_defaultTeam.PlayerCount, Is.EqualTo(1));
    }

    [Test]
    public void RemovePlayer_PlayerIsValid_PlayerIsAddedToTeam()
    {
        _defaultTeam.AddPlayer(_defaultPlayer);
        _defaultTeam.RemovePlayer(_defaultPlayer.Name);
        Assert.That(_defaultTeam.PlayerCount, Is.EqualTo(0));
    }

    [TestCase("Kircho")]
    public void HasPlayer_PlayerIsInTeam_ReturnTrue(string mockPlayerName)
    {
        Player mockPlayer = CreatePlayer(mockPlayerName);

        _defaultTeam.AddPlayer(mockPlayer);

        Assert.That
            (_defaultTeam.HasPlayer(mockPlayerName, _defaultTeam.Name), 
            Is.True);
    }

    [TestCase("Kircho", "Todor")]
    public void HasPlayer_PlayerIsNotInTeam_ReturnFalse(string mockPlayerNameInTeam, string mockPlayerNameNotInTeam)
    {
        Player mockPlayer = CreatePlayer(mockPlayerNameInTeam);

        _defaultTeam.AddPlayer(mockPlayer);

        Assert.That
            (_defaultTeam.HasPlayer(mockPlayerNameNotInTeam, _defaultTeam.Name),
            Is.False);
    }

    [Test]
    public void CalculateRating_TeamIsValid_ReturnsAverageOfPlayerOverall()
    {
        Team teamWithPlayers = CreateTeamWithPlayers();

        Assert.That(teamWithPlayers.Rating, Is.EqualTo(13));
    }
}

