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
        _lstVehicleInventory.ItemsSource = _rentalShop.Items;
        _lstRentals.ItemsSource = _rentalShop.Rentals;
        
    }

	private async void OnCreateRental(object sender, EventArgs e)
	{
        try
        {
            //Read the input from the user
            DateTime startDate = (DateTime)_dtpStartDate.Date;
            DateTime endDate = (DateTime)_dtpEndDate.Date;
            IRentable item = (IRentable)_lstVehicleInventory.SelectedItem;

            //Process the user input to rent the selected vehicle
            _rentalShop.RentItem(item, startDate, endDate);

            //Confirm the rental to the user
            await DisplayAlertAsync("Speedy Rentals", $"Your {item.Description} will be ready on {startDate:D}", "OK");
        }
        catch (NullReferenceException ex)
        {
            await DisplayAlertAsync("Rent Wheels", $"Unexpected error while creating the rental.\n\nError: {ex.Message}",
                                    "OK");
        }
        catch (ArgumentNullException ex)
        {
            await DisplayAlertAsync("Speedy Rentals", $"An item has not been selected. Please select the item to rent.\n\nError: {ex.Message}",
                                    "OK");
        }
        catch (ArgumentException ex)
        {

			await DisplayAlertAsync("Speedy Rentals", $"The rental dates are incorrect. Please select and end date after the start date.\n\nError: {ex.Message}",
						"OK");
		}
	}
}
