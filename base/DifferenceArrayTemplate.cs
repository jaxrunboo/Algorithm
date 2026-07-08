namespace Algorithm
{
    public class DifferenceArrayTemplate
    {
        public int[] RangeAddition(int length, int[][] operations)
        {
            /*
            题目内容：
            给你一个长度为 n 的数组 nums ，初始化时所有数组的值都是 0 。
            然后给你一个数组 operations ，operations[i] = [starti, endi, vali] ，
            表示对 nums 的第 starti 到第 endi 个元素都加上 vali 。
            
            length = 5
            operations = [[1,3,2],[2,4,3],[0,2,-2]]
            返回：[-2,0,3,5,3]
            */

            /*
            思路：
            对数组的区间值进行调整，思路就可以准确定位到差分数组
            差分数组的含义： 表示相邻两个元素的差值，他的前缀和就是原数组的值
            因此可以对查分数组的值进行调整，进而可以在求前缀和的时候，获得变更后的数组值
            */

            int[] difference = new int[length];
            foreach (var item in operations)
            {
                int left = item[0];
                int right = item[1];
                int val = item[2];

                difference[left] += val;
                if (right + 1 < length)
                    difference[right + 1] -= val;
            }

            // 可以直接用diff数组进行数据累计，也可以用一个新数组来做
            for (int i = 1; i < length; i++)
            {
                difference[i] += difference[i - 1];
            }
            return difference;

        }


        public int[] CorporateFlightBookings(int n, int[][] bookings)
        {
            /*
            题目内容：
            这里有 n 个航班，它们分别从 1 到 n 进行编号。
            有一份航班预订表 bookings ，表中第 i 条预订记录 bookings[i] = [firsti, lasti, seatsi] 
            意味着在从 firsti 到 lasti （包括 firsti 和 lasti ）的每个航班上预订了 seatsi 个座位。
            请你返回一个长度为 n 的数组 answer，其中 answer[i] 是航班 i 上预订的座位总数。

            思路：
            数组是各个航班的人数,下标是航班号-1
            查分数组是各个航班的差值
            唯一的差别就是索引从1开始，因此需要对索引进行转换
            */

            int[] difference = new int[n];
            foreach (var item in bookings)
            {
                int left = item[0];
                int right = item[1];
                int val = item[2];

                difference[left - 1] += val;
                if (right < n) difference[right] -= val;
            }

            for (int i = 1; i < n; i++)
            {
                difference[i] += difference[i - 1];
            }
            return difference;

        }

    }
}