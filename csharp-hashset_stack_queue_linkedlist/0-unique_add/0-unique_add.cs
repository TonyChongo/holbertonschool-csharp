using System;
using System.Collections.Generic;

class List
{
    public static int Sum(List<int> myList)
    {
        Dictionary<int, int> uniqueInteger = new Dictionary<int, int>();

        foreach (int num in myList)
        {
            if (uniqueInteger.ContainsKey(num))
            {
                uniqueInteger[num]++;
            }
            else
            {
                uniqueInteger[num] = 1;
            }
        }
        int sum = 0;
        foreach (var kvp in uniqueInteger)
        {
            sum += kvp.Key;
        }
        return sum;
    }
}