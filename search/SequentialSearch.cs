using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.search
{
    /// <summary>
    /// 顺序查找只能处理小量数据
    /// </summary>
    internal class SequentialSearch
    {
        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Search(int[] arr, int num)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 哨兵模式的顺序查找
        /// 他的优点是，减少了i和 arr.Length比较的步骤
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Sentinel_Search(int[] arr, int num)
        {
            /*
             * 所谓的哨兵，就是将待查询的数据，作为一个值，作为循环的结束
             * 如果没有这个哨兵，他会一直-1,即使已经成为了负数
             * 
             * 所以哨兵模式用通俗的含义是：
             * 让我要查询的数字，在数组的开头去站岗，然后从后向前查询，直到查到哨兵的值，就能够确认，循环查找已经结束了
             * 
             * 
             * 1.第一个数字去比较
             * 2.执行比较
             * 3.循环比较结束后，将第一个数字修改回原值
             */
            if (arr[0] == num)
            {
                return 0;
            }

            int temp = arr[0];
            int i = arr.Length - 1;
            arr[0] = num;//哨兵
            while (arr[i] != num)
            {
                i--;
            }
            arr[0] = temp;
            return i;
        }

    }
}
