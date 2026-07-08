namespace Algorithm
{
    public class Week1Templates
    {
        public int[] TwoSumInputArrayIsSorted(int[] nums, int target)
        {
            /*
            题目内容：
            给定一个已按升序排列的整数数组 numbers ，请你从数组中找出两个数满足相加之和等于目标数 target 。
            函数应该以长度为 2 的整数数组的形式返回这两个数的下标值。numbers 的下标 从 1 开始计数 ，所以答案数组应当满足 1 <= answer[0] < answer[1] <= numbers.length 。
            你可以假设每个输入只对应唯一的答案，而且你不可以重复使用相同的元素。
            示例 1：
            输入：numbers = [2,7,11,15], target = 9
            输出：[1,2]
            解释：2 与 7 之和等于目标数 9 。因此 index1 = 1, index2 = 2 。
            示例 2：
            输入：numbers = [2,3,4], target = 6
            输出：[1,3]
            示例 3：
            输入：numbers = [-1,0], target = -1
            输出：[1,2]

            思路：
            原先如果没有升序的时候，思路是用hash/dict实现的方式，逐条循环写入字典，循环到某一个值的时候，就得到了结果
            但是当前的数组是有序的，所以理论上有更优的思路
            此时使用双指针的方式，left从最小开始，right从最右开始(本来想right从target相关开始，但是如果有负数就不满足了)
            行为逻辑 
            判断 right和left所属值的和与target的关系
            == 则直接返回
            > 说明值过大，right左移 继续判断
            < 说明值过小 left右移 继续判断
            循环结束，返回 [-1,-1]
            循环的条件 left < right


            所以这个实现，对比hash的实现，空间复杂度更优
            */

            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return new int[] { -1, -1 };
        }

        public int[] FindFirstAndLastPositionOfElementInSortedArray(int[] nums, int target)
        {
            /*
            题目内容：
            给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
            如果数组中不存在目标值 target，返回 [-1, -1]。
            示例 1：
            输入：nums = [5,7,7,8,8,10], target = 8
            输出：[3,4]
            示例 2：
            输入：nums = [5,7,7,8,8,10], target = 6
            输出：[-1,-1]
            示例 3：
            输入：nums = [], target = 0
            输出：[-1,-1]

            思路：
            数组有序，还是进行查找某个值，完全可以使用二分。
            所以思路是，我二分查到某个值，左右判断值的数量即可。
            或者，能不能直接二分查完呢（这个好像更加不合适，我二分查到的时候是判断==，如果修改这个条件，二分可能就失效了）
           */

            /* 
            这是我用我自己的思路实现出来的
            可是他的时间复杂度是 O(logN)+O(n) 不合适            
            int left = 0;
            int right = nums.Length - 1;
            int index = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (index == -1)
            {
                return new int[] { -1, -1 };
            }

            int leftIndex = index;
            int rightIndex = index;
            // 接下来开始判断左右两边的值
            for (int i = index - 1; i >= 0; i--)
            {
                if (nums[i] == target)
                {
                    leftIndex = i;
                }
                else
                {
                    break;
                }
            }

            for (int i = index + 1; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    rightIndex = i;
                }
                else
                {
                    break;
                }
            }
            return new int[] { leftIndex, rightIndex };
            */

            /*
            更优的实现方式
            */

            int leftIndex = FindLeftIndex(nums, target);
            if (leftIndex == -1)
            {
                return new int[] { -1, -1 };
            }
            int rightIndex = FindRightIndex(nums, target);
            return new int[] { leftIndex, rightIndex };
        }

        private int FindLeftIndex(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }

        private int FindRightIndex(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }
    }
}