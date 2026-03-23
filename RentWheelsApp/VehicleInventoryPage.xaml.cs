using System.Diagnostics;
using RentWheelsLibrary;

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
		_lstVehicleInventory.ItemsSource = rentalShop.Inventory;
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
		Vehicle vehicle = _rentalShop.CreateVehicle(vehicleType, make);
		vehicle.Mileage = mileage;
		vehicle.PassengerCapacity = passCapacity;
		vehicle.LicencePlate = licensePlate;

		//Add the vehicle objec to the vehicle inventory in the rental shop
		_rentalShop.Inventory.Add(vehicle);
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