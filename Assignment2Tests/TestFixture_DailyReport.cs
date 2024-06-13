using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment2;
using TestedClass = Assignment2.DailyReport;

namespace Assignment2Tests
{
    /// <summary>
    /// Test Fixture for DailyReport class
    /// </summary>
    [TestClass]
    public class TestFixture_DailyReport
    {
        //Tested class is DailyReport 
        private TestedClass testedClass;

        private JourneyList journeyList;

        //create 2 drivers for testing 
        static readonly Driver driver1 = new Driver("Driver 1");
        static readonly Driver driver2 = new Driver("Driver 2");

        //create 3 journeys for testing 
        readonly Journey journey1 = new Journey(driver1, DateTime.Today, "NE1 1AA", "SR5 1AB", 12);
        readonly Journey journey2 = new Journey(driver2, DateTime.Parse("12/12/2023"), "SR2 1RA", "SR5 1AB", 2);
        readonly Journey journey3 = new Journey(driver1, DateTime.Parse("12/12/2023"), "SR2 1RA", "SR5 1AB", 8);

        /// <summary>
        /// TestInitialize method to run before every test
        /// </summary>
        /// <remarks>Create new instances of journeyList and testedClass before each test</remarks>
        [TestInitialize]
        public void TestInitialize()
        {
            journeyList = new JourneyList();

            testedClass = new TestedClass(journeyList);
        }

        /// <summary>
        /// TestCleanup method to run after every test 
        /// </summary>
        /// <remarks> Set instances of testedClass and journeyList to null after each test</remarks>
        [TestCleanup]
        public void TestCleanup()
        {
            testedClass = null;
            journeyList = null;
        }

        /// <summary>
        /// Test for CalcDailyDistance
        /// </summary>
        /// <remarks>test should return the correct daily distance for the date specified</remarks>
        [TestMethod]
        public void CalcDailyDistance_Successful()
        {
            //add journeys to journeyList
            journeyList.journeys.Add(journey1);
            journeyList.journeys.Add(journey2);
            journeyList.journeys.Add(journey3);

            //call method to test correct distance is calculated
            DateTime date = DateTime.Parse("12/12/2023");
            double expected = journey2.Distance + journey3.Distance;
            double actual = testedClass.CalcDailyDistance(date);

            var failMessage = String.Format("Daily distance should be {0} but is {1}", expected, actual);

            Assert.AreEqual(actual, expected, failMessage);

        }

        /// <summary>
        /// Test for CalcDailyDistance
        /// </summary>
        /// <remarks>method should return 0 as is called on an empty list of journeys</remarks>
        [TestMethod]
        public void CalcDailyDistance_EmptyList()
        {
            //call method which should return 0 
            DateTime date = DateTime.Parse("12/12/2023");
            double expected = 0;
            double actual = testedClass.CalcDailyDistance(date);

            var failMessage = String.Format("Daily distance should be {0} but is {1}", expected, actual);

            Assert.AreEqual(actual, expected, failMessage);
        }

        [TestMethod]
        public void CalcDailyDistance_NoJourneysOnDate()
        {
            //add journeys to journeyList
            journeyList.journeys.Add(journey1);
            journeyList.journeys.Add(journey2);
            journeyList.journeys.Add(journey3);

            //call method to test 0 distance is calculated for specified date
            DateTime date = DateTime.Parse("13/12/2023");
            double expected = 0;
            double actual = testedClass.CalcDailyDistance(date);

            var failMessage = String.Format("Daily distance should be {0} but is {1}", expected, actual);

            Assert.AreEqual(actual, expected, failMessage);
        }
    }
}
