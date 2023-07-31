using System;
using System.Collections.Generic;

class Dictionary
{
    public static int NumberOfKeys(Dictionary<string, string> myDict)
    {
        int count = 0;

        foreach (var kvp in myDict)
        {
            count++;
        }

        return count;
    }
}