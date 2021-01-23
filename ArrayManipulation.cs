using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

class Solution {
    
    static long arrayManipulation(int n, int[][] queries)
    {
        var bigQuery = new int[n + 2];

        foreach (var q in queries)
        {
            bigQuery[q[0]] += q[2];
            bigQuery[q[1] + 1] -= q[2];
        }

        long max = 0, current = 0;

        foreach (var q in bigQuery)
            if (max < (current += q))
                max = current;

        return max;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++) {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
