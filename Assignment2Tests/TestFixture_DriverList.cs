using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment2;
using TestedClass = Assignment2.DriverList;

namespace Assignment2Tests
{
	/// <summary>
	/// Test fixture for DriverList class 
	/// </summary>
    [TestClass]
    public class TestFixture_DriverList
    {
		//tested class is DriverList
		private TestedClass testedClass;
		//create new driver for tests
		readonly Driver driver1 = new Driver("Driver 1");

		/// <summary>
		/// TestInitialize method to run before every test
		/// </summary>
		/// <remarks>creates new instance of testedClass and adds driver1 to the list</remarks>
		[TestInitialize]
		public void TestInitialize()
		{
			testedClass = new TestedClass();
			testedClass.drivers.Add(driver1);
		}

		/// <summary>
		/// TestCleanup method to run after every test
		/// </summary>
		/// <remarks>sets tested class to null</remarks>
		[TestCleanup]
		public void TestCleanup()
		{
			// Ensure that the tested class object reference is set to null so any actual instance can
			// be garbage collected.
			testedClass = null;

		}

		/// <summary>
		/// Method to test AddDriver()
		/// </summary>
		/// <remarks>new driver should be added successfully to the list</remarks>
		[TestMethod]
        public void AddDriver_Successful()
        {
			//create new Driver object to add to list
			Driver driver = new Driver("Driver 2");
			//int to store actual number of objects in driverList after method is called 
			int actual;
			//expected number of items within driver list after new driver is added
			int expected = 2;

			//call method which is being tested
			testedClass.AddDriver(driver);

			//store number of objects in driverList within the 'actual' variable
			actual = testedClass.drivers.Count;

			var failMessage = String.Format("List should contain {0} drivers but instead contains {1}", expected, actual);

			Assert.AreEqual(actual, expected, failMessage);

		}

		/// <summary>
		/// Method to test AddDriver()
		/// </summary>
		/// <remarks>should fail to add driver as will be a duplicate</remarks>
		[TestMethod]
		public void AddDriver_DriverAlreadyExists()
		{
			//create new driver with the same name as driver already in the list
			Driver driver = new Driver("Driver 1");

			//cast in try catch block as exception should be thrown 
            try
            {
				//call method and assert it fails 
				testedClass.AddDriver(driver);
				Assert.Fail("Expected duplicate exception");
            }
			//catch the expected exception
            catch(DuplicateDriverException)
            {

            }
		}

		/// <summary>
		/// Method to test HasDriver()
		/// </summary>
		/// <remarks>should return false to indicate driver does not exist 
		/// within the driver list</remarks>
		[TestMethod]
		public void HasDriver_False()
        {
			//create new driver object to check list for
			Driver driver = new Driver("Driver 2");

			var failMessage = String.Format("Method has returned true when it should be false.");

			//check HasDriver method returns false
			Assert.IsFalse(testedClass.HasDriver(driver), failMessage);
        }

		/// <summary>
		/// Method to test HasDriver()
		/// </summary>
		/// <remarks>should return true as driver does already exist
		/// within driver list</remarks>
		[TestMethod]
		public void HasDriver_True()
		{
			//create driver object with name that already exists within the list
			Driver driver = new Driver("Driver 1");

			var failMessage = String.Format("Method has returned false when it should be true.");

			//check that HasDriver method returns true 
			Assert.IsTrue(testedClass.HasDriver(driver), failMessage);
		}

		/// <summary>
		/// Method to test HasDriver()
		/// </summary>
		/// <remarks>should return false as a null driver object is passed 
		/// as the parameter</remarks>
		[TestMethod]
		public void HasDriver_Null()
		{
			//create new driver object which is null
			Driver driver = null;

			var failMessage = String.Format("Method has returned not null when it should be null.");

			//check method returns false 
			Assert.IsFalse(testedClass.HasDriver(driver), failMessage);
		}

		/// <summary>
		/// Method to test GetDriver()
		/// </summary>
		/// <remarks>should return driver object successfully</remarks>
		[TestMethod]
		public void GetDriver_Successful()
        {
			//string to store driver name to search for
			string driverName = "Driver 1";

			//driver which it should return is stored within 'expected' object 
			var expected = driver1;

			//driver returned by method is stored in 'actual' object
			var actual = testedClass.GetDriver(driverName);

			var failMessage = String.Format("Method has returned {0} when it should be {1}.", actual, expected);

			Assert.AreEqual(actual, expected, failMessage);
        }

