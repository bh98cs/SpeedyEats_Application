using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    ///  Class to store details of data file 
    /// </summary>
    public class ConfigRecord
    {
        /// <summary>
        /// String to store name of data file
        /// </summary>
        public String Filename { get; private set; }

        /// <summary>
        /// Constructor for class ConfigRecord
        /// </summary>
        /// <param name="Filename">name of data file</param>
        public ConfigRecord(String Filename)
        {
            this.Filename = Filename;
        }

        /// <summary>
        /// Overridden ToString method
        /// </summary>
        /// <returns>Name of data file</returns>
        public override String ToString()
        {
            return String.Format("{0}", Filename);
        }
    }
}
