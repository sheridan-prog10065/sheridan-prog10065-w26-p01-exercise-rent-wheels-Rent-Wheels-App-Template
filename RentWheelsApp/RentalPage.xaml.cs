using RentWheelsLibrary;

namespace RentWheelsApp;

public partial class RentalPage : ContentPage
{
    private SpeedyRentalShop _rentalShop;
    public RentalPage(SpeedyRentalShop rentalShop)
    {
        //initialize the business logic service before any controls are created
        _rentalShop = rentalShop;
        
        InitializeComponent();

        //Connect the list of vehicles with the collection view to display the vehicle list
        _lstVehicleInventory.ItemsSource = _rentalShop.Vehicles;
        _lstRentals.ItemsSource = _rentalShop.Rentals;
        
    }

	private void OnCreateRental(object sender, EventArgs e)
	{
        //Read the input from the user
        DateTime startDate = (DateTime)_dtpStartDate.Date;
        DateTime endDate = (DateTime)_dtpEndDate.Date;
        Vehicle selectedVehicle = (Vehicle)_lstVehicleInventory.SelectedItem;

        //Use the user input to create a rental struct
        Rental contract = new Rental(selectedVehicle, startDate, endDate);
        //TODO: calculate the price of the rental using the CalculateRentalCost
        //method of the vehicle and set it in the contract

        //Add the rental contract to the list of rentals
        _rentalShop.Rentals.Add(contract);

	}
}
