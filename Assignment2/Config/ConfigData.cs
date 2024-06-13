using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{   
    /// <summary>
    /// Class to store a list of config records 
    /// </summary>
    public class ConfigData
    {   
        /// <summary>
        /// List of config records
        /// </summary>
        public List<ConfigRecord> configRecords { get; set; }

        /// <summary>
        /// Integer to move onto next config record
        /// </summary>
        public int NextRecord { get; set; }

        /// <summary>
        /// Constructor for ConfigData class 
        /// </summary>
        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}
