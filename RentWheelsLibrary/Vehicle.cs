using System;
using System.Collections.Generic;
using System.Text;

namespace RentWheelsLibrary;

/// <summary>
/// Represents a generic vehicle, the base class for all vehicle types supported by the app
/// </summary>
public abstract class Vehicle : IRentable
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
		_mileage = 0;
		_passengerCapacity = 0;
		_licensePlate = "N/A";
	}
	#endregion

	#region Properties
	public string Make
	{
		get { return _make; }
		set { _make = value;}
	}

	public double Mileage
	{
		get { return _mileage; }
		set { _mileage = value; }
	}

	public byte PassengerCapacity
	{
		get { return _passengerCapacity; }
		set { _passengerCapacity = value; }
	}

	public string LicencePlate
	{
		get { return _licensePlate; }
		set { _licensePlate = value; }
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
