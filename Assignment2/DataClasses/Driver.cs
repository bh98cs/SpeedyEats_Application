using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Class to store details of Drivers
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// name of driver
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="name">Name of driver</param>
        public Driver(String name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Overridden ToString method 
        /// </summary>
        /// <returns>Name of driver</returns>
        public override String ToString()
        {
            return String.Format("Name: {0}", Name);
        }
    }
}
