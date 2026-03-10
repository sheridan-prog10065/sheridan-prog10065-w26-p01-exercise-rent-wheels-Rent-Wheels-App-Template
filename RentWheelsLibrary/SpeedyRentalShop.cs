using System.Collections.ObjectModel;

namespace RentWheelsLibrary;

public class SpeedyRentalShop
{ 
	#region Fields

	private ObservableCollection<Vehicle> _vehicleInventory;
	private ObservableCollection<Rental> _rentalList;

	#endregion

	#region Constructors

	public SpeedyRentalShop()
	{
		_vehicleInventory = new ObservableCollection<Vehicle>();
		_rentalList = new ObservableCollection<Rental>();
		
		//Create default vehicle
		CreateDefaultVehicles();
	}

	#endregion
	
	#region Properties

	public ObservableCollection<Vehicle> Vehicles
	{
		get { return _vehicleInventory; }
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
		Vehicle carOne = new Vehicle("Hyundai");
		carOne.Mileage = 10000;
		carOne.PassengerCapacity = 5;
		carOne.LicencePlate = "ABC 1234";
		_vehicleInventory.Add(carOne);

		//Create second default vehicle and add to list
		Vehicle luxaryCar = new Vehicle("BMW");
		luxaryCar.Mileage = 500;
		luxaryCar.PassengerCapacity = 2;
		luxaryCar.LicencePlate = "SPEED 1";
		_vehicleInventory.Add(luxaryCar);

		//Create third default vehicle and add to list
		Vehicle familyCar = new Vehicle("Honda Odyssey");
		familyCar.Mileage = 17000;
		familyCar.PassengerCapacity = 7;
		familyCar.LicencePlate = "YMCA 123";
		_vehicleInventory.Add(familyCar);
	}

	#endregion

}