using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpProyects
{
	public static class CalculatePrime
	{
		public static void Test()
		{
			IEnumerable<int> numbersList = Enumerable.Range(1, 1000);
			ConcurrentBag<int> resultCollection = new ConcurrentBag<int>();

			Console.WriteLine("Calculating primes for {0} numbers in serial.", numbersList.Count());
			Extensions.PrintMeasureFor(() =>
				numbersList.Select(x => IsPrime(x)).ToList()
			);

			Console.WriteLine("Calculating primes for {0} numbers in paralell.", numbersList.Count());
			Extensions.PrintMeasureFor(() =>
				Parallel.ForEach(numbersList, number =>
					resultCollection.Add(IsPrime(number))
			));

			Console.WriteLine("Calculating primes for {0} numbers in serial with a resource access.", numbersList.Count());
			Extensions.PrintMeasureFor(() =>
				numbersList.Select(x => IsPrimeWithResourceAccess(x)).ToList()
			);

			Console.WriteLine("Calculating primes for {0} numbers in paralell with a resource access.", numbersList.Count());
			Extensions.PrintMeasureFor(() =>
				Parallel.ForEach(numbersList, number =>
					resultCollection.Add(IsPrimeWithResourceAccess(number))
			));
		}

		private static int IsPrime(int number)
		{
			var boundary = (int)Math.Floor(Math.Sqrt(number));

			for (int i = 2; i <= boundary; ++i)
			{
				if (number % i == 0) return 0;
			}

			return number;
		}

		private static int IsPrimeWithResourceAccess(int number)
		{
			var random = new Random();
			Thread.Sleep(random.Next(1, 100));

			return IsPrime(number);
		}
	}
}
