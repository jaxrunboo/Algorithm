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

            //start<= end而不是start<end的原因：奇数情况下，最后会面临这个情况
            while (start <= end)
            {
                Console.WriteLine("HalfSearch运行次数:" + count++);
                int mid = (start + end) / 2;
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
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int InterpolationSearch(int[] arr, int num)
        {

            int start = 0;
            int end = arr.Length - 1;
            int count = 0;

            //start<= end而不是start<end的原因：奇数情况下，最后会面临这个情况
            while (start <= end)
            {
                Console.WriteLine("InterpolationSearch运行次数:" + count++);
                //查询元素index的占比位置
                int mid = start + (num - arr[start]) / (arr[end] - arr[start]) * (end - start);
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
            int end = arr.Length;
            int oldEnd = arr.Length;

            int count = 0;


            while (arr.Length > Fbi(k)-1)
            {
                k++;
            }

            for(int fbiStart =arr.Length -1; fbiStart < Fbi(k) - 1; fbiStart++)
            {
                arr[fbiStart] = arr[arr.Length - 1];
            }

            while(start <= end)
            {
                Console.WriteLine("FbiSearch运行次数:" + count++);

                int mid = start + Fbi(k-1) - 1;
                if(arr[mid] < num)
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
