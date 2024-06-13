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
    class JourneyListWasUnsuccessful : IJourneyList
    {
        public List<Journey> journeys { get; set; }

        public JourneyListWasUnsuccessful()
        {
            journeys = new List<Journey>();
        }

        /// <summary>
        /// Dummy method to return null list of journeys for test purposes
        /// </summary>
        /// <param name="driver">driver to return journeys for (is ignored in this dummy method)</param>
        /// <returns>null list of journeys</returns>
        public IEnumerable<Journey> GetDriverJourneys(Driver driver)
        {
            return null;

        }
    }
}
