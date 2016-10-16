using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProyects
{
	public static class FizzBuzz
	{
		#region FizzFuzz
		public static void GenerateFizzFuzz()
		{
			Enumerable.Range(1, 3000).
				Select(num => GetValue(num)).
				ToList().
				ForEach(x => Console.Write("{0}, ", x));

			Console.ReadKey();
		}

		private static string GetValue(int value)
		{
			return new HermaFx.Functional.PatternMatcher<string>().
				Case<int>(x => x % 3 == 0 && x % 5 != 0, "Fizz").
				Case<int>(x => x % 3 != 0 && x % 5 == 0, "Fuzz").
				Case<int>(x => x % 3 == 0 && x % 5 == 0, "FizzFuzz").
				Default(x => x.ToString()).
				Match(value);
		}
		#endregion
	}
}
