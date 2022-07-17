using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static void whatFlavors(List<int> cost, int money)
    {
        var costSet = cost
            .Select((item, index) => new{index,item})
            .GroupBy(q => q.item)
            .ToDictionary(i => i.Key, i => i.Select(q => q.index).ToArray());
        
        for (var i = 0; i < cost.Count; i++)
        {
            var c = cost[i];
            if (c >= money) continue;
            
            var missingMoney = money - c;    
            
            if (costSet.TryGetValue(missingMoney, out int[] indexes))
            {
                for (var j = 0; j < indexes.Length; j++)
                {
                    var index = indexes[j];
                    
                    if (index == i) continue;
                        
                    Console.WriteLine($"{i + 1} {index + 1}"); 
                    
                    return;      
                }
            }
        }   
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> cost = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(costTemp => Convert.ToInt32(costTemp)).ToList();

            Result.whatFlavors(cost, money);
        }
    }
}
