using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.test
{
    public class Test1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            /*
            目的： 求两个和为target的数组的索引
            思路： 一个循环就可以结束，每次都去查看dict中是否有 dict[target-nums[i]] 的值，有的话直接把i和index输出出来，没有就继续循环
            直到循环结束，给空数组
             */

            if (nums.Length < 2)
            {
                return new int[] { };
            }

            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var key = target - nums[i];
                if (dict.TryGetValue(key, out int index))
                {
                    return new int[] { i, index };
                }

                dict.TryAdd(nums[i], i);
            }

            return new int[] { };
        }

        public int BinarySearch(int[] nums, int target)
        {
            /*
            思路：
            循环的处理 满足left <= right 就可以进行取中然后位移的计算 
            */
            if (nums.Length == 0)
            {
                return -1;
            }

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

    }
}
