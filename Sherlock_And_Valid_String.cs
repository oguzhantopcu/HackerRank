using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Algorithms.Strings
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputDictionary = Console.ReadLine().GroupBy(l => l).ToDictionary(l => l.Key, l => l.Count());

			Console.WriteLine(TryToMakeValid(inputDictionary) ? "YES" : "NO");
		}

		private static bool TryToMakeValid(Dictionary<char, int> charFreqs)
		{
			var attempts = 0;
			var averageFreq = charFreqs.GroupBy(l => l.Value)
				.OrderByDescending(p => p.Count())
				.ThenByDescending(l => l.Key)
				.First().Key; // find most used frequencies, if there are two character with same frequency, select higher one.

			foreach (var charFreq in charFreqs)
			{
				var freqDiff = Math.Abs(charFreq.Value - averageFreq);
				if (freqDiff > 1 && charFreq.Value != 1) // if the difference higher than 1, we can not make valid this string in one step
				{
					return false;
				}

				if (charFreq.Value == 1 && freqDiff != charFreq.Value) // if the frequency of a character is equal to 1, lets remove it to make string valid. make sure the average frequency is not equal to 1.
				{
					attempts++;
				}
				else if(freqDiff == 1) // if the difference is equal to 1, attempt to make string valid.
				{
					attempts++;
				}

				if (attempts > 1)
				{
					return false; // it seems we have tried two or more times to make this string valid, so return false.
				}
			}

			return true;
		}
	}
}