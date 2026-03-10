namespace RentWheelsLibrary;

/// <summary>
/// Represents a van that derives from a generic vehicle and calculates rental cost based on passenger capacity
/// </summary>
public class Van : Vehicle
{
    private decimal PRICE_PER_DAY = 35.99m;
    private const double LARGE_PREMIUM_FACTOR = 1.25;

    public Van(string make) : base(make)
    {
    }

    public override decimal CalculateRentalCost(Rental contract)
    {
        //Vans have large size premium factor applied for a large passenger capacity 
        if (_passengerCapacity > 6)
        {
            //large van; apply the premium factor
            return PRICE_PER_DAY * contract.Duration.Days * (decimal)LARGE_PREMIUM_FACTOR;
        }

        //regular van
        return PRICE_PER_DAY * contract.Duration.Days;
    }

}