using Moq;
using ToyRobotChallenge.BusinessLogic;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Models;

namespace UnitTests;

internal class ToyRobotCommandServiceTests
{
    private ToyRobotCommandService toyRobotCommandService;
   
    private Mock<IToyRobotService> toyRobotServiceMock;
    private Mock<ICommandParserService> commandParserServiceMock;

    [SetUp]
    public void Setup()
    {
        this.toyRobotServiceMock = new Mock<IToyRobotService>();
        this.commandParserServiceMock = new Mock<ICommandParserService>();
        this.toyRobotCommandService = new ToyRobotCommandService(toyRobotServiceMock.Object, commandParserServiceMock.Object);
    }

    [Test]
    public void Given_Place_Command_Assert_Place_Called()
    {
        commandParserServiceMock.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new Command(AvailableCommands.Place) { Direction = Direction.North, Position = new Position(0,0)});
              
        toyRobotCommandService.Command("command");
              
        toyRobotServiceMock.Verify(x => x.Place(It.IsAny<Position>(), It.IsAny<Direction>()), Times.Once);             
    }

    [Test]
    public void Given_Move_Command_Assert_Move_Called()
    {
        commandParserServiceMock.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new Command(AvailableCommands.Move));

        toyRobotCommandService.Command("command");

        toyRobotServiceMock.Verify(x => x.Move(), Times.Once);
    }

    [Test]
    public void Given_Left_Command_Assert_Left_Called()
    {
        commandParserServiceMock.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new Command(AvailableCommands.Left));

        toyRobotCommandService.Command("command");

        toyRobotServiceMock.Verify(x => x.Left(), Times.Once);
    }

    [Test]
    public void Given_Right_Command_Assert_Left_Called()
    {
        commandParserServiceMock.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new Command(AvailableCommands.Right));

        toyRobotCommandService.Command("command");

        toyRobotServiceMock.Verify(x => x.Right(), Times.Once);
    }

    [Test]
    public void Given_Report_Called_Assert_Position_And_Direction_Rerieved()
    {
        commandParserServiceMock.Setup(x => x.Parse(It.IsAny<string>()))
            .Returns(new Command(AvailableCommands.Report));

        toyRobotServiceMock.Setup(x => x.GetPosition()).Returns(new Position(0, 0));
        toyRobotServiceMock.Setup(x => x.GetDirection()).Returns(Direction.North);

        toyRobotCommandService.Command("command");

        toyRobotServiceMock.Verify(x => x.GetDirection(), Times.Once);
        toyRobotServiceMock.Verify(x => x.GetPosition(), Times.Once);
    }
}
