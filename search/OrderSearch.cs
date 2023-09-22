using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.search
{
    /// <summary>
    /// 有序表查找
    /// 要求查找的arr是有序的
    /// </summary>
    internal class OrderSearch
    {
        /// <summary>
        /// 折半查找，T=O(log2N)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int HalfSearch(int[] arr, int num)
        {
            int start = 0;
            int end = arr.Length - 1;

            int count = 0;

            while (start <= end)
            {
                Console.WriteLine("HalfSearch运行次数:" + count++);
                int mid = GetMidIndex(start, end);
                if (arr[mid] < num)
                {
                    start = mid + 1;
                }
                else if (arr[mid] > num)
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        /// <summary>
        /// 插值查找(折半的升级版)
        /// 前提是查找arr顺序且分布均匀
        /// 是以一个占比的思路去设计的
        /// 
        /// 只是修改了mid的取值方式，以比重的方式去获取
        /// 这种思路，在逻辑上好像是可行的，要求arr强顺序，强分布均匀，要求其实有点非常高了
        /// 但是如果我的参数能够满足这个要求，就更像是人类去进行结果预估了
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int InterpolationSearch(int[] arr, int num)
        {

            int start = 0;
            int end = arr.Length - 1;
            int count = 0;

            while (start <= end)
            {
                Console.WriteLine("InterpolationSearch运行次数:" + count++);
                //查询元素index的占比位置
                int mid = GetMidIndex(start, end, arr, num);
                if (arr[mid] < num)
                {
                    start = mid + 1;
                }
                else if (arr[mid] > num)
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        

        private int GetMidIndex(int startIndex,int endIndex)
        {
            return (startIndex + endIndex) / 2;
        }

        private int GetMidIndex(int startIndex,int endIndex, int[] arr,int num)
        {
            return startIndex + (num - arr[startIndex]) / (arr[endIndex] - arr[startIndex]) * (endIndex - startIndex);
        }

        private int GetMidIndexForFBI(int start,int k)
        {
            return start + Fbi(k) - 1;
        }

        /// <summary>
        /// 裴波那契函数(也可以直接通过数组实现，此处递归仅为展示)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int Fbi(int index)
        {
            if (index < 2)
            {
                return index == 0 ? 0 : 1;
            }
            return Fbi(index - 1) + Fbi(index - 2);

        }


        /// <summary>
        /// 裴波那契查找(折半查找的升级版)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FbiSearch(int[] arr,int num)
        {
            /*
             * 思路：
             * 1. 扩充数组arr，使之length达到Fbi(k)-1的长度
             * 2. 使用传统的插值思路进行查询
             */
            int k = 0;
            int start = 0;
            int end = arr.Length -1;
            int oldEnd = arr.Length -1;

            int count = 0;

            //取长度最合适的k
            while (end > Fbi(k) - 1)
            {
                k++;
            }
            //补足右侧不足的数组内容
            for(int fbiStart =arr.Length; fbiStart < Fbi(k) - 1; fbiStart++)
            {
                arr[fbiStart] = arr[arr.Length - 1];
            }

            while(start <= end)
            {
                Console.WriteLine("FbiSearch运行次数:" + count++);

                int mid = GetMidIndexForFBI(start, k);
                if (arr[mid] < num)
                {
                    start = mid + 1;
                    k = k - 2;
                }
                else if(arr[mid] > num)
                {
                    end =mid -1;
                    k = k - 1;
                }
                else
                {
                    //此处的条件是因为，很可能mid一直取右边，超出了length，而超出length的值都是相等的
                    if(mid<= oldEnd)
                    {
                        return mid;
                    }
                    else
                    {
                        return oldEnd;
                    }
                }
            }
            return -1;
        }
    }
}
