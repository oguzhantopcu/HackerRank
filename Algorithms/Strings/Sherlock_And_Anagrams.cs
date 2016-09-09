using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Strings
{
	class Program
	{
		static void Main(string[] args)
		{
			var count = Convert.ToInt32(Console.ReadLine())      ;
                
            for(var i = 0; i < count; i++)
			{
            	var res = FindUnorderedAnagrammaticPairCount(Console.ReadLine());

				Console.WriteLine(res);    
            }
		}

		public static IEnumerable<string> FindAllSubstrings(string text, int strLength)
		{
			for (int i = 0; i <= text.Length - strLength; i++)
			{
				yield return text.Substring(i, strLength);
			}
		}

		public static IEnumerable<string> SortStrings(IEnumerable<string> strings)
		{
			return strings.Select(c => new string(c.OrderByDescending(q => q).ToArray()));
		}

		public static int FindUnorderedAnagrammaticPairCount(string text)
		{
			var result = 0;

			for (int i = 1; i < text.Length; i++)
			{
				var substrs = FindAllSubstrings(text, i);
				var sortedSubstrs = SortStrings(substrs);

				result += sortedSubstrs.GroupBy(c => c)
					.Where(l => l.Count() > 1)
					.Sum(c => CombinationCount(c.Count(), 2));
			}

			return result;
		}

		public static BigInteger Factorial(BigInteger number)
		{
			BigInteger result = 1;

			for (int i = 0; i < number; i++)
			{
				result *= i + 1;
			}

			return result;
		}

		public static int CombinationCount(int number, int peer)
		{
			return (int)(Factorial(number) / (Factorial(peer) * Factorial(number - peer)));
		}
	}
}