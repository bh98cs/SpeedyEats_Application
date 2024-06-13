using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class ViewDates : Form
    {

        
        private DailyReport dailyReport;

        public ViewDates()
        {
            InitializeComponent();
        }

        public ViewDates(JourneyList journeyList)
        {
            InitializeComponent();
            dailyReport = new DailyReport(journeyList);
        }

        /// <summary>
        /// Method to dislay distance covered each day 
        /// </summary>
        public void DisplayDailyDistance()
        {

            //Calculate daily distance for each date which is in the list  
            foreach (IGrouping<DateTime, Journey> journeyGroup in dailyReport.GetDates())
            {
                DateTime date = journeyGroup.Key;
                lstDates.Items.Add(String.Format("{0} : {1}km", journeyGroup.Key.ToString("d"), dailyReport.CalcDailyDistance(date)));
            }
        }

        private void ViewDates_Load(object sender, EventArgs e)
        {
            DisplayDailyDistance();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


