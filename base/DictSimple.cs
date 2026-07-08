namespace Algorithm
{
    public class DictSimple
    {

        public int[] TwoSum(int[] nums, int target)
        {
            /*
            这里是求数组中的两数之和 = target
            返回这两个数的索引
            nums = [2,7,11,15], target = 9
            return [0,1]
            nums = [3,2,4], target = 6
            return [1,2]
            nums = [3,3], target = 6
            return [0,1]

            思路：
            1. 如果是暴力穷举，每个值都要在数组中循环找 targer - arr[n],这个时间复杂度就是O(n^2)
            2. 如果使用数据字段，key是值，value是index，理论上第一次循环赋值，第二次循环直接找 target - key 的 index即可 O(n)。
            但是这个逻辑需要考虑重复key如何处理。我觉得如果出现重复key，如果两个key != target可以直接抛弃掉
            3. 还有更好的方案吗， 上面这个理论上可以把全部的内容找到。但是这个题目并不需要全部的内容，我只要找到第一组即可。
            所以思路是，还是用dictionary,但是，我不需要先过第一次循环，而是直接在一个循环中做掉
            第一个元素，放在dict中
            第二个元素开始，先去比对 target -key 的值，是否已经在dict中有key了，有的话，直接抛出，循环结束。没有的话，继续add
            直到循环结束
            如果直到结束还没有抛出，int的返回值也应该是空的
            */

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // var key = target - nums[i];
                // if (dict.ContainsKey(key))
                // {
                //     return new int[] { i, dict[key] };
                // }
                if (dict.TryGetValue(target - nums[i], out int index)) // 优化版
                {
                    return new int[] { i, index };
                }
                dict.TryAdd(nums[i], i);
            }
            return new int[0];
        }


        public bool ValidAnagram(string s, string t)
        {
            /*
            这里是判断两个字符串是否是字母异位词
            两个字符串中包含的字母相同，但是顺序不同
            返回true or false

            思路：
            1. 我使用hashset，把第一个存入，第二个逐个比对，任何不不含的都有问题。但是也需要把第二个存入，用第一个去比对
            实际上就是两者取差集
            这个时间复杂度是O(n) 但是空间复杂度是O(2n)
            2. 更好的思路呢
            我还是使用hashset,我把s放进去，然后对t的内容逐条比对，从s中删除。如果有不存在的，异常，如果全存在，但是最后s还是有
            多余的值，也是异常。 这样空间复杂度是O(n)
            3. 他不是说可以用ascii码的方式来计算吗
            用一个26长度的数组来存储，s中每个字母的个数，然后对t中的每个字母的个数进行减法操作。如果最终结果为0，则说明是异位词。
            这个时间复杂度是O(n) 但是空间复杂度是O(1)
            */
            if(s.Length != t.Length)
            {
                return false;
            }

            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                arr[t[i] - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}