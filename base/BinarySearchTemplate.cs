namespace Algorithm
{
    public class BinarySearchTemplate
    {
        public int BinarySearch(int[] nums, int target)
        {
            /*
            给定一个升序整数数组 nums 和一个目标值 target。
如果目标值存在，返回它的下标；否则返回 -1。

            思路：
            有序，可直接二分查找


            */


            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        public int SearchInsertPosition(int[] nums, int target)
        {
            /*
            给定一个升序整数数组 nums 和一个目标值 target。

            如果目标值存在，返回它的下标；否则返回它应该被插入的位置。
            
            */

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;

        }
    }
}