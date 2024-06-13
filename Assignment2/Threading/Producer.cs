using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment2
{
    class Producer
    {
		// Count of producer threads that are running
		private static int runningThreads = 0; 
		private static object locker = new object();
		private const int duration = 1000; // Simulate time taken to produce a work item 


		// Id for producer
		private string id;
		// Thread upon which this instance of a producer runs
		public Thread T { get; private set; }

		// bool to signal if producer has finished 
		private bool finished;
		// PCQueue that this producer is producing work items for
		private PCQueue pcQueue;

		// Configuration data 
		private ConfigData configFile;
		// File handler for reading data
		private IDriverFileReader IOhandler;

		public static int RunningThreads // Property getter/setter methods
		{
			get
			{
				return runningThreads;
			}

			private set
			{
				lock (locker)
				{
					// MUTEX control for potential multiple thread access to this property
					runningThreads = value;
				}
			}
		}

		public bool Finished // Property getter/setter methods
		{
			get
			{
				return finished;
			}

			set
			{
				lock (this)
				{
					// MUTEX control for potential multiple thread access to this property
					finished = value;
				}
			}
		}

		/// <summary>
		/// Constructor for producer 
		/// </summary>
		/// <param name="id">id of producer</param>
		/// <param name="pcQueue">PCQueue in which work is produced for</param>
		/// <param name="configFile">config data</param>
		/// <param name="IOhandler">File handler for reading data</param>
		public Producer(string id, PCQueue pcQueue, ConfigData configFile, IDriverFileReader IOhandler)
		{
			this.id = id;
			finished = false; // Initially not finished
			this.pcQueue = pcQueue;
			this.configFile = configFile;
			this.IOhandler = IOhandler;
			(T = new Thread(run)).Start(); // Create a new thread for this producer and get it started
			RunningThreads++; // Increment the number of running producer threads;
		}

		/// <summary>
		/// Thread code for Producer
		/// </summary>
		/// <remarks>Method enqueues work item to pcQueue</remarks>
		public void run()
		{
			ConfigRecord configRecord = null;

			// While not finished, generate a new work item and enqueue it on the PCQueue, output that this producer has
			// produced a new item (and what it is called)
			while (!Finished)
			{
				// Lock configuration file and obtain next filename to process
				// If there are no filenames left then set filename to null so that nothing is produced
				lock (configFile)
				{
					if (configFile.NextRecord < configFile.configRecords.Count)
					{
						configRecord = configFile.configRecords[configFile.NextRecord++];
					}
					else
					{
						configRecord = null;
					}
				}

				// only queue item if there is a config record to read
				if (configRecord != null)
				{
					// Enqueue a new work item
					pcQueue.enqueueItem(new Work(configRecord, IOhandler));

					// Output to console that this producer produced a work item
					Console.WriteLine("Producer:{0} has created and enqueued Work Item:{1}", id, configRecord.ToString());

				}

				// Simulate producer activity running for duration milliseconds
				Thread.Sleep(duration);
			}

			lock (locker)
			{
				// Decrement the number of running producer threads
				RunningThreads--;
			}


			// Output producer has finished
			Console.WriteLine("Producer:{0} has finished", id);
		}

	}
}
