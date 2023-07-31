using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        int MaxScore = -1;
        string bestKey = "None";

        foreach (var kvp in myList)
        {
            if (kvp.Value > MaxScore)
            {
                MaxScore = kvp.Value;
                bestKey = kvp.Key;
            }
        }
        return bestKey;
    }
}