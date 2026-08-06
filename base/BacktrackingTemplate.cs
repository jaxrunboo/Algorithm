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


        public List<List<int>> CombinationSum(int[] candidates, int target)
        {
            /*
            题目：
            给定一个无重复元素的数组candidates和一个目标数target，找出candidates中所有和为target的组合。
            candidates中的每个数字在每个组合中可以使用多次

            例如：
            candidates = [2,3,6,7]
            target = 7

            答案：
            [
            [2,2,3],
            [7]
            ]

            思路：
            这种要采用回溯
            但是，当前节点的数据使用了之后，还可以继续使用

            */

            var result = new List<List<int>>();
            var current = new List<int>();
            BackTrackRepeatSum(result, current, candidates, target, 0);
            return result;
        }

        private void BackTrackRepeatSum(List<List<int>> result, List<int> current, int[] candidates, int target, int start)
        {
            if (current.Sum() > target)
            {
                return;
            }

            if (current.Sum() == target)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                current.Add(candidates[i]);
                BackTrackRepeatSum(result, current, candidates, target, i);
                current.RemoveAt(current.Count - 1);
            }
        }


        public List<List<int>> CombinationSumII(int[] candidates, int target)
        {
            /*
            题目：
            给定一个有重复元素的数组candidates和一个目标数target，找出candidates中所有和为target的组合。
            candidates中的每个数字在每个组合中只能使用一次。

            例如：
            candidates = [10,1,2,7,6,1,5]
            target = 8

            答案：
            [
            [1,1,6],
            [1,2,5],
            [1,7],
            [2,6]
            ]

            思路：
            这种要采用回溯
            但是，当前节点的数据使用了之后，不可以继续使用
            因此，每次都要查下一个节点
            而且需要预先排序
            同一层的相同元素需要处理

            */

            var result = new List<List<int>>();
            var current = new List<int>();
            Array.Sort(candidates);
            BackTrackNoRepeatSum2(result, current, candidates, target, 0);
            return result;
        }

        private void BackTrackNoRepeatSum2(List<List<int>> result, List<int> current, int[] candidates, int target, int start)
        {
            if (current.Sum() > target)
            {
                return;
            }
            if (current.Sum() == target)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                current.Add(candidates[i]);
                BackTrackNoRepeatSum2(result, current, candidates, target, i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }


        public List<List<string>> NQueens(int n)
        {
            /*
            题目：
            给定一个整数n，返回所有可能的n皇后问题的解决方案。
            
            例如：
            n = 4

            答案：
            [
            [".Q..","...Q","Q...","..Q."],
            ["..Q.","Q...","...Q",".Q.."]
            ]

            思路：
            回溯
            需要一个方法，判断当前位置是否可以放置皇后
            这个方法的逻辑是判断 左上 上 右上 是否已经放置了皇后

            */

            var result = new List<List<string>>();
            var current = new List<string>();
            BackTrackNQueens(result, current, n, 0);
            return result;
        }

        private void BackTrackNQueens(List<List<string>> result, List<string> current, int n, int row)
        {
            if (row == n)
            {
                result.Add(new List<string>(current));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!HasQueen(current, row, col))
                {
                    current.Add(new string('.', col) + 'Q' + new string('.', n - col - 1));
                    BackTrackNQueens(result, current, n, row + 1);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }


        private bool HasQueen(List<string> current, int row, int col)
        {
            for (int i = 1; i <= row; i++)
            {
                if (current[row - i][col] == 'Q')
                {
                    return true;
                }
                if (col - i >= 0 && current[row - i][col - i] == 'Q')
                {
                    return true;
                }
                if (col + i < current[0].Length && current[row - i][col + i] == 'Q')
                {
                    return true;
                }
            }

            return false;
        }


        public List<string> LetterCombinationsOfaPhoneNumber(string digits)
        {
            /*
            题目：
            给定一个包含数字2-9的字符串digits，返回所有可能的字母组合。
            每个数字对应一个字母，2对应abc，3对应def，4对应ghi，5对应jkl，6对应mno，7对应pqrs，8对应tuv，9对应wxyz
            例如：
            digits = "23"

            答案：
            ["ad","ae","af","bd","be","bf","cd","ce","cf"]

            思路：
            回溯
            这明显是各个数组的值都是唯一的，而且顺序已经排好了
            所以，满足数量就可以获得结果

            */

            var result = new List<string>();
            var current = new List<string>();

            var dict = new Dictionary<char, string>
            {
                {'0', ""},
                {'1', ""},
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"},
            };

            BackTrackLetterCombinationsOfaPhoneNumber(result, current, dict, digits, 0);
            return result;
        }

        private void BackTrackLetterCombinationsOfaPhoneNumber(List<string> result, List<string> current, Dictionary<char, string> dict, string digits, int index)
        {
            if (current.Count == digits.Length)
            {
                result.Add(string.Join("", current));
                return;
            }

            var success = dict.TryGetValue(digits[index], out string digitValue);
            if (!success) return;

            foreach (var letter in digitValue)
            {
                current.Add(letter.ToString());
                BackTrackLetterCombinationsOfaPhoneNumber(result, current, dict, digits, index + 1);
                current.RemoveAt(current.Count - 1);
            }

        }

        public List<string> RestoreIPAddresses(string s)
        {
            /*
            题目：
            给定一个只包含数字的字符串s，请将它分割成三个或四个子字符串，每个子字符串代表一个IP地址的一部分。
            返回所有可能的IP地址组合。

            例如：
            s = "25525511135"
            答案：
            ["255.255.11.135","255.255.111.35"]

            思路：
            回溯
            
            我如何判断这个字符是ip的一部分呢
            如果这个字符是ip的一部分，那么这个字符的值不能大于255
            如果这个字符是ip的一部分，那么这个字符的值不能小于0

            问题似乎可以转化成，s的组合情况，每个组合都代表一个ip地址的一部分
            必须只能组合成4个，多了就不满足场景
            可以进行适当的剪枝


            */

            var result = new List<string>();
            var current = new List<string>();
            BackTrackRestoreIPAddresses(result, current, s, 0);
            return result;

        }

        private void BackTrackRestoreIPAddresses(List<string> result, List<string> current, string s, int index)
        {
            if (current.Count == 4)
            {
                if (index == s.Length)
                {
                    result.Add(string.Join(".", current));
                }
                return;
            }

            for (int i = index; i < s.Length && i - index < 3; i++)
            {
                var segment = s.Substring(index, i - index + 1);
                if (!IsValidSegment(segment))
                {
                    continue;
                }
                current.Add(segment);
                BackTrackRestoreIPAddresses(result, current, s, i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }

        private bool IsValidSegment(string segment)
        {
            if (segment.Length > 1 && segment[0] == '0')
            {
                return false;
            }
            return int.Parse(segment) <= 255;
        }

    }

}
