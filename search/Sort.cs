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

            PrintArr(arr);
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
            PrintArr(arr);
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
            PrintArr(arr);

        }
        
        
        /// <summary>
        /// 简单选择排序
        /// 逻辑就是每次循环选中最小值的index，与起始index元素swap
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void EasySelectSort(int[] arr)
        {
            /*
             * 思路相差不大，从第一个元素开始循环，用一个min做标识，跟后面循环比较
             * 直到找到最小值才会进行swap
             * 相对冒泡来讲，降低了swap的次数，但是没有降低查找次数，T不变
             */
            int min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                min = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(arr,min,i);
                }
            }
            PrintArr(arr);
        }

        public void InstantInsertSort(int[] arr)
        {
            int temp = 0;
            int j = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    temp = arr[i];
                    //如果arr[j]始终大于temp，就要一直往移一位
                    //最终情况，如果arr[0]
                    for (j = i - 1; j >= 0 && arr[j] > temp; j--)
                    {
                        arr[j + 1] = arr[j];
                    }
                    //此处的j+1并非表示逻辑index，而是上面循环执行结束后，j又多减了一次1，所以加上
                    arr[j + 1] = temp;
                }
            }
            PrintArr(arr);
        }

        private void Swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        private void PrintArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
