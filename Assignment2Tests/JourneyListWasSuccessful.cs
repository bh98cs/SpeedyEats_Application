using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2;

namespace Assignment2Tests
{
    /// <summary>
    /// Stub class for JourneyList for testing purposes
    /// </summary>
    public class JourneyListWasSuccessful : IJourneyList
    {

        public List<Journey> journeys { get; set; }

        public JourneyListWasSuccessful()
        {
            journeys = new List<Journey>();
        }

        /// <summary>
        /// Dummy method to return list of journeys for test purposes
        /// </summary>
        /// <param name="driver">driver to retrieve journeys for (is ignored in this dummy method)</param>
        /// <returns>list of journeys</returns>
        public IEnumerable<Journey> GetDriverJourneys(Driver driver)
        {
            //create new list of journeys and add 2 journeys for test purposes
            JourneyListWasSuccessful journeys = new JourneyListWasSuccessful();
            Journey journey1 = new Journey(driver, DateTime.Today, "delivery", "collection", 12);
            Journey journey2 = new Journey(driver, DateTime.Today, "delivery", "collection", 1);

            journeys.journeys.Add(journey1);
            journeys.journeys.Add(journey2);

            var journeyList =
                from journey in journeys.journeys
                select journey;

            return journeyList;

        }
    }
}
