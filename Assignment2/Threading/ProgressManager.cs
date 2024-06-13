using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class ProgressManager
    {
        //number of items remaining in work queue
        private int itemsRemaining;
        public int ItemsRemaining 
        {
            get
            {
                return itemsRemaining;
            }

            set
            {
                lock (this)
                {
                    // MUTEX control for potential multiple thread access to this property
                    itemsRemaining = value;
                }
            }
        }

        /// <summary>
        /// Constructor with no parameters
        /// </summary>
        public ProgressManager()
        {
            //items remaining in queue is set to 0 
            this.ItemsRemaining = 0;
        }

        /// <summary>
        /// Constructor for progress manger which takes a value of items in the queue
        /// </summary>
        /// <param name="items">number of items in the queue</param>
        public ProgressManager(int items)
        {
            this.ItemsRemaining = items;
        }

    }
}
