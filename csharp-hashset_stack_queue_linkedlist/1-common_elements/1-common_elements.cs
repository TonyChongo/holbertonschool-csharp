using System;
using System.Collections.Generic;

class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        Dictionary<int, int> elementCount = new Dictionary<int, int>();

        foreach (int num in list1)
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

        List<int> commonElement = new List<int>();

        foreach (int num in list2)
        {
            if (elementCount.TryGetValue(num, out int count) && count > 0)
            {
                commonElement.Add(num);
                elementCount[num]--;
            }
        }

        commonElement.Sort();

        return commonElement;
    }
}