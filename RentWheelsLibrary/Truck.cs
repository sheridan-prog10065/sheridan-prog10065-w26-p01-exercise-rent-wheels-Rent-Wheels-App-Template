namespace RentWheelsLibrary;

/// <summary>
/// Represents a Truck that derives from Vehicle and calculates rental cost based on rental duration and payload
/// </summary>
internal class Truck : Vehicle
{
    private const decimal PRICE_PER_DAY = 59.99m;

    public Truck(string make) : base(make)
    {
    }

    public override decimal CalculateRentalCost(Rental contract)
    {
        //TODO: incorporate payload as a new attribute to determine the rental cost
        return PRICE_PER_DAY * contract.Duration.Days;
    }


}