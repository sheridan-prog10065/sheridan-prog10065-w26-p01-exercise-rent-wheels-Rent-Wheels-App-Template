using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RentWheelsLibrary;

public class SpeedyRentalShop
{ 
	#region Fields

	private ObservableCollection<IRentable> _itemInventory;
	private ObservableCollection<Rental> _rentalList;

	#endregion

	#region Constructors

	public SpeedyRentalShop()
	{
		_itemInventory = new ObservableCollection<IRentable>();
		_rentalList = new ObservableCollection<Rental>();
		
		//Create default vehicle
		CreateDefaultVehicles();
	}

	#endregion
	
	#region Properties

	public ObservableCollection<IRentable> Inventory
	{
		get { return _itemInventory; }
	}

	public ObservableCollection<Rental> Rentals
	{
		get { return _rentalList; }
	}

	#endregion

	#region Methods

	/// <summary>
	/// Create three default vehicle objects, initializes all their properties and add them to the vehicle list
	/// </summary>
	private void CreateDefaultVehicles()
	{
		//Create first default vehicle and add to list
		Vehicle carOne = new Car("Toyota");
		carOne.Mileage = 10000;
		carOne.PassengerCapacity = 5;
		carOne.LicencePlate = "ABC 1234";
		_itemInventory.Add(carOne);

		//Create second default vehicle and add to list
		Vehicle luxaryCar = new Car("BMW");
		luxaryCar.Mileage = 500;
		luxaryCar.PassengerCapacity = 2;
		luxaryCar.LicencePlate = "SPEED 1";
		_itemInventory.Add(luxaryCar);

		//Create third default vehicle and add to list
		Vehicle familyCar = new Van("Honda Odyssey");
		familyCar.Mileage = 17000;
		familyCar.PassengerCapacity = 7;
		familyCar.LicencePlate = "YMCA 123";
		_itemInventory.Add(familyCar);
	}

	/// <summary>
	/// Creates a concrete vehicle object based on the given vehicle type and make.
	/// The rest of the program uses the vehicle types generically through the Vehicle
	/// base class
	/// </summary>
	/// <param name="vehicleType">the type of vehicle to create: car, van or truck</param>
	/// <param name="make">the make of vehicle</param>
	/// <returns></returns>
	public Vehicle CreateVehicle(string vehicleType, string make)
	{
		//Check the vehicle type and create the correspohnding objecy
		switch (vehicleType)
		{
			case "Car":
				return new Car(make);

			case "Truck":
				return new Truck(make);

			case "Van":
				return new Van(make);

			default:
				Debug.Assert(false, "Unknown vehicle type");
				return null;
		}
	}

	/// <summary>
	/// Create a rental contract for the given vehicle with the period requested
	/// </summary>
	/// <param name="item">vehicle to rent</param>
	/// <param name="startDate">start of the rental period</param>
	/// <param name="endDate">end of the rental period</param>
	/// <exception cref="NotImplementedException"></exception>
	public Rental RentItem(IRentable item, DateTime startDate, DateTime endDate)
	{
		//Step 1: Obtain and validate the input (e.g. parameters or field variables)
		if (item == null)
		{
			//TODO: throw an exception identifying an invalid contract
		}

		if (startDate < DateTime.Today || endDate <= startDate)
		{
			//TODO: throw an exception identifying an invalid contract
		}

		//Step 2: Process the input (e.g. creating and keeping track of objects
		//create the contract
		Rental contract = new Rental(item, startDate, endDate);

		//calculate the price
		decimal price = item.CalculateRentalCost(contract); //this is a polymorphic method

		//record the price in the contract
		contract.Price = price;

		//Step 3: Provide the "output" (e.g. returning, setting field variables,saving information...)
		_rentalList.Add(contract);
		return contract;
	}

	#endregion

}