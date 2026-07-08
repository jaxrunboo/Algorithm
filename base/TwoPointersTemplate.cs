namespace Algorithm
{
    public class TwoPointersTemplate
    {
        public bool ValidPalindrome(string s)
        {
            /*
            这里是判断一个字符串是否是回文
            回文是指正序和倒序相同的字符串
            返回true or false

            思路：
            上一个数据字典、hash用的时候往往只关注存在，不关注顺序
            现在看双指针是要关注顺序的

            1. 暴力穷举
            先把字符串中的特殊信息先摘出来，然后再一次循环进行前后值比对
            O(2n) O(n)
            2. 双指针
            不也是两边同时跑吗，我跳过特殊符号就好了，左侧加一右侧减一，两者只要不相等就结束
            O(n) O(1)
            */

            if (s.Length == 0)
            {
                return false;
            }
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;

                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public int ContainerWithMostWater(int[] height)
        {
            /*
            这里是求一个数组中，两个值之间的最大面积
            返回最大面积
            height = [1,8,6,2,5,4,8,3,7]
            return 49
            height = [1,1]
            return 1
            */

            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;
            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, area);
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxArea;
        }

    }
}