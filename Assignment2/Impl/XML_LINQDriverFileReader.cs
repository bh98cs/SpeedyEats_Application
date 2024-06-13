using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment2
{
    /// <summary>
    /// Class to read date from XML files using Xml.Linq
    /// </summary>
    /// <remarks>Implements IDriverFileReader interface</remarks>
    class XML_LINQDriverFileReader : IDriverFileReader
    {
        /// <summary>
        /// Method to retrieve driver data from Xml file 
        /// </summary>
        /// <param name="configRecord">name of the file to read from</param>
        /// <returns>Driver object to be added to driverList</returns>
        public Driver ReadDriverDataFromFile(ConfigRecord configRecord)
        {
            
            try
            {
                // Open file and load into memory as XML
                XDocument xmlDoc = XDocument.Load(configRecord.Filename);

                // Create driver (should only be one in file but retrieve first to be sure)
                var driverName = (from c in xmlDoc.Descendants("Driver") select c.Attribute("name").Value).First();

                Driver driver = new Driver(driverName);

                // Create and return a driver based on report name
                return driver;
            }
            catch
            {
                //return null if failed to read xml file
                return null;
            }

        }

        /// <summary>
        /// Method to read journey data from Xml file 
        /// </summary>
        /// <param name="configRecord">name of file to read from</param>
        /// <returns>List of journeys read from Xml file</returns>
        public JourneyList ReadJourneyDataFromFile(ConfigRecord configRecord)
        {
            //new journey list created to store journeys read from the Xml file 
            JourneyList journeyList = new JourneyList();

            try
            {
                // Open file and load into memory as XML
                XDocument xmlDoc = XDocument.Load(configRecord.Filename);


                //variable to keep track of how many journeys are in the Xml file
                var journeys = (from c in xmlDoc.Descendants("Journey") select c.Elements("Journey")).ToList();

                //store details of each journey in their own lists 
                var journeyDate = (from c in xmlDoc.Descendants("Journey") select c.Attribute("date").Value).ToList();

                var journeyCollection = (from c in xmlDoc.Descendants("Journey") select c.Element("Collection").Value).ToList();

                var journeyDelivery = (from c in xmlDoc.Descendants("Journey") select c.Element("Delivery").Value).ToList();

                var journeyDistance = (from c in xmlDoc.Descendants("Journey") select c.Element("Distance").Value).ToList();

                //driver object retrieved from the same xml file 
                var driver = ReadDriverDataFromFile(configRecord);

                //lock to ensure only one thread can access the journeyList at one time 
                lock (journeyList)
                {
                    //create a Journey object for each journey read from the Xml file 
                    //adding each object to the journeyList
                    for (int i = 0; i < journeys.Count; i++)
                    {
                        Journey journey = new Journey(driver, DateTime.Parse(journeyDate[i]), journeyDelivery[i], journeyCollection[i], Convert.ToInt32(journeyDistance[i]));
                        journeyList.journeys.Add(journey);
                    }
                }
                return journeyList;
            }
            catch
            {
                //return null if failed to read the Xml file 
                return null;
            }

        }
    }
}
