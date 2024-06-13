using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Assignment2
{
    /// <summary>
    /// Class for the forms based user interface 
    /// </summary>
    public partial class FormsBasedUI : Form, IUserInterface
    {
        public IDriverFileReader IOhandler { get; }
        private ConfigData configData;
        private DriverList driverList;
        private JourneyList journeyList;
        private DailyReport dailyReport;
        private DriverReport driverReport;

        public FormsBasedUI(IDriverFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        public void SetUpConfigData()
        {
            //new empty object for configData 
            configData = new ConfigData();

            //generating config data for each XML file using the filename
            configData.configRecords.Add(new ConfigRecord("Driver-01.xml"));
            configData.configRecords.Add(new ConfigRecord("Driver-02.xml"));
            configData.configRecords.Add(new ConfigRecord("Driver-03.xml"));
            configData.configRecords.Add(new ConfigRecord("Driver-04.xml"));
        }

        /// <summary>
        /// Method to run producers and consumers 
        /// </summary>
        public void RunProducerConsumer()
        {
            //create new empty driver list 
            driverList = new DriverList();

            //create new empty journey list
            journeyList = new JourneyList();

            //create progress manager to manage workload 
            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            // Output message that the producers and consumers started
            lblProgress.Text = "Creating and starting all producers and consumers";
            lblProgress.Refresh();

            // Create a PCQueue with capacity of 100 (reasonable size for the scale of SpeedyEats)
            var pcQueue = new PCQueue(100);

            // Create 2 Producer and 2 Consumer instances and begin executing threads 
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler),
                                     new Producer("P2", pcQueue, configData, IOhandler)};

            Consumer[] consumers = { new Consumer("C1", pcQueue, driverList, journeyList, progManager),
                                     new Consumer("C2", pcQueue, driverList, journeyList, progManager)};

            // loop to keep producing and consuming until all work items are completed according to progress manager 
            while (progManager.ItemsRemaining > 0) ;

            // Output message to indicate that the program is shutting down
            lblProgress.Text = "Shutting down all producers and consumers";
            lblProgress.Refresh();

            // Deactivate the PCQueue
            pcQueue.Active = false;

            // signal to producers to finish 
            foreach (var p in producers)
            {
                p.Finished = true;
            }

            // signal to consumers to finish 
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            // pulse all threads incase threads are stranded 
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    Monitor.Pulse(pcQueue);

                    // short sleep to ensure pulses are detected 
                    Thread.Sleep(100);
                }
            }

            //feedback to user to advise the system is waiting for threads to finish
            Console.WriteLine("Waiting for threads ... ");

            // loop to wait while threads are spinning 
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ;

            //output that all producers and consumers are shut down
            lblProgress.Text = "All producers and consumers shut down";
            lblProgress.Refresh();

        }

        /// <summary>
        /// Method to display all drivers 
        /// </summary>
        public void DisplayDrivers()
        {
            //new driver report created using the journey list
            driverReport = new DriverReport(journeyList);

            //sort list of drivers alphabetically 
            driverList.SortList();

            //allow for user to only select one driver at a time 
            lstDrivers.SelectionMode = SelectionMode.One;

            // Clear items in listbox
            lstDrivers.Items.Clear();
            lstTotalDistance.Items.Clear();

            // display all drivers in driver list 
            foreach (Driver driver in driverList.drivers)
            {
                // calculate each drivers total distance from their journeys and store in variable 
                double totalDistance = driverReport.CalcTotalDistance(driver);
                // add driver name to list box 
                lstDrivers.Items.Add(driver.Name);
                // add drivers total distance to list box 
                lstTotalDistance.Items.Add(String.Format("{0}km", totalDistance));
            }

        }


        /// <summary>
        /// Method to display details of the longest journey 
        /// </summary>
        public void DisplayLongestJourney()
        {
            //retrieve longest journey 
            Journey longestJourney = journeyList.GetLongestDistance();

            //output details of longest journey onto the form
            txtLongestJourney.Text = String.Format("Driver: {0} Date: {1} Distance: {2}km", longestJourney.Driver.Name, longestJourney.Date.ToString("d"), longestJourney.Distance);

        }

        /// <summary>
        /// Method to display all dates which journeys have been made on 
        /// </summary>
        public void DisplayDatesAndDistance()
        {
            ViewDates viewDatesForm = new ViewDates(journeyList);

            viewDatesForm.ShowDialog();

        }


        /// <summary>
        /// Method to display all journeys made by a driver 
        /// </summary>
        /// <param name="driver">driver to retrieve journeys for</param>
        public void DisplayDriverJourneys(Driver driver)
        {
            //clear all items in list box
            lstJourneys.Items.Clear();

            //add each journey returned from GetDriverJourneys() method 
            foreach (Journey journey in journeyList.GetDriverJourneys(driver))
            {
                lstJourneys.Items.Add(journey);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // Clear any items in listboxes
            ClearAll();


            SetUpConfigData();

            // Update form object properties to provide feedback to the user 
            lblProgress.Text = "Config data loaded. Waiting for user to press load";
            //set next required button to enabled to user can progress 
            btnProducerConsumer.Enabled = true;
            btnDates.Enabled = false;
            btnDrivers.Enabled = false;
            lstDrivers.Enabled = false;
            lstJourneys.Enabled = false;
        }


        private void btnProducerConsumer_Click(object sender, EventArgs e)
        {
            // Clear items in listbox
            lstDrivers.Items.Clear();

            //output that data is being obtained
            lblProgress.Text = "Obtaining driver data. Please wait...";
            lblProgress.Refresh();

            // Run producer/consumer queue to load driver and journey data
            RunProducerConsumer();

            // Update form object properties to confirm data has been loaded successfully 
            lblProgress.Text = "Driver data loaded";
            btnDrivers.Enabled = true;
            btnDates.Enabled = true;
            lstDrivers.Enabled = true;
            lstTotalDistance.Enabled = true;
            lstJourneys.Enabled = true;
            btnProducerConsumer.Enabled = false;
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            ClearAll();
            DisplayLongestJourney();
            DisplayDrivers();

            lstJourneys.Items.Add("Please select driver to view their journeys.");
        }

        private void lstDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validation to ensure user has made a selection from the list box 
            if(lstDrivers.SelectedIndex <= driverList.drivers.Count && lstDrivers.SelectedIndex > -1)
            {
                DisplayDriverJourneys(driverList.drivers[lstDrivers.SelectedIndex]);
            }
            else
            {
                //user feedback if an invalid selection has been made 
                MessageBox.Show("Cannot show journeys for that selected item!");
            }

        }

        private void btnDates_Click(object sender, EventArgs e)
        {
            ClearAll();
            DisplayLongestJourney();
            DisplayDatesAndDistance();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Method to clear both list boxes on the form 
        /// </summary>
        private void ClearAll()
        {
            lstDrivers.Items.Clear();
            lstJourneys.Items.Clear();
            lstTotalDistance.Items.Clear();
            txtLongestJourney.Text = null;
        }
    }
}
