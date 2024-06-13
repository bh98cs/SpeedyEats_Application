using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to store details of journeys 
    /// </summary>
    public class Journey
    {
        /// <summary>
        /// variable to store the driver which has made the journey 
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Variable for the date of the journey 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// variable for the postcode the delivery was made to 
        /// </summary>
        public String DeliveryAddress { get; set; }

        /// <summary>
        /// variable for the postcode the driver collected from 
        /// </summary>
        public String CollectionAddress { get; set; }

        /// <summary>
        /// variable for the distance of the journey 
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Constructor for a journey object 
        /// </summary>
        /// <param name="driver">driver which made the journey</param>
        /// <param name="date">date of the journey</param>
        /// <param name="deliveryAddress">delivery postcode</param>
        /// <param name="collectionAddress">collection postcode</param>
        /// <param name="distance">distance of the journey</param>
        public Journey(Driver driver, DateTime date, String deliveryAddress, String collectionAddress, int distance)
        {
            this.Driver = driver;
            this.Date = date;
            this.DeliveryAddress = deliveryAddress;
            this.CollectionAddress = collectionAddress;
            this.Distance = distance;
        }

        /// <summary>
        /// Overridden ToString method 
        /// </summary>
        /// <returns>details of the journey within a string variable</returns>
        public override String ToString()
        {
            return String.Format("Collected From: {0,-15} Delivered To: {1,-15} Date: {2,-15} Distance: {3, -15}", CollectionAddress, DeliveryAddress, Date.ToString("d"), Distance + "km");
        }

    }
}
