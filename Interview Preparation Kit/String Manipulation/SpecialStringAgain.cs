using System.Collections.Generic;
using System.IO;
using System;

class Solution
{
    static long SubstrCount(int n, string s)
    {
        long res = 0;
        for (var i = 0; i < n; i++)
        {
            var chars = new HashSet<char>();

            for (var j = 1; j < n - i + 1; j++)
            {
                var lastChar = s[i + j - 1];

                chars.Add(lastChar);

                if (j == 1)
                {
                    res++;
                    continue;
                }

                if (chars.Count > 2) // has 3 chars, no special
                {
                    break;
                }

                if (chars.Count == 1) // it could be a or aaa, special
                {
                    res++;
                    continue;
                }

                var midSpec = IsMiddleSpecial(s, i, j);
                if (midSpec.IsSpecial)
                {
                    res++;
                }

                if (!midSpec.CanBeSpecial)
                {
                    break;
                }
            }
        }

        return res;
    }

    static MiddleStat IsMiddleSpecial(string text, int pos, int len)
    {
        if (len % 2 == 0) // even number and aaba, no special
        {
            return new MiddleStat(false, true); 
        }

        var middleChar = text[pos + len / 2];
        var firstChar = text[pos];

        if (middleChar == firstChar)
        {
            return new MiddleStat(false, true);
        }

        for (int i = 0; i < len / 2; i++)
        {
            if (text[pos + i] != firstChar) // abaaaa, no special, can not be special in even longer substrings
            {
                return new MiddleStat(false, false);
            }

            if (text[pos + len - i - 1] != firstChar)
            {
                return new MiddleStat(false, true); // aaaba, no special, can be special in longer substrings like aaabaaa
            }
        }

        return new MiddleStat(true, false);
    }

    private struct MiddleStat
    {
        public MiddleStat(bool isSpec, bool canBeSpec)
        {
            IsSpecial = isSpec;
            CanBeSpecial = canBeSpec;
        }

        public bool IsSpecial { get; }
        public bool CanBeSpecial { get; }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = SubstrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
