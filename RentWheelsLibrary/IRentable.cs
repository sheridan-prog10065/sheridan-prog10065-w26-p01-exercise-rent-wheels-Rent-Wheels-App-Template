using System;
using System.Collections.Generic;
using System.Text;

namespace RentWheelsLibrary;

/// <summary>
/// Represents the functionality of item that can be rented
/// </summary>
public interface IRentable
{
	/// <summary>
	/// Uniquely identifies a rentable item
	/// </summary>
	string Id { get; }

	/// <summary>
	/// Describes a rentable item to be dispalyed to the user
	/// </summary>
	string Description { get; }

	/// <summary>
	/// Calculates the cost of the rental based on the given contract
	/// </summary>
	/// <param name="contract">contract that specifies start and end dates</param>
	/// <returns>the cost of the rental</returns>
	decimal CalculateRentalCost(Rental contract);
}
