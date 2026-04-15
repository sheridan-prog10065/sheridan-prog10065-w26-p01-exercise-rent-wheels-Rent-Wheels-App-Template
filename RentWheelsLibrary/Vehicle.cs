using System;
using System.Collections.Generic;
using System.Text;

namespace RentWheelsLibrary;

/// <summary>
/// Represents a generic vehicle, the base class for all vehicle types supported by the app
/// </summary>
public abstract class Vehicle : IRentable //IS-A IRentable, implements IRentable
{
	#region Fields

	protected string _make;
	protected double _mileage;
	protected byte _passengerCapacity;
	protected string _licensePlate;

	#endregion

	#region Constructors
	public Vehicle(string make)
	{
		_make = make;
		_mileage = -1;
		_passengerCapacity = 0;
		_licensePlate = "N/A";
	}
	#endregion

	#region Properties
	public string Make
	{
		get { return _make; }
		set
		{
			//validate the input value
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new InvalidVehicleException("The vehicle make is empty. Cannot set the make of the vehicle");
			}

			_make = value;
		}
	}

	public double Mileage
	{
		get
		{
			if (_mileage <= 0)
			{
				throw new InvalidVehicleException("The mileage has not been set. Cannot return the vehicle mileage");
			}

			return _mileage;
		}
		set
		{
			//validate the new mileage value
			if (value <= 0 || value < _mileage)
			{
				throw new InvalidVehicleException("New mileage is not valid. Cannot change the mileage of the vehicle");
			}

			_mileage = value;
		}
	}

	public byte PassengerCapacity
	{
		get
		{
			if (_passengerCapacity < 2)
			{
				throw new InvalidVehicleException(
					"The passenger capacity has not been set. Cannot return the passenger capacity");
			}

			return _passengerCapacity;
		}
		set
		{
			if (value < 2)
			{
				throw new InvalidVehicleException("Cannot change the passenger capacity. Vehicle must have at least two passengers");
			}

			_passengerCapacity = value;
		}
	}

	public string LicencePlate
	{
		get
		{
			//Validate the license plate is not empty and it is not "N/A"
			if (string.IsNullOrWhiteSpace(_licensePlate) || _licensePlate == "N/A")
			{
				throw new InvalidVehicleException(
					"The license plate has not been set. Cannot return the license plate");
			}

			return _licensePlate;
		}
		set
		{
			//Validate the new value is not empty (or spaces), not "N/A", it has at least two characters and not more than 8
			if (string.IsNullOrWhiteSpace(value) || value == "N/A" || value.Length < 2 || value.Length > 8)
			{
				throw new InvalidVehicleException(
					"Invalid license plate value. License plate numbers must have between 2 and 8 characters and cannot be N/A. Cannot change the license plate number");
			}

			_licensePlate = value;
		}
	}

	//Implement the IRentable iterface properties

	public string Id
	{
		get { return this.LicencePlate; }
	}

	public string Description
	{ 
		get { return $"{_make}: {_licensePlate} with {_mileage} km, and {_passengerCapacity} passengers."; }
	}
	#endregion

	#region Methods

	public override string ToString()
	{
		return this.Description;
	}

	/// <summary>
	/// Implementation of IRentable interface method
	/// </summary>
	/// <param name="contract"></param>
	/// <returns></returns>
	public abstract decimal CalculateRentalCost(Rental contract);

	#endregion
}
