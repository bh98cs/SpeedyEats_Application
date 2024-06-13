using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Interface for classes which will be used to read in data for drivers and journeys 
    /// </summary>
    public interface IDriverFileReader
    {
        Driver ReadDriverDataFromFile(ConfigRecord configRecord);
        JourneyList ReadJourneyDataFromFile(ConfigRecord configRecord);
    }
}
