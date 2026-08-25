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
                rank[rootX]++;
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


    }
}
