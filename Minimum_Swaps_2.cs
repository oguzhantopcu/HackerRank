using System.IO;
using System;

class Solution {

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr, int swap = 0)
    {
        while (true)
        {
            var index1 = 0;
            var index2 = 0;

            for (var i = 0; i < arr.Length; i++)
            {
                var item = arr[i];
                var heir = i + 1;

                if (item != heir)
                {
                    index1 = i;
                    index2 = item - 1;

                    break;
                }
            }

            if (index1 + index2 <= 0) return swap;

            swap++;

            var temp = arr[index2];
            arr[index2] = arr[index1];
            arr[index1] = temp;
        }
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
