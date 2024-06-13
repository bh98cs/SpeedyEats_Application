using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment2;
using TestedClass = Assignment2.DriverReport;

namespace Assignment2Tests
{
    /// <summary>
    /// Test fixture for DriverReport
    /// </summary>
    [TestClass]
    public class TestFixture_DriverReport
    {
        //tested class is DriverReport
        private TestedClass testedClass;

        //journey list to pass as parameter for driver report 
        private IJourneyList journeyList;

        /// <summary>
        /// Test Initialize class to run before each test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            //blank initialize as tested class instance will be set up differently in each test
        }

        /// <summary>
        /// TestCleanup class to run after each test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            //set tested class and journeyList instance to null
            testedClass = null;
            journeyList = null;
        }

        /// <summary>
        /// Method to test CalcTotalDistance()
        /// </summary>
        /// <remarks>total driver distance should be calculated correctly</remarks>
        [TestMethod]
        public void CalcTotalDistance_Successful()
        {
            //create driver object to calculate total distance for
            Driver driver = new Driver("Driver");
            //new journeyList instance using stub class 
            journeyList = new JourneyListWasSuccessful();
            //new testedClass instance passing in journeyList stub 
            testedClass = new TestedClass(journeyList);

            //expected distance to be calculated
            double expected = 13;
            double actual;

            //store result of tested method within 'actual' variable
            actual = testedClass.CalcTotalDistance(driver);

            var failMessage = String.Format("Total distance should be {0} but instead returns {1}", expected, actual);

            Assert.AreEqual(expected, actual, failMessage);

        }

        /// <summary>
        /// Method to test CalcTotalDistance()
        /// </summary>
        /// <remarks>should return 0 as no journeys will be in the list</remarks>
        [TestMethod]
        public void CalcTotalDistance_NoJourneysInList()
        {
            //create driver object to calculate total distance for
            Driver driver = new Driver("Driver");
            //new journeyList instance using stub 
            journeyList = new JourneyListWasUnsuccessful();
            //new testedClass instance passing in journeyList stub
            testedClass = new TestedClass(journeyList);

            //expected distance to be calculated
            double expected = 0;
            double actual;

            //store result of tested method within 'actual' variable
            actual = testedClass.CalcTotalDistance(driver);

            var failMessage = String.Format("Total distance should be {0} but instead returns {1}", expected, actual);

            Assert.AreEqual(expected, actual, failMessage);
        }
    }
}
