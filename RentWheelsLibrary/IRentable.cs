using System;
using System.Collections.Generic;
using System.Text;

namespace RentWheelsLibrary;

public interface IRentable
{
	string Id { get; }

	string Description { get; }

	decimal CalculateRentalCost(Rental contract);
}
