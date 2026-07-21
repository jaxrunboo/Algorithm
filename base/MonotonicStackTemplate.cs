namespace Algorithm
{
    public class MonotonicStackTemplate
    {

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            /*
            题目内容
            给定两个数组 nums1 和 nums2，二者没有包含关系。
            对 nums1 中每个数字 x（按值查询），在 nums2 中找到 x 对应的「下一个更大元素」：
            即 nums2 中 x 第一次出现位置右侧，第一个比 x 大的数字。
            若 x 不在 nums2 中，或右侧不存在更大的数，返回 -1。
            nums1 中出现重复值时，查到的答案相同（都对应 nums2 里同一个 x）。

            思路：
            暴力：遍历 nums1，对每个 x 在 nums2 里找位置再向右扫，O(n * m)。

            优化分两步：
            1. 单调栈预处理 nums2（O(m)）
               - 栈存 nums2 的下标（不是值）
               - 从左到右扫 nums2，栈顶下标对应值 < 当前值时弹栈，说明当前值就是它的下一个更大元素
               - 弹栈时写入 result[下标]；扫完后仍在栈中的下标，右侧无更大元素，赋 -1
            2. 字典按值查 nums1（O(n + m)）
               - 把 nums2 每个值映射到其下一个更大元素；同一值多次出现只保留第一次出现的结果
               - 遍历 nums1，dict 能查到则用对应值，否则 -1
            */

            // 第一步：单调栈预处理 nums2，result[i] = nums2[i] 右侧第一个更大的数
            var stack = new Stack<int>();
            var result = new int[nums2.Length];
            Array.Fill(result, -1);

            for (int i = 0; i < nums2.Length; i++)
            {
                while (stack.Count > 0 && nums2[stack.Peek()] < nums2[i])
                {
                    var pop = stack.Pop();
                    result[pop] = nums2[i];
                }
                stack.Push(i);
            }

            // 第二步：值 -> 下一个更大元素（同一值取 nums2 中第一次出现的结果）
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < result.Length; i++)
            {
                if (!dict.ContainsKey(nums2[i]))
                {
                    dict.TryAdd(nums2[i], result[i]);
                }
            }

            // 第三步：按值查 nums1，不在 nums2 中则 -1
            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.TryGetValue(nums1[i], out var value))
                {
                    nums1[i] = value;
                }
                else
                {
                    nums1[i] = -1;
                }
            }
            return nums1;


        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            /*
            题目内容
            给定一个整数数组 temperatures，表示每天的温度。
            返回一个数组 answer，其中 answer[i] 表示第 i 天需要等待多少天才能得到更暖和的温度。
            如果之后都不会更暖和，请在该位置用 0 来代替。

            思路：
            结合上面的题目，就有更好的方式了
            用单调递减栈，题目转化为 查比当前值大的下一个值，跟当前值的索引差值就是需要等待的天数
            */

            var stack = new Stack<int>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    var pop = stack.Pop();
                    temperatures[pop] = i - pop;
                }
                stack.Push(i);
            }
            while (stack.Count > 0)
            {
                var pop = stack.Pop();
                temperatures[pop] = 0;
            }
            return temperatures;

        }
    }
}