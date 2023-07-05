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
            int i = arr.Length - 1;
            arr[0] = num;//哨兵
            while (arr[i] != num)
            {
                i--;
            }
            return i;
        }

    }
}
