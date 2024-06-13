using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to store and process a list of journeys
    /// </summary>
    /// <remarks>implements the IJourneyList interface</remarks>
    public class JourneyList : IJourneyList
    {
        /// <summary>
        /// variable for list of journeys 
        /// </summary>
        public List<Journey> journeys { get; set; }

        /// <summary>
        /// constructor for JourneyList object
        /// </summary>
        public JourneyList()
        {
            journeys = new List<Journey>();
        }

        /// <summary>
        /// Method to retrieve all journeys made by a driver
        /// </summary>
        /// <param name="driver">driver which journeys are to be retrieved for</param>
        /// <returns>List of journeys made by the driver ordered by date </returns>
        public IEnumerable<Journey> GetDriverJourneys(Driver driver)
        {
            //LINQ query retrieving all journeys made by driver, ordered by date 
            var driverJourneys =
                from journey in journeys
                where journey.Driver.Name == driver.Name
                orderby journey.Date descending
                select journey;

            if(driverJourneys == null)
            {
                //thow exception if no journeys for selected driver
                NoJourneysForDriverException noJourneysForDriver = new NoJourneysForDriverException();
                throw noJourneysForDriver;
            }
            else
            {
                return driverJourneys;
            }
        }

        /// <summary>
        /// Method to check if list contains a particular journey
        /// </summary>
        /// <param name="delivery">delivery postcode of the journey</param>
        /// <param name="date">date of the journey</param>
        /// <returns>bool indicating whether the journey exists within the list</returns>
        public bool HasJourney(string delivery, DateTime date)
        {
            //validation to check parameter has been provided 
            if (String.IsNullOrEmpty(delivery))
            {
                //throw exception if no journey details provided
                NoJourneyDetailsProvidedException noJourneyDetailsProvidedException = new NoJourneyDetailsProvidedException();
                throw noJourneyDetailsProvidedException;
            }

            //check list for matching delivery address and date
            foreach (var journey in journeys)
            {
                if (delivery == journey.DeliveryAddress && date == journey.Date)
                {
                    //returns true if there is a matching journey
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to retrieve the journey with the longest recorded distance
        /// </summary>
        /// <returns>Journey which has the longest distance in the list</returns>
        public Journey GetLongestDistance() 
        {
            //LINQ query to order the list of journeys by distance (longest distance at the top of the list)
            //ordered by date second so most recent longest journey is top of the list
            var getLongestJourney =
                from journey in journeys
                orderby journey.Distance descending, journey.Date descending
                select journey;

            //retrieve the first object of the list as this is the most recent longest journey
            Journey longestJourney = getLongestJourney.FirstOrDefault();

            return longestJourney;
        }

        /// <summary>
        /// Method to retrieve a particular journey
        /// </summary>
        /// <param name="delivery">delivery postcode of the journey</param>
        /// <param name="date">date of the journey</param>
        /// <returns></returns>
        public Journey GetJourney(string delivery, DateTime date)
        {
            //LINQ query to select journey with matching delivery and date 
                var getJourney =
                        from myJourney in journeys
                        where myJourney.DeliveryAddress == delivery && myJourney.Date == date
                        select myJourney;

            if(getJourney.Count() > 0)
            {
                //should only be one journey however the FirstOrDefault function ensures only one journey is returned
                Journey journey = getJourney.FirstOrDefault();

                return journey;
            }
            else
            {
                //throw exception as journey not found 
                JourneyNotFoundException notFoundException = new JourneyNotFoundException();
                throw notFoundException;
            }

        }

        /// <summary>
        /// Method to add a journey to the list
        /// </summary>
        /// <param name="journey">journey which is to be added to the list</param>
        public void AddJourney(Journey journey)
        {
            //check the journey does not already exist by calling HasJourney method
            if (!HasJourney(journey.DeliveryAddress, journey.Date))
            {
                //add the journey if it does not already exist
                journeys.Add(journey);
            }
            else
            {
                //throw exception as journey already exists
                DuplicateJourneyException duplicate = new DuplicateJourneyException();
                throw duplicate;
            }
        }

        /// <summary>
        /// Method to remove a journey from the list 
        /// </summary>
        /// <remarks>This method removes the journey using the delivery postcode 
        /// and date of the journey</remarks>
        /// <param name="delivery">delivery postcode of the journey to be removed</param>
        /// <param name="date">date of the journey to be removed</param>
        /// <returns>bool indicating whether the journey was successfully removed</returns>
        public bool RemoveJourney(string delivery, DateTime date)
        {
            //check journey exists within the list 
            if (!HasJourney(delivery, date))
            {
                //throw exception as journey not found 
                JourneyNotFoundException notFoundException = new JourneyNotFoundException();
                throw notFoundException;
            }

            //retrieve the journey using the GetJourney method
            var journey = GetJourney(delivery, date);

            //remove the journey
            return RemoveJourney(journey);
        }

        /// <summary>
        /// Method to remove a journey from the list
        /// </summary>
        /// <param name="journey">journey to be removed</param>
        /// <returns>bool indicating whether the journey was successfully removed or not</returns>
        public bool RemoveJourney(Journey journey)
        {
            //call Remove() function which returns a bool indicating whether successful 
            return journeys.Remove(journey);
        }


        /// <summary>
        /// Method to remove all journeys from the list 
        /// </summary>
        public void RemoveAllJourneys()
        {
            //check the list does contain elements before clearing
            if(journeys.Count > 0)
            {
                journeys.Clear();
            }
            else
            {
                //throw exception 
            }
        }
    }
    /// <summary>
    /// Exception for a duplicate journey 
    /// </summary>
    public class DuplicateJourneyException : Exception
    {
        private static String msg = "This journey already exists!";

        public DuplicateJourneyException()
            : base(msg)
        {
        }

    }

    /// <summary>
    /// Exception for null journey details being provided
    /// </summary>
    public class NoJourneyDetailsProvidedException : Exception
    {
        private static String msg = "Journey details have not been provided!";

        public NoJourneyDetailsProvidedException() : base(msg)
        {
        }
    }

    /// <summary>
    /// Exception for journey not being found in list
    /// </summary>
    public class JourneyNotFoundException : Exception
    {
        private static String msg = "Journey not found";

        public JourneyNotFoundException() : base(msg)
        {
        }
    }

    /// <summary>
    /// Exception for driver with no journeys
    /// </summary>
    public class NoJourneysForDriverException : Exception
    {
        private static String msg = "No journeys recorded for this driver.";

        public NoJourneysForDriverException(): base(msg)
        {
        }
    }

}
