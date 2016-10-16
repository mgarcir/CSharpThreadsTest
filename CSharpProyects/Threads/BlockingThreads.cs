using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpProyects
{
	public class BlockingThreads
	{
		private static int Total = 0;
		private static Object thisLock = new Object();

		public static void Test()
		{
			IEnumerable<int> myTasks = Enumerable.Range(1, 100);

			Extensions.PrintMeasureFor(
				() => Parallel.ForEach(myTasks, t => {
					CouldAccess(t);
				}));

			Extensions.PrintMeasureFor(
				() => myTasks.ToList().ForEach(t =>
					CouldAccess(t)
				));

			Console.WriteLine("The value for Total is: {0}.", Total);
		}

		private static void CouldAccess(int id)
		{
			Random time = new Random();
			bool lockWasTaken = false;

			Console.WriteLine("[{0}] Enter...", id);

			Thread.Sleep(time.Next(1, 1000));

			do
			{
				try
				{
					Monitor.TryEnter(thisLock, ref lockWasTaken);
					if (lockWasTaken)
					{
						Console.WriteLine("[{0}] The resource is free.", id);
						Console.WriteLine("[{0}] The process is working...", id);
						Thread.Sleep(time.Next(1, 1000));
						Total++;
						Console.WriteLine("[{0}] The total is now {1}", id, Total);
					}
				}
				finally
				{
					if (lockWasTaken)
					{
						Monitor.Exit(thisLock);
						Console.WriteLine("[{0}] The resource has been released.", id);
					}
					else
					{
						Console.WriteLine("[{0}] The resource is on use...", id);
						Thread.Sleep(time.Next(1, 1000));
					}
				}
			} while (!lockWasTaken);
		}
	}
}
