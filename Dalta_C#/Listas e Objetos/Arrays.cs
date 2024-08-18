using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista.Arrays;

class Arrays
{
    public static void Execute()
    {
        Console.WriteLine("--- ARRAY ---");

        int[] nums = [1, 4, 5 ,112];
        nums.Append(12);
        Console.WriteLine(nums[^1]);
    }
}
