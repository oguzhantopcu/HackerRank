using System.IO;
using System.Linq;
using System;

class Solution
{
    static int activityNotifications(int[] expenditure, int d)
    {
        var maxExpenditure = expenditure.Max();
        var lookBackDays = expenditure.Take(d).ToArray();
        var countMapSort = new int[maxExpenditure + 1];

        foreach (var exp in lookBackDays) countMapSort[exp]++;

        var notificationCount = 0;

        for (int i = d; i < expenditure.Length; i++)
        {
            var exp = expenditure[i];
            var median = CountMedian(countMapSort, d);

            if (exp >= 2 * median) notificationCount++;

            var lost = expenditure[i - lookBackDays.Length];

            countMapSort[lost]--;
            countMapSort[exp]++;
        }

        return notificationCount;
    }

    private static decimal CountMedian(int[] countMap, int lookBackLength)
    {
        var lookBackHalfLength = (lookBackLength + 1) / 2;
        var even = lookBackLength % 2 == 0;
        var sortedArrayIndex = 0;
        var median = 0m;

        for (int i = 0; i < countMap.Length; i++)
        {
            if (sortedArrayIndex + countMap[i] > lookBackHalfLength)
            {
                for (int j = 0; j < countMap[i]; j++)
                {
                    sortedArrayIndex++;

                    if (TryGetMedian(sortedArrayIndex, lookBackHalfLength, ref median, i, even)) return median;
                }
            }
            else
            {
                sortedArrayIndex += countMap[i];

                if (TryGetMedian(sortedArrayIndex, lookBackHalfLength, ref median, i, even)) return median;
            }
        }

        return 0;
    }

    private static bool TryGetMedian(int sortedArrayIndex, int lookBackHalfLength, ref decimal median, int i, bool even)
    {
        if (sortedArrayIndex == lookBackHalfLength)
        {
            median = i;

            if (!even)
            {
                return true;
            }
        }
        else if (sortedArrayIndex == lookBackHalfLength + 1)
        {
            median = (median + i) / 2;

            return true;
        }

        return false;
    }


    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '),
                expenditureTemp => Convert.ToInt32(expenditureTemp))
            ;
        int result = activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
