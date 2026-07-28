namespace Algorithm
{
    public class BacktrackingTemplate
    {
        public List<List<int>> Combinations(int n, int k)
        {
            /*
            题目：
            给定
            n = 4
            k = 2
            返回：
            [
            [1,2],
            [1,3],
            [1,4],
            [2,3],
            [2,4],
            [3,4]
            ]

            这题目是在做啥，我需要组合n个数，从1到n，选出k个数，返回所有可能的组合
            那就是 Ckn(数学表达式) = n! / (k! * (n-k)!)
            那么我需要一个方法，从1到n，选出k个数，返回所有可能的组合
            回溯法，从1到n，选出k个数，返回所有可能的组合
            public List<List<int>> Combinations(int n, int k)
            {
                List<List<int>> result = new List<List<int>>();
                List<int> current = new List<int>();
                Backtrack(result, current, 1, n, k);
                return result;
            }

            */
            List<List<int>> result = new List<List<int>>();
            List<int> current = new List<int>();
            Backtrack(result, current, 1, n, k);
            return result;

        }

        private void Backtrack(List<List<int>> result, List<int> current, int start, int n, int k)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                current.Add(i);
                Backtrack(result, current, i + 1, n, k);
                current.RemoveAt(current.Count - 1);
            }
        }

        public List<List<int>> CombinationSumIII(int k, int n)
        {
            /*
            题目：
          从1~9中选择不重复的k个数，要求和为n，返回所有可能的组合

            例如：

            k = 3

            n = 7

            答案：

            [
            [1,2,4]
            ]

            思路：
            这种要采用回溯

            */

            var result = new List<List<int>>();
            var current = new List<int>();
            Backtrack1(result, current, 1, k, n);
            return result;
        }

        private void Backtrack1(List<List<int>> result, List<int> current, int start, int k, int n)
        {
            if (current.Sum() > n) // 剪枝 pruning
            {
                return;
            }
            if (current.Count == k)
            {
                if (current.Sum() == n)
                {
                    result.Add(new List<int>(current));
                }
                return;
            }

            for (int i = start; i <= 9; i++)
            {
                current.Add(i);
                Backtrack1(result, current, i + 1, k, n);
                current.RemoveAt(current.Count - 1);
            }
        }

    }
}