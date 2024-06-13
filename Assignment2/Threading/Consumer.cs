using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    class Consumer
	{
		// number of consumer threads which are running 
		private static int runningThreads = 0;
		private static object locker = new object();
		private const int duration = 1000; // Simulate time taken to consume a work item 


		// Id for consumer
		private string id;
		//Thread upon which this instance of a consumer runs 
		public Thread T { get; private set; }
		// bool to signal whether consumer has finished
		private bool finished;

		//PCQueue that this consumer is taking work from
		private PCQueue pcQueue;

		// list of drivers 
		private DriverList driverList;

		// list of journeys 
		private JourneyList journeyList;

		private ProgressManager progManager;

		public static int RunningThreads
		{
			get
			{
				return runningThreads;
			}

			private set
			{
				lock (locker)
				{
					runningThreads = value;
				}
			}
		}

		public bool Finished
		{
			get
			{
				return finished;
			}

			set
			{
				lock (this)
				{
					finished = value;
				}
			}
		}

		/// <summary>
		/// Constructor for consumer 
		/// </summary>
		/// <param name="id">id for consumer</param>
		/// <param name="pcQueue">queue which work is to be taken from</param>
		/// <param name="driverList">driver list to add driver data to</param>
		/// <param name="journeyList">journey list to add journey data to</param>
		/// <param name="progManager">progress manager for work</param>
		public Consumer(string id, PCQueue pcQueue, DriverList driverList, JourneyList journeyList, ProgressManager progManager)
		{
			this.id = id;
			finished = false;
			this.pcQueue = pcQueue;
			this.driverList = driverList;
			this.journeyList = journeyList;
			this.progManager = progManager;
			(T = new Thread(run)).Start(); // Create a new thread
			RunningThreads++; // keep track of running thread 
		}

		/// <summary>
		/// Thread code for Consumer
		/// </summary>
		/// <remarks>Method dequeues and consumes work item from pcQueue</remarks>
		public void run()
		{
			// While not finished, dequeue a work item from the PCQueue and consume this work item by calling
			// ReadDriverData() and ReadJourneyData() 
			while (!Finished)
			{
				// Dequeue a work item
				var item = pcQueue.dequeueItem();

				//check work item is not null
				if (!ReferenceEquals(null, item))
				{
					// Invoke the work item's ReadDriverData() and ReadJourneyData() methods
					Driver driver = item.ReadDriverData();
					JourneyList newJourneys = item.ReadJourneyData();

					// Ensure null returns are ignored (will happen if data not in correct format or can't open file)
					if (!ReferenceEquals(null, driver) && !ReferenceEquals(null, newJourneys))
					{
						// Add this driver to the driver list locking while being modified
						lock (driverList)
						{
							driverList.drivers.Add(driver);
						}

						//add journeys to the journey list, locking while being modified
						lock (journeyList)
						{
							foreach (Journey journey in newJourneys.journeys)
							{
								journeyList.journeys.Add(journey);
							}
						}

						//output to console
						Console.WriteLine("Consumer:{0} has consumed Work Item:{1}", id, item.configRecord.ToString());

					}

					else
					{
						// Output fail reject message to the console
						Console.WriteLine("Consumer:{0} has rejected Work Item:{1}", id, item.configRecord.ToString());
					}


					//simulate consumer activity
					Thread.Sleep(duration);

					//update number of items remaining 
					lock (locker)
					{
						progManager.ItemsRemaining--;
					}
				}
			}

			// Decrement the number of running consumer threads
			lock (locker)
			{
				RunningThreads--;
			}

			// Output that this consumer has finished
			Console.WriteLine("Consumer:{0} has finished", id);
		}
	}
}
