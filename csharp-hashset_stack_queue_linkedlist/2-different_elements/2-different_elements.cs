using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        Dictionary<int, int> elementCount1 = new Dictionary<int, int>();
        Dictionary<int, int> elementCount2 = new Dictionary<int, int>();
        // Create dictionaries to store the occurrences of elements in both lists

        PopulateElementCount(list1, elementCount1);
        PopulateElementCount(list2, elementCount2);
        // Populate the dictionaries with elements from list1 and list2

        List<int> differentElements = new List<int>();
        // Create a list to store the different elements

        foreach (int num in list1)
        {
            if (!elementCount2.ContainsKey(num))
            {
                differentElements.Add(num);
            }
        }

        foreach (int num in list2)
        {
            if (!elementCount1.ContainsKey(num))
            {
                differentElements.Add(num);
            }
        }

        differentElements.Sort();

        return differentElements;
    }

    private static void PopulateElementCount(List<int> inputList, Dictionary<int, int> elementCount)
    {
        foreach (int num in inputList)
        {
            if (elementCount.ContainsKey(num))
            {
                elementCount[num]++;
            }
            else
            {
                elementCount[num] = 1;
            }
        }
    }
}