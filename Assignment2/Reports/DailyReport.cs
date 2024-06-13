using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to hold methods to process daily reports 
    /// </summary>
    public class DailyReport
    {
        private readonly IJourneyList journeyList;

        /// <summary>
        /// Constructor for daily report 
        /// </summary>
        /// <param name="journeyList">journeyList generate daily report for</param>
        public DailyReport(IJourneyList journeyList)
        {
            this.journeyList = journeyList;

        }

        /// <summary>
        /// Method to calculate daily distance
        /// </summary>
        /// <param name="date">date to calculate distance for</param>
        /// <returns>total distance covered in km as a double</returns>
        public double CalcDailyDistance(DateTime date)
        {
            //Linq query to retreive all journeys on a specific date 
            var dailyDistance =
                from journey in journeyList.journeys
                where date == journey.Date
                select journey.Distance;

            //variable to store the total daily distance 
            double totalDistance = 0;

            //add each journey's distance to the totalDistance varaible 
            foreach(var distance in dailyDistance)
            {
                totalDistance += distance;
            }

            return totalDistance;
        }

        /// <summary>
        /// Method to retreive all dates in which a journey was made on 
        /// </summary>
        /// <returns>list of dates whcih journeys have been made on</returns>
        public IEnumerable<IGrouping<DateTime, Journey>> GetDates()
        {
            //Linq SQL query to group journeys by date 
            //ordered by date 
            IEnumerable<IGrouping<DateTime, Journey>> journeyQuery =
                        (from journey in journeyList.journeys
                         orderby journey.Date descending
                         group journey by journey.Date);
            
            return journeyQuery;
        }
    }
}
