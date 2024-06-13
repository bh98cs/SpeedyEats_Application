using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Interface for classes which will store and manage lists of Journeys
    /// </summary>
    public interface IJourneyList
    {
        List<Journey> journeys { get; set; }
        IEnumerable<Journey> GetDriverJourneys(Driver driver);
    }
}
