using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Work
    {
        // Data used when this work is processed - config record
        public ConfigRecord configRecord { get; private set; }
        // file handler for reading data 
        private IDriverFileReader IOhandler; 

        /// <summary>
        /// constructor for work 
        /// </summary>
        /// <param name="data">config data</param>
        /// <param name="IOhandler">file handler for reading data</param>
        public Work(ConfigRecord data, IDriverFileReader IOhandler) //extra param for IcyclistIO
        {
            this.configRecord = data; // Data is initialised when the work is instantiated
            this.IOhandler = IOhandler;
        }

        /// <summary>
        /// Method to read driver data
        /// </summary>
        /// <returns>Driver object read from data file</returns>
        public Driver ReadDriverData()
        {
            // Reads the specified file and extracts the driver data from it to store in a driver object
            return IOhandler.ReadDriverDataFromFile(configRecord);
        }

        /// <summary>
        /// Method to read journey data
        /// </summary>
        /// <returns>list of journeys read from data file</returns>
        public JourneyList ReadJourneyData()
        {
            // reads file and extracts journey data which is stored in a journey object. Each journey 
            // object is then added to the journey list
            return IOhandler.ReadJourneyDataFromFile(configRecord);
        }

    }
}
