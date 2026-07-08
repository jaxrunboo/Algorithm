namespace Algorithm
{
    public class PrefixSum
    {
        private int[] prefixSum;

        public PrefixSum(int[] nums)
        {
            int total = 0;
            prefixSum = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                prefixSum[i] = total;
            }
        }

        public int RangeSum(int left, int right)
        {
            if (left == 0) return prefixSum[right];
            return prefixSum[right] - prefixSum[left - 1];
        }
    }

    public class FindPivotIndexClass
    {
        /*
        题目内容：
        给定一个整数数组 nums，请编写一个能够返回数组 “中心下标” 的方法。
        中心下标是数组的一个下标，其左侧所有元素相加的和等于右侧所有元素相加的和。
        如果数组不存在中心下标，返回 -1。
        如果数组有多个中心下标，返回最靠近左边的那一个。
        数组下标从 0 开始。
        数组长度范围是 [0, 10000]。
        每个元素的值范围是 [-1000, 1000]。
        
        思路：
        我现在能够很容易的计算 rangeSum(l,r)
        rangeSum(i+1,length-1) = sum(i-1)
        sum(length-1) - sum(i) = sum(i-1)

        直接在循环时判断 right = total - left - nums[i] = left 
        比算出最后的公式来更加容易理解，并且不需要额外物理空间，边界范围也不需要考虑太多

   
        */
        public int FindPivotIndex(int[] nums)
        {
            int total = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
            }

            int leftSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int right = total - leftSum - nums[i];
                if (leftSum == right)
                {
                    return i;
                }
                leftSum += nums[i];
            }

            return -1;
        }
    }


}