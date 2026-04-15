namespace RentWheelsLibrary;

/// <summary>
/// Represents business logic exceptions generated when attempts are made to change
/// a vehicle object using incorrect data
/// </summary>
public class InvalidVehicleException : Exception //Derive, IS-A Exception
{
    public InvalidVehicleException(string message) : base(message)
    {
    }
}