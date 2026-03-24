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
    private IRentable _item;
    private decimal _price;

    #endregion

    #region Constructors

    public Rental(IRentable item, DateTime startDate, DateTime endDate)
    {
        _item = item;
        _startDate = startDate;
        _endDate = endDate;
        _price = 0m;
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

    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = value;
        }
    }

    public TimeSpan Duration
    {
        get { return _endDate - _startDate; }
    }

    public IRentable Item
    {
        get { return _item; }
    }

	#endregion

	#region Methods
	public override string ToString()
	{
        return $"{_item.Id} rented for {this.Duration.Days} day(s), from {_startDate.ToShortDateString()} to {_endDate.ToShortDateString()} for {_price} CAD";
	}
    #endregion
}
