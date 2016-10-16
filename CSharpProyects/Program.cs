using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HermaFx.Functional;
using System.Threading;

namespace CSharpProyects
{
	class Program
	{
		static void Main(string[] args)
		{
			//FizzBuzz.GenerateFizzFuzz();
			//ParallelVsSerial.Test();
			//BlockingThreads.Test();
			//CalculatePrime.Test();
			Console.ReadLine();
		}

		
	}

	public static class Extensions
	{
		public static void PrintMeasureFor(Action action)
		{
			var measure = System.Diagnostics.Stopwatch.StartNew();
			action.Invoke();
			measure.Stop();
			Console.WriteLine("***********************");
			Console.WriteLine("Measure is: {0}", measure.Elapsed.TotalMilliseconds);
			Console.WriteLine("***********************");
		}

		public static void PrintMeasureFor(Action<int> action)
		{
			var measure = System.Diagnostics.Stopwatch.StartNew();
			action.Invoke(1);
			measure.Stop();

			Console.WriteLine("***********************");
			Console.WriteLine("Measure is: {0}", measure.Elapsed.TotalMilliseconds);
			Console.WriteLine("***********************");
		}
	}
}
