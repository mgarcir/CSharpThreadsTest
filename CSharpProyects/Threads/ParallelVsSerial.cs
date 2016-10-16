using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpProyects
{
	public static class ParallelVsSerial
	{
		public static void Test()
		{
			var tasks = Enumerable.Range(1, 100);
			new ParallelOptions { MaxDegreeOfParallelism = 100};

			PrintMeasureFor(() => tasks.ToList().ForEach(x => EmptyTask(x)));
			PrintMeasureFor(() => Parallel.ForEach(tasks, t => EmptyTask(t)));
		}

		private static void EmptyTask(int id)
		{
			var random = new Random();

			Thread.Sleep(random.Next(1, 1000));

			//Console.WriteLine("[{0}] Empty task finish!.", id);
		}

		private static void PrintMeasureFor(Action action)
		{
			var measure = System.Diagnostics.Stopwatch.StartNew();
			action.Invoke();
			measure.Stop();
			Console.WriteLine("Measure is: {0}", measure.Elapsed.TotalMilliseconds);
		}
	}
}
