using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to hold methods to process driver reports 
    /// </summary>
    public class DriverReport
    {

        private readonly IJourneyList journeyList;

        /// <summary>
        /// constructor for driver report 
        /// </summary>
        /// <param name="journeyList">journey list to process driver reports for</param>
        public DriverReport(IJourneyList journeyList)
        {
            this.journeyList = journeyList;
        }

        /// <summary>
        /// Method to calculate the total distance for a driver 
        /// </summary>
        /// <param name="driver">driver to calculate total distance for</param>
        /// <returns>total distance covered by driver in km as a double</returns>
        public double CalcTotalDistance(Driver driver)
        {
            //variable to hold total distance of driver 
            double totalDistance = 0;

            //validation to check driver has at least one journey 
            //returns 0 if no journeys have been made by the driver 
            if(journeyList.GetDriverJourneys(driver) != null)
            {
                //add distance of each journey made by the driver to the totalDistance variable
                foreach (Journey j in journeyList.GetDriverJourneys(driver))
                {

                    totalDistance += j.Distance;
                }
            }

            return totalDistance;
        }
    }
}
