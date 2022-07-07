using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlowApp
{
    /// <summary>
    /// Create a method for each type of loop
    /// which returns the highest number
    /// within a list
    /// </summary>
    public static class LoopTypes
    {
        public static int HighestForEachLoop(List<int> nums)
        {
            int highest = nums[0];
            //think about edge cases
            foreach (int i in nums)
            {
                if (highest < i)
                {
                    highest = i;
                }
            }
            return highest;
        }

        public static int HighestForLoop(List<int> nums)
        {
            int highest = nums[0];
            for (int i = 0; i < nums.Count; i++)
            {
                if (highest < nums[i])
                {
                    highest = nums[i];
                }
            }
            return highest;
        }

        public static int HighestWhileLoop(List<int> nums)
        {
            int highest = nums[0];
            int i = 0;
            while (i < nums.Count)
            {
                if (highest < nums[i])
                {
                    highest = nums[i];
                }
                i++;
            }
            return highest;
        }

        public static int HighestDoWhileLoop(List<int> nums)
        {
            int highest = nums[0];
            int i = 0;
            do
            {
                if (highest < nums[i])
                {
                    highest = nums[i];
                }
                i++;
            } while (i < nums.Count);
            return highest;
        }

        public static int LowestForEachLoop(List<int> nums)
        {
            int lowest = nums[0];
            //think about edge cases
            foreach (int i in nums)
            {
                if (lowest > i)
                {
                    lowest = i;
                }
            }
            return lowest;
        }

        public static int LowestForLoop(List<int> nums)
        {
            int lowest = nums[0];
            for (int i = 0; i < nums.Count; i++)
            {
                if (lowest > nums[i])
                {
                    lowest = nums[i];
                }
            }
            return lowest;
        }

        public static int LowestWhileLoop(List<int> nums)
        {
            int lowest = nums[0];
            int i = 0;
            while (i < nums.Count)
            {
                if (lowest > nums[i])
                {
                    lowest = nums[i];
                }
                i++;
            }
            return lowest;
        }

        public static int LowestDoWhileLoop(List<int> nums)
        {
            int lowest = nums[0];
            int i = 0;
            do
            {
                if (lowest > nums[i])
                {
                    lowest = nums[i];
                }
                i++;
            } while (i < nums.Count);
            return lowest;
        }
    }
}
