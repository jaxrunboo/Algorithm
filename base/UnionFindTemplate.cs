namespace Algorithm
{
    public class UnionFindTemplate
    {
        public int NumberOfProvinces(int[][] isConnected)
        {
            /*
            题目：
            有 n 个城市，其中一些彼此相连，另一些没有相连。
            如果城市 a 与城市 b 直接相连，且城市 b 与城市 c 直接相连，那么城市 a 与城市 c 间接相连。
            省份 是一组直接或间接相连的城市，组内不含其他没有相连的城市。
            给你一个 n x n 的矩阵 isConnected，其中 isConnected[i][j] = 1 表示第 i 个城市和第 j 个城市直接相连，
            否则为 0。返回矩阵中 省份 的数量。

            示例 1：
            输入：isConnected = [
            [1,1,0],
            [1,1,0],
            [0,0,1]]
            输出：2
            解释：城市 0 和城市 1 直接相连，城市 2 独立，所以有 2 个省份。

            示例 2：
            输入：isConnected = [[1,0,0],[0,1,0],[0,0,1]]
            输出：3
            解释：三个城市分别属于三个不同的省份。

            思路：
            这是典型的并查集题目。每个城市一开始各自成一个集合，
            如果两个城市直接相连，就把它们所在的集合合并。
            最终集合的个数就是省份数量。

            并查集核心操作：
            1. Find：沿着 parent 找到根节点，并用路径压缩把沿途节点直接挂到根上。
            2. Union：把两个根合并；这里用按秩合并，避免树退化成链表。
            3. 遍历矩阵上三角，isConnected[i][j] == 1 时 Union(i, j)。
            4. 统计 parent[i] == i 的个数，即根节点个数。
            */

            var n = isConnected.Length;
            var parent = new int[n]; // 每个省份的父节点，一开始是他自己
            var rank = new int[n]; // 每个省份的秩，一开始是0
            int provinceCount = n;

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            // 上三角遍历
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1 && Union(parent, rank, i, j))
                    {
                        provinceCount--;
                    }
                }
            }

            return provinceCount;
        }

        private bool Union(int[] parent, int[] rank, int x, int y)
        {
            var rootX = Find(parent, x);
            var rootY = Find(parent, y);
            if (rootX == rootY)
            {
                return false;
            }

            if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else
            {
                parent[rootX] = rootY;
                rank[rootY]++;
            }

            return true;
        }

        private int Find(int[] parent, int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent, parent[x]);
            }
            return parent[x];
        }


        public int[] RedundantConnection(int[][] edges)
        {
            /*
            题目（LeetCode 684）：
            一棵树上有 n 个节点，标号从 1 到 n。再额外添加一条边后，图里恰好出现一个环。
            返回可以删去使得图重新变成树的那条边。如果有多个答案，返回在 edges 中出现最晚的那条。

            示例 1：
            输入：edges = [[1,2],[1,3],[2,3]]
            输出：[2,3]
            解释：[1,2]、[1,3] 正常建树；处理 [2,3] 时 2 和 3 已经连通，这条边造成环。

            示例 2：
            输入：edges = [[1,2],[2,3],[3,4],[1,4],[1,5]]
            输出：[1,4]

            思路：
            按 edges 顺序逐条处理。若 u 和 v 已经在同一集合（Find(u) == Find(v)），
            说明这条边是多余的，直接返回；否则 Union(u, v)。
            注意节点编号从 1 开始，parent 数组开 n+1。
            */

            var n = edges.Length;
            var parent = new int[n + 1];
            var rank = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                var u = edge[0];
                var v = edge[1];
                if (Find(parent, u) == Find(parent, v))
                {
                    return edge;
                }
                Union(parent, rank, u, v);
            }

            return new int[0];
        }


        public int NumberOfOperationsToMakeNetworkConnected(int n, int[][] connections)
        {
            /*
            题目：
            有 n 个计算机，编号从 0 到 n-1。给定一个列表 connections，
            其中 connections[i] = [a, b] 表示计算机 a 和 b 直接相连。
            返回使所有计算机连通所需的最少操作数。如果无法连通所有计算机，返回 -1。

            思路：
            一眼并查集
            
            边界： 要求线的数量要 >= 节点数 -1
            然后，判断联通块数量
            这个值 -1 就是需要的调整的网线数量

            这其中的 n-1 是公式计算出来的

            每个联通块预留的最小网线数量 = S(n) - 1
            假设有k个联通块
            整个图需要的最小网线数量 = n - k
            需要变更的网线数量 = k - 1 
            总的网线数量 = m
            m - (n - k) >= k - 1
            => m >= n - 1

            */

            if (connections.Length < n - 1)
            {
                return -1;
            }

            var parent = new int[n];
            var rank = new int[n];
            var count = n;

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            for (int i = 0; i < connections.Length; i++)
            {
                if (Union(parent, rank, connections[i][0], connections[i][1]))
                {
                    count--;
                }
            }

            return count - 1;

        }


        public List<List<string>> AccountsMerge(List<List<string>> accounts)
        {
            /*
            题目：
            给定一个列表 accounts，其中每个元素 accounts[i] 是一个字符串列表，表示一个账户的邮箱地址。
            现在需要将具有相同邮箱地址的账户合并。
            返回合并后的账户列表。每个账户的邮箱地址列表可以按任意顺序返回。

            所以这种情况，可以使用并查集
             节点是账户信息，两者可以取交集，有值说明可以合并，但是这种通过list的实现方式很困难
             应该是各个list的交叉对比，这是不是要 n* n 了

             如果我只把邮箱当做节点，会有更好的处理方式吗
             先每组账户内部union，再组件union,似乎跟一组账户作为界面，看似没有区别



            */

            var parent = new Dictionary<string, string>();
            var rank = new Dictionary<string, int>();
            var emailToName = new Dictionary<string, string>();

            // 初始化
            foreach (var account in accounts)
            {
                var name = account[0];
                for (int i = 1; i < account.Count; i++)
                {
                    var email = account[i];
                    if (!parent.ContainsKey(email))
                    {
                        parent[email] = email;
                    }
                    if (!rank.ContainsKey(email))
                    {
                        rank[email] = 0;
                    }
                    if (!emailToName.ContainsKey(email))
                    {
                        emailToName[email] = name;
                    }
                }
            }


            // 各组串联
            foreach (var account in accounts)
            {
                for (int i = 2; i < account.Count; i++)
                {
                    UnionEamil(parent, rank, account[1], account[i]);
                }
            }

            var result = new List<List<string>>();
            parent.GroupBy(e => FindEmail(parent, e.Key)).ToList().ForEach(item =>
            {
                var list = item.Select(e => e.Key).Distinct().OrderBy(e => e).ToList();
                var name = emailToName.FirstOrDefault(e => e.Key == list[0]).Value;
                list.Insert(0, name);
                result.Add(list);
            });

            return result;

        }

        // 路径压缩，他做的只是将所有的点联通，但并不是把parent直接指向root
        private string FindEmail(Dictionary<string, string> parent, string email)
        {
            if (parent[email] != email)
            {
                parent[email] = FindEmail(parent, parent[email]);
            }
            return parent[email];
        }

        private bool UnionEamil(Dictionary<string, string> parent, Dictionary<string, int> rank, string email1, string email2)
        {
            var rootEmail1 = FindEmail(parent, email1);
            var rootEmail2 = FindEmail(parent, email2);
            if (rootEmail1 == rootEmail2)
            {
                return false;
            }
            if (rank[rootEmail1] > rank[rootEmail2])
            {
                parent[rootEmail2] = rootEmail1;
            }
            else if (rank[rootEmail1] < rank[rootEmail2])
            {
                parent[rootEmail1] = rootEmail2;
            }
            else
            {
                parent[rootEmail1] = rootEmail2;
                rank[rootEmail2]++;
            }
            return true;
        }


    }
}
