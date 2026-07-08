namespace Algorithm
{
    public class SlidingWindowTemplate
    {
        public int LongestSubstringWithoutRepeatingCharacters(string s)
        {
            /*
            这里是求一个字符串中，最长的没有重复字符的子串
            返回最长子串的长度
            s = "abcabcbb"
            return 3

            说是需要用滑动窗口：
            那盲猜一下思路是，两个指针的含义是窗口的开始和结束，但是都是从一侧开始
            第一个指针先不动，第二个指针右移。逻辑是，只要不在前面的hash内就右移。
            直到发现右边的字符存在了，这个时候记录长度。
            然后左侧指针右移，直到找到和右边字符相同的内容再+1.
            此时窗口就没有重复了，再继续右移右侧指针。循环执行

            直到右侧指针到底。
            每次相同都计算最大长度
            */

            if (s.Length <= 0) return 0;

            int maxLength = 0;

            int left = 0;
            int right = 0;

            var hashset = new HashSet<char>();

            for (; right < s.Length; right++)
            {
                while (hashset.Contains(s[right]))
                {
                    hashset.Remove(s[left++]);
                }
                hashset.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }


        public int LongestSubstringWithoutRepeatingCharactersV_Dict(string s)
        {
            /*
            数据字典的实现的话，就可以把直接跳到相同值的index,而不需要一次次循环。
            但是实现起来可能有问题，可能还是要循环删除吧

            实际上是不用的，可以直接把重复的位置覆盖掉

            */

            if (s.Length <= 0) return 0;

            int maxLength = 0;

            int left = 0;
            int right = 0;

            var dict = new Dictionary<char, int>();

            for (; right < s.Length; right++)
            {
                if (dict.TryGetValue(s[right], out int index) && index >= left)
                {
                    left = index + 1;
                }
                dict[s[right]] = right;
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }



        public int MinimumSizeSubarraySum(int target, int[] nums)
        {
            /*
            题目内容：
            给定一个含有 n 个正整数的数组和一个正整数 target 。

找出该数组中满足其和 ≥ target 的长度最小的 连续子数组 [nums_l, nums_l+1, ..., nums_r-1, nums_r] ，并返回其长度。如果不存在符合条件的子数组，返回 0 。

示例 1：

输入：target = 7, nums = [2,3,1,2,4,3]
输出：2
解释：子数组 [4,3] 是该条件下的长度最小的子数组。

            思路：
            这种求连续几个内容的场景，往往都是需要滑动窗口的

            还是先移动r,当 l -> r之间的数据<t，继续右移 
            =t 记录值，然后右移l 右移r 循环计算
            >t 右移l 计算 
            感觉可以把每一步位移都发生计算
            */

            int minSize = int.MaxValue;
            int left = 0;
            int right = 0;

            if (nums.Length <= 0) return Math.Min(minSize, 0);

            int sum = 0;
            for (; right < nums.Length; right++)
            {
                sum += nums[right];

                while (sum >= target)
                {
                    minSize = Math.Min(minSize, right - left + 1);
                    sum -= nums[left++];
                }
            }

            return Math.Min(minSize, 0);

        }

    }
}