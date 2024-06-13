using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment2;
using TestedClass = Assignment2.JourneyList;

namespace Assignment2Tests
{
    /// <summary>
    /// Test fixture to test JourneyList class 
    /// </summary>
    [TestClass]
    public class TestFixture_JourneyList
    {
        //tested class is JourneyList
        private TestedClass testedClass;
        //new driver object
        static Driver driver = new Driver("Driver");
        //date to use for journeys 
        const string date = "11/04/2023";

        //two new journey objects 
        readonly Journey journey = new Journey(driver, DateTime.Parse(date), "NE29 1XX", "SR5 1AB", 15);
        readonly Journey journey2 = new Journey(driver, DateTime.Parse(date), "SR5 1XX", "SR5 1AB", 3);

        /// <summary>
        /// TestInitialize method to run before each test 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            //create new instance of tested class 
            testedClass = new TestedClass();
            //add journeys to journey list 
            testedClass.journeys.Add(journey);
            testedClass.journeys.Add(journey2);
        }

        /// <summary>
        /// TestCleanup to run after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            //set tested class to null
            testedClass = null;
        }

        /// <summary>
        /// Method to test HasJourney()
        /// </summary>
        /// <remarks>tested method should return a true boolean</remarks>
        [TestMethod]
        public void HasJourney_IsTrue()
        {
            //expected result of the tested method 
            bool expected = true;
            //result of the method is stored within 'actual' variable
            //passing in parameters which match a journey within the list
            bool actual = testedClass.HasJourney(journey.DeliveryAddress, journey.Date);

            var failMessage = String.Format("Method should return {0} but returns {1}.", expected, actual);

            Assert.IsTrue(actual, failMessage);
        }

        /// <summary>
        /// Method to test HasJourney()
        /// </summary>
        /// <remarks>should return false boolean</remarks>
        [TestMethod]
        public void HasJourney_IsFalse()
        {
            //expected result of method 
            bool expected = false;
            //result of method is stored within 'actual' boolean
            //passing in parameters which do not match with a journey within the list
            bool actual = testedClass.HasJourney("NE1 1AA", DateTime.Parse("11/04/2023"));

            var failMessage = String.Format("Method should return {0} but returns {1}.", expected, actual);

            Assert.IsFalse(actual, failMessage);
        }

        /// <summary>
        /// Method to test HasJourney()
        /// </summary>
        /// <remarks>should throw exception as null delivery parameter is provided</remarks>
        [TestMethod]
        public void HasJourney_DeliveryIsNull()
        {
            //try catch as exception will be thrown 
            try
            {
                //pass null delivery parameter
                testedClass.HasJourney(null, DateTime.Today);
                Assert.Fail("Expected no journey details exception");
            }
            //catch expected exception
            catch (NoJourneyDetailsProvidedException)
            {

            }
        }

        /// <summary>
        /// Method to test GetLongestDistance()
        /// </summary>
        /// <remarks>should successfully return longest distance </remarks>
        [TestMethod]
        public void GetLongestDistance_Successful()
        {
            //new journey object for testing 
            Journey newJourney = new Journey(driver, DateTime.Today, "XXXXX", "XXXXX", 15);

            //add journey to journey list 
            testedClass.journeys.Add(newJourney);

            //new journey should be returned as from tested method as is the most recent 
            //journey with the joint longest distance 
            Journey expected = newJourney;
            
            //result of the method is stored within 'actual' variable
            Journey actual = testedClass.GetLongestDistance();

            var failMessage = String.Format("Method should return {0} but returns {1}.", expected.Distance, actual.Distance);

            Assert.AreEqual(actual, expected, failMessage);

        }

        /// <summary>
        /// Method to test GetJourney()
        /// </summary>
        /// <remarks>should successfully return the correct journey</remarks>
        [TestMethod]
        public void GetJourney_Successful()
        {
            //expected result of the tested method 
            Journey expected = journey;
            //result of the tested method is stored in 'actual' variable
            Journey actual = testedClass.GetJourney(journey.DeliveryAddress, journey.Date);

            var failMessage = String.Format("Method should return {0} but returns {1}.", expected.DeliveryAddress, actual.DeliveryAddress);

            Assert.AreEqual(actual, expected, failMessage);

        }

        /// <summary>
        /// Method to test GetJourney()
        /// </summary>
        /// <remarks>should throw exception as journey not found</remarks>
        [TestMethod]
        public void GetJourney_JourneyNotFound()
        {
            //try catch as exception will be thrown
            try
            {
                //call method with parameters which do not match a journey in the list
                testedClass.GetJourney("Doesnt Exist", DateTime.Today);
                Assert.Fail("Should throw not found exception");
            }
            //catch expected exception
            catch (JourneyNotFoundException)
            {

            }

        }

        /// <summary>
        /// Method to test AddJourney()
        /// </summary>
        /// <remarks>new journey should be successfully added to the list</remarks>
        [TestMethod]
        public void AddJourney_Successful()
        {
            //create new journey object to add to the list 
            Journey newJourney = new Journey(driver, DateTime.Today, "Test", "Test", 1);
            //expected number of object within list after the method is called
            int expected = testedClass.journeys.Count + 1;
            int actual;

            testedClass.AddJourney(newJourney);

            //store number of objects in journey list within 'actual' variable 
            actual = testedClass.journeys.Count;

            var failMessage = String.Format("List should contain {0} journeys but actually contains {1}.", expected, actual);

            Assert.AreEqual(expected, actual, failMessage);
        }

        /// <summary>
        /// Method to test AddJourney()
        /// </summary>
        /// <remarks>journey to be added is a duplicate so exception should be thrown</remarks>
        [TestMethod]
        public void AddJourney_IsADuplicate()
        {
            //try catch block as exception will be thrown
            try
            {
                //try add duplicat journey to list
                testedClass.AddJourney(journey);
                Assert.Fail("Should throw duplicate journey exception");
            }
            //catch expected exception
            catch (DuplicateJourneyException)
            {

            }
        }

        /// <summary>
        /// Method to test RemoveJourney()
        /// </summary>
        /// <remarks>Journey should be successfully removed using delivery and date as parameters</remarks>
        [TestMethod]
        public void RemoveJourney_ByDeliveryAndDate_Successful()
        {
            //method should return true variable indicating journey has been removed
            bool expected = true;
            bool actual;

            //store bool returned by method within 'actual' variable
            actual = testedClass.RemoveJourney(journey.DeliveryAddress, journey.Date);

            var failMessage = String.Format("Method should return {0} but actually returns {1}.", expected, actual);

            Assert.IsTrue(actual, failMessage);
        }

        /// <summary>
        /// Method to test RemoveJourney()
        /// </summary>
        /// <remarks>Journey should not be removed as doesnt exist within the list. Exception should be thrown</remarks>
        [TestMethod]
        public void RemoveJourney_ByDeliveryAndDate_DoesNotExist()
        {
            //try catch block as exception will be thrown
            try
            {
                //try remove journey which does not exist
                testedClass.RemoveJourney("Doesnt exist", DateTime.Today);
                Assert.Fail("Should throw journey not found exception");
            }
            //catch expected exception
            catch (JourneyNotFoundException)
            {

            }
        }

        /// <summary>
        /// Method to test RemoveJourney()
        /// </summary>
        /// <remarks>Journey should be successfully removed</remarks>
        [TestMethod]
        public void RemoveJourney_Successful()
        {
            //method should return true variable indicating journey has been removed
            bool expected = true;
            bool actual;

            //bool returned by method is stored in 'actual' variable
            actual = testedClass.RemoveJourney(journey2);

            var failMessage = String.Format("Method should return {0} but actually returns {1}.", expected, actual);

            Assert.IsTrue(actual, failMessage);
        }

        /// <summary>
        /// Method to test RemoveJourney()
        /// </summary>
        /// <remarks>Journey does not exist within list so shouldnt be removed</remarks>
        [TestMethod]
        public void RemoveJourney_Unsuccessful()
        {
            //method should return false variable indicating journey has been removed
            bool expected = false;
            bool actual;

            //create new journey to pass as parameter for tested method
            //journey is not added to the list so that the method should return false 
            Journey newJourney = new Journey(driver, DateTime.Today, "XXXXX", "XXXXX", 10);

            //bool returned by method is stored in 'actual' variable
            actual = testedClass.RemoveJourney(newJourney);

            var failMessage = String.Format("Method should return {0} but actually returns {1}.", expected, actual);

            Assert.IsFalse(actual, failMessage);
        }

        /// <summary>
        /// Method to test RemoveAllJourneys()
        /// </summary>
        /// <remarks>should successfully remove all journeys</remarks>
        [TestMethod]
        public void RemoveAllJourneys_Successful()
        {
            //expected number of objects within list after method is called
            int expected = 0;
            int actual;

            testedClass.RemoveAllJourneys();

            //number of objects in list after method is called is stored within 'actual' variable
            actual = testedClass.journeys.Count;

            var failMessage = String.Format("List should contain {0} journeys but actually contains {1}.", expected, actual);

            Assert.AreEqual(expected, actual, failMessage);
        }
    }
}
