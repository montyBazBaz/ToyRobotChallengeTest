namespace ToyRobotChallenge.Exceptions;

[Serializable]
internal class CommandNotKnownException : Exception
{
    public CommandNotKnownException(string message)
        : base(message) { }
}