		/// <summary>
		/// Method to test GetDriver()
		/// </summary>
		/// <remarks>should return null as driver does not exist within the list</remarks>
		[TestMethod]
		public void GetDriver_DriverDoesNotExist()
        {
			//string to store driver name we will search for 
			string driverName = "Doesnt Exist";

			//try catch block as exception will be thrown 
            try
            {
				testedClass.GetDriver(driverName);
				Assert.Fail("Expected driver not found exception");
            }
			//catch expected exception
            catch (DriverNotFoundException)
            {

            }
        }

		/// <summary>
		/// Method to test GetDriver()
		/// </summary>
		/// <remarks>should return null as driver does not exist within the list</remarks>
		[TestMethod]
		public void GetDriver_NullParameter()
		{
			//variable which is null to be used as parameter 
			string driverName = null;

			//try catch block as exception will be thrown 
			try
			{
				testedClass.GetDriver(driverName);
				Assert.Fail("Expected driver not found exception");
			}
			//catch expected exception
			catch (NoDriverDetailsProvidedException)
			{

			}
		}

		/// <summary>
		/// Method to test RemoveDriver()
		/// </summary>
		/// <remarks>should successfully remove driver from the list</remarks>
		[TestMethod]
		public void RemoveDriver_Successful()
        {
			//expected outcome is for a true boolean to be returned
			bool expected = true;
			bool actual;

			//driver is removed from list and boolean returned is stored in 'actual' variable
			actual = testedClass.RemoveDriver(driver1);

			var failMessage = String.Format("Method should return {0} but returns {1}", actual, expected);

			Assert.IsTrue(actual, failMessage);

		}

		/// <summary>
		/// Method to test RemoveDriver()
		/// </summary>
		/// <remarks>should return false as a null parameter is provided</remarks>
		[TestMethod]
		public void RemoveDriver_NullDriverAsParameter()
        {
			//expected outcome is for a false boolean to be returned
			bool expected = false;
			bool actual;

			//create new driver object which is null
			Driver driver = new Driver(null);

			//store bool returned in 'actual' variable
			actual = testedClass.RemoveDriver(driver);

			var failMessage = String.Format("Method should return {0} but returns {1}", expected, actual);

			Assert.IsFalse(actual, failMessage);
		}

		/// <summary>
		/// Method to test RemoveDriver()
		/// </summary>
		/// <remarks>Should return false as driver does not exist within the list</remarks>
		[TestMethod]
		public void RemoveDriver_DriverDoesntExist()
		{
			//expected outcome is for the method to return false 
			bool expected = false;
			bool actual;

			//new driver object is created which doesnt exist within the list
			Driver driver = new Driver("Driver 2");

			//bool returned is stored within 'actual' variable
			actual = testedClass.RemoveDriver(driver);

			var failMessage = String.Format("Method should return {0} but returns {1}", expected, actual);

			Assert.IsFalse(actual, failMessage);
		}

		/// <summary>
		/// Method to test RemoveAllDrivers() 
		/// </summary>
		/// <remarks>should successfully remove all items from drivers list</remarks>
		[TestMethod]
		public void RemoveAllDrivers_Successful()
        {
			int actual;
			//driver list should have 0 items after the method is called 
			int expected = 0;

			testedClass.RemoveAllDrivers();

			//after method is called store the number of items in drivers list within 'actual' variable
			actual = testedClass.drivers.Count;

			var failMessage = String.Format("List contains {0} elements when it should contain {1}.", actual, expected);

			Assert.AreEqual(actual, expected);
        }

		/// <summary>
		/// Method to test SortList()
		/// </summary>
		/// <remarks>list should be sorted successfully</remarks>
		[TestMethod]
		public void SortList_Successful()
        {
			//expected driver object to be top of the drivers list
			Driver expected = new Driver("AA");
			Driver actual;

			//add driver which should be at the top of the list after sorting 
			testedClass.drivers.Add(expected);

			testedClass.SortList();

			//store the object at the top of the drivers list within 'actual' variable
			actual = testedClass.drivers[0];

			var failMessage = String.Format("First object is {0} when it should be {1}.", actual, expected);

			Assert.AreEqual(actual, expected);
        }

	}
}
