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
}