using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System;
using System.Globalization;

class Solution {
    static long countTriplets(List<long> inputNumbers, long ratio) 
    {
        var recurrenceDictionary = new Dictionary<long, long>();
        var doubletDictionary = new Dictionary<long, long>();

        foreach (var number in inputNumbers)
        {
            if (!recurrenceDictionary.ContainsKey(number))
            {
                recurrenceDictionary.Add(number, 0);
                doubletDictionary.Add(number, 0);
            }
        }

        long result = 0;
        for (var inputIndex = inputNumbers.Count - 1; inputIndex != -1; inputIndex--)
        {
            var currentNumber = inputNumbers[inputIndex];
            
            var thirdElem = currentNumber * ratio;
            
            if (doubletDictionary.TryGetValue(thirdElem, out var doubletRecurrence))
            {
                result += doubletRecurrence;
            }
            
            if (recurrenceDictionary.TryGetValue(thirdElem, out var singleRecurrence))
            {
                doubletDictionary[currentNumber] += singleRecurrence;
            }
            
            recurrenceDictionary[currentNumber]++;
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.Write(ans.ToString(CultureInfo.InvariantCulture));

        textWriter.Flush();
        textWriter.Close();
    }
}
