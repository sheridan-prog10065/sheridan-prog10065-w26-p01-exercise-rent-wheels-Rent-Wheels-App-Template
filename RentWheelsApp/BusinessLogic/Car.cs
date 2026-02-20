namespace RentWheelsApp.BusinessLogic;

/// <summary>
/// Represents a car that derives from vehicle and calculates rental cost based on duration and a luxary car premium
/// for luxary car makes
/// </summary>
public class Car: Vehicle
{
    private const decimal PRICE_PER_DAY = 29.99m;
    private const double LUXARY_PREMIUM_FACTOR = 1.25;
    
    public Car(string make) : base(make)
    {
    }

    public override decimal CalculateRentalCost(Rental contract)
    {
        //Determine if the car is a luxary car and apply a luxary premium
        switch (_make)
        {
            case "Mercedes":
            case "BMW":
            case "Audi":
            case "Ferrari":
            case "Lamborhini":
                //rental car is a luxary car -> apply the luxary tax
                return PRICE_PER_DAY * contract.Duration.Days * (decimal)LUXARY_PREMIUM_FACTOR;
            
            default:
                //regular car
                return PRICE_PER_DAY * contract.Duration.Days;
        }
    }
}