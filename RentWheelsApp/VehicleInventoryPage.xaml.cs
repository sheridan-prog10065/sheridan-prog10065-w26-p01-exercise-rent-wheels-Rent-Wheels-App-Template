using System.Diagnostics;
using RentWheelsApp.BusinessLogic;

namespace RentWheelsApp;

public partial class VehicleInventoryPage : ContentPage
{
	private SpeedyRentalShop _rentalShop;
	
	public VehicleInventoryPage(SpeedyRentalShop rentalShop)
	{
		//initialize the business logic service before any controls are created
		_rentalShop = rentalShop;
		
		InitializeComponent();
		
		//Bind the list of vehicles to the collection view AFTER it has been initialized
		//by the InitiliateComponent() call above
		_lstVehicleInventory.ItemsSource = rentalShop.Vehicles;
	}

	private void OnAddVehicle(object sender, EventArgs e)
	{
		//Read all the vehicle properties that the user has entered
		string vehicleType = (string)_pckVehicleType.SelectedItem;
		string make = _txtMake.Text;
		byte passCapacity = byte.Parse(_txtPassengerCapacity.Text);
		double mileage = double.Parse(_txtMileage.Text);
		string licensePlate = _txtLicensePlate.Text;

		//Create a vehicle object and fill it with the user data
		Vehicle vehicle = CreateVehicle(vehicleType, make);
		vehicle.Mileage = mileage;
		vehicle.PassengerCapacity = passCapacity;
		vehicle.LicencePlate = licensePlate;

		//Add the vehicle objec to the vehicle inventory in the rental shop
		_rentalShop.Vehicles.Add(vehicle);
	}

	/// <summary>
	/// Creates a concrete vehicle object based on the given vehicle type and make.
	/// The rest of the program uses the vehicle types generically through the Vehicle
	/// base class
	/// </summary>
	/// <param name="vehicleType">the type of vehicle to create: car, van or truck</param>
	/// <param name="make">the make of vehicle</param>
	/// <returns></returns>
	private Vehicle CreateVehicle(string vehicleType, string make)
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
				return new Vehicle(make);
		}
	}

	private void OnClear(object sender, EventArgs e)
	{
		//Use the empty string or the String.Empty constant
		_pckVehicleType.SelectedItem = null;
		_txtMake.Text = "";
		_txtMileage.Text = "";
		_txtLicensePlate.Text = string.Empty;
		_txtPassengerCapacity.Text = string.Empty;
	}
}