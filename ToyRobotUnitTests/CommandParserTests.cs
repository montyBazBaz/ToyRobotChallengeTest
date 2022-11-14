using FluentAssertions;
using ToyRobotChallenge.BusinessLogic;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Exceptions;
using ToyRobotChallenge.Models;

namespace UnitTests;

internal class CommandParserTests
{
    private ICommandParserService commandParserService;

    [SetUp]
    public void Setup()
    {
        this.commandParserService = new CommandParserService();
    }

    [TestCase]
    public void Given_Valid_Place_Command_Text_Return_Valid_Command()
    {
        var expectedResult = new Command(AvailableCommands.Place);
        expectedResult.Position = new Position(0, 0);
        expectedResult.Direction = Direction.East;

        var response = commandParserService.Parse("PLACE 0,0,EAST");

        response.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void Given_Place_Command_Lower_and_upper_Case_Assert_Valid()
    {
        var expectedResult = new Command(AvailableCommands.Place);
        expectedResult.Position = new Position(0, 0);
        expectedResult.Direction = Direction.East;

        var response = commandParserService.Parse("PLACE 0,0,East");

        response.Should().BeEquivalentTo(expectedResult);
    }

    [TestCase("PLACE 0 0,East", true)]
    [TestCase("PLACE 00,East", true)]
    [TestCase("PLACE 0,0,East1", true)]
    [TestCase("PLACE 0,0,East", false)]
    public void Given_Place_Command_Invalid_Position_Assert_Exception_Thrown(string text, bool shouldThrow)
    {
        var act = () => commandParserService.Parse(text);

        if (shouldThrow)
        {
            act.Should().ThrowExactly<PlaceParametersInvalidException>();
        }
        else
        {
            act.Should().NotThrow();
        }
    }


    [TestCase("MOVE", false)]
    [TestCase("LEFT", false)]
    [TestCase("RIGHT", false)]
    [TestCase("REPORT", false)]
    [TestCase("UP", true)]
    [TestCase("DOWN", true)]
    public void Given_Command_Name_Not_Known_Throw_Exception(string text, bool shouldThrow)
    {
        var act = () => commandParserService.Parse(text);

        if (shouldThrow)
        {
            act.Should().ThrowExactly<CommandNotKnownException>();
        }
        else
        {
            act.Should().NotThrow();
        }
    }
}
