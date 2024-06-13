using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Interface for classes which will provide the User Interface 
    /// </summary>
    interface IUserInterface
    {
        void SetUpConfigData();
        void RunProducerConsumer();
        void DisplayDrivers();
        void DisplayDatesAndDistance();
        void DisplayLongestJourney();
        void DisplayDriverJourneys(Driver driver);

    }
}
