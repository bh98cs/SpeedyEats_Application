using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment2
{
	/// <summary>
	/// Class to store and process list of Drivers 
	/// </summary>
	/// <remarks>List holds objects of type Driver</remarks>
    public class DriverList
    {
		/// <summary>
		/// List of driver objects 
		/// </summary>
		public List<Driver> drivers { get; set; }

		/// <summary>
		/// Class constructor
		/// </summary>
		public DriverList()
		{
			drivers = new List<Driver>();
		}

		/// <summary>
		/// Method to add driver to list 
		/// </summary>
		/// <param name="driver">driver to be added to the list</param>
		/// <remarks>Method checks a duplicate driver does not already 
		/// exist within the list before adding new driver</remarks>
		public void AddDriver(Driver driver)
		{
			//check if driver is already in the list 
			if (!HasDriver(driver))
			{
				drivers.Add(driver);
			}
			else 
            {
				//throw exception that driver already exists
				DuplicateDriverException duplicateDriverException = new DuplicateDriverException();
				throw duplicateDriverException;
            }
		}

		/// <summary>
		/// Method to check whether a driver already exists within the list 
		/// </summary>
		/// <param name="driver">driver which method is checking if they already are in the list </param>
		/// <returns>boolean indicating whether the driver was found within the list</returns>
		public bool HasDriver(Driver driver)
		{
			bool hasDriver = false;
			//validation to check parameter has been provided 
			if (ReferenceEquals(null, driver))
			{
				return false;
			}
			foreach (var d in drivers)
			{
				//if the name matches a driver already in the list, a true bool is returned
				if (d.Name == driver.Name)
				{
					hasDriver = true;
				}
			}

			return hasDriver;

		}

		/// <summary>
		/// Method to retreive a driver from the list 
		/// </summary>
		/// <param name="name">name of driver to retrieve from the list</param>
		/// <returns>Driver object with the matching name </returns>
		public Driver GetDriver(string name)
		{
			//validation to check if null parameter was given
			if (String.IsNullOrEmpty(name))
			{
				//throw exception to inform no details provided
				NoDriverDetailsProvidedException noDriverDetailsProvidedException = new NoDriverDetailsProvidedException();
				throw noDriverDetailsProvidedException;
			}

			//Linq query to retrieve driver from list with matching name
			var getDriver =
				from driver in drivers
				where driver.Name == name
				select driver;

			if(getDriver.Count() < 1)
            {
				//throw exception if driver wasn't found
				DriverNotFoundException driverNotFoundException = new DriverNotFoundException();
				throw driverNotFoundException;
            }
            else
            {
				//should only be one matching driver however return first 
				return getDriver.FirstOrDefault();
            }
		}

		/// <summary>
		/// Method to remove a driver from the list
		/// </summary>
		/// <param name="driver">driver object to be removed</param>
		/// <returns>boolean indicating whether driver was successfully removed</returns>
		public bool RemoveDriver(Driver driver)
		{
			//Remove() function returns true if successfully removed
			return drivers.Remove(driver);
		}

		/// <summary>
		/// Method to remove all drivers from the list
		/// </summary>
		public void RemoveAllDrivers()
		{
			drivers.Clear();
		}

		/// <summary>
		/// Method to sort list of drivers
		/// </summary>
		/// <remarks>Sorts list alphabetically according to driver's name </remarks>
        public void SortList()
        {
			//Linq query to sort drivers alphabetically
			var driverQuery =
				from driver in drivers
				orderby driver.Name
				select driver;
			//items are removed then readded in the order of the driverQuery result
			foreach(var driver in driverQuery)
            {
				drivers.Remove(driver);
				drivers.Add(driver);
            }
        }
	}

	/// <summary>
	/// Exception for a duplicate driver 
	/// </summary>
	public class DuplicateDriverException : Exception
	{
		private static String msg = "This driver already exists!";

		public DuplicateDriverException()
			: base(msg)
		{
		}

	}

	/// <summary>
	/// Exception for null driver details being provided
	/// </summary>
	public class NoDriverDetailsProvidedException : Exception
	{
		private static String msg = "Driver details have not been provided!";

		public NoDriverDetailsProvidedException() : base(msg)
		{
		}
	}

	/// <summary>
	/// Exception for driver not being found in list
	/// </summary>
	public class DriverNotFoundException : Exception
	{
		private static String msg = "Driver not found";

		public DriverNotFoundException() : base(msg)
		{
		}
	}

}
