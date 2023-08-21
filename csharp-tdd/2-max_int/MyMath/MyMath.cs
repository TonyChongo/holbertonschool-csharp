using System;
using System.Collections.Generic;

namespace MyMath
{
    /// <summary>
    /// Operation class
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Public integer
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Max(List<int> nums)
        {
            if (nums.Count == 0)
                return 0;

            int max = nums[0];
            foreach (int num in nums)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }
    }
}
