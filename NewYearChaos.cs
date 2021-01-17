using System;

class Solution {

    // Complete the minimumBribes function below.
    static void MinimumBribes(int[] bastards)
    {
        var moveCount = 0;
        
        for (int i = 0; i < bastards.Length; i++)
        {
            var index = bastards.Length - (i + 1);

            if (bastards[index] <= index) continue;

            var partialMoveCount = FixPlace(bastards, index);
            if (partialMoveCount > 2)
            {
                Console.WriteLine("Too chaotic");
                
                return;
            }

            moveCount += partialMoveCount;

            i -= partialMoveCount;
        }

        Console.WriteLine(moveCount);
    }

    static int FixPlace(int[] array, int index)
    {
        var indexPlus = index + 1;
        if (array[index] == indexPlus)
        {
            return 0;
        }
        
        Swap(array, index, index = indexPlus);

        return FixPlace(array, index) + 1;
    }
    
    static void Swap(int[] array, int index1, int index2)
    {
        var oneTemp = array[index1];
        
        array[index1] = array[index2];
        array[index2] = oneTemp;
    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
                ;
            MinimumBribes(q);
        }
    }
}
