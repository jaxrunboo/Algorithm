using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.search
{
    internal class Sort
    {
        /// <summary>
        /// 最基础的交换排序
        /// 小的放在最前面，循环执行
        /// </summary>
        /// <param name="arr"></param>
        public void SwapSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int j = index + 1; j < arr.Length; j++)
                {
                    if (arr[index] > arr[j])
                    {
                        Swap(arr, index, j);
                    }
                }
            }

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }


        /// <summary>
        /// 冒泡排序
        /// 自后向前，把最小值挤到最前面
        /// 目前看相对交换排序没有提升，都是T(n^2)
        /// </summary>
        /// <param name="arr"></param>
        public void BubbleSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int end = arr.Length - 2; end >= index; end--)
                {
                    if (arr[end] > arr[end + 1])
                    {
                        Swap(arr, end, end + 1);
                    }
                }
            }
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// 冒泡的优化算法
        /// 通过设置flag，减少成功排序后的执行次数
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void BetterBubbleSort(int[] arr)
        {
            //增加一个flag来标识是否还需要继续进行排序
            bool flag = true;
            for (int index = 0; index < arr.Length && flag; index++)
            {
                flag = false;
                for (int end = arr.Length - 2; end >= index; end--)
                {
                    if (arr[end] > arr[end + 1])
                    {
                        Swap(arr, end, end + 1);
                        flag = true;
                    }
                }
            }
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }

        }

        private void Swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
