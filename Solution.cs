using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Console.ReadLine();
        var X = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        var W = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

        Console.WriteLine(WeightedMean(X, W));
    }

    public static string WeightedMean(int[] values, int[] weights)
    {
        var sumOfWeightsTimesValues = 0;
        for(var i = 0; i < values.Length; i++)
        {
            sumOfWeightsTimesValues += values[i] * weights[i];
        }
        var sumOfWeights = 0;
        foreach (var weight in weights) sumOfWeights += weight;
        var result =(decimal)sumOfWeightsTimesValues / sumOfWeights;
        return String.Format("{0:0.0}", result);
    }
}