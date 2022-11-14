namespace ToyRobotChallenge.Exceptions;

[Serializable]
internal class PlaceParametersInvalidException : Exception
{
    public PlaceParametersInvalidException(string message)
        : base(message) { }
}
