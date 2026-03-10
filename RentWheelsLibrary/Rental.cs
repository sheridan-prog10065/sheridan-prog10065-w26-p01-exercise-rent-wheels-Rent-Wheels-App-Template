using System;
using System.Collections.Generic;
using System.Text;

namespace RentWheelsLibrary;

/// <summary>
/// Represents a rental agreement for renting a given vehicle for a given duration
/// </summary>
public struct Rental
{
    #region Fields

    private DateTime _startDate;
    private DateTime _endDate;
    private Vehicle _vehicle;
    //TODO: add a price field variable

    #endregion

    #region Constructors

    public Rental(Vehicle vehicle, DateTime startDate, DateTime endDate)
    {
        _vehicle = vehicle;
        _startDate = startDate;
        _endDate = endDate;
    }

    #endregion

    #region Properties

    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }

    //TODO: add a price property

    public TimeSpan Duration
    {
        get { return _endDate - _startDate; }
    }

    public Vehicle Vehicle
    {
        get { return _vehicle; }
    }

	#endregion

	#region Methods
	public override string ToString()
	{
        //TODO: include the price property in the string output
        return $"{_vehicle.LicencePlate} rented for {this.Duration.Days} day(s), from {_startDate.ToShortDateString()} to {_endDate.ToShortDateString()}";
	}
    #endregion
}
