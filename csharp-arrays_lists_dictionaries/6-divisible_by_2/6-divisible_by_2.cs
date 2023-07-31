using System;
using System.Collections.Generic;

class List
{
    public static List<bool> DivisibleBy2(List<int> myList)
    {
        List<bool> result = new List<bool>(myList.Count);

        foreach (int number in myList)
        {
            bool isDivisionBy2 = (number % 2 == 0);
            result.Add(isDivisionBy2);
        }

        return result;
    }
}