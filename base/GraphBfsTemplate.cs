namespace Algorithm
{
    public class GraphBfsTemplate
    {
        private int[] dx = new int[] { 1, -1, 0, 0 };
        private int[] dy = new int[] { 0, 0, 1, -1 };


        public int RottingOranges(int[][] grid)
        {
            /*
            题目内容：
            给你一个大小为 m x n 的二进制矩阵 
            grid ，其中 0 表示一个空单元格、1 表示一个新鲜橘子、2 表示一个腐烂的橘子。
            每分钟，腐烂的橘子 周围 4 个方向上相邻 的新鲜橘子都会腐烂。
            返回 直到单元格中没有新鲜橘子为止所必须经过的最小分钟数。如果不可能，返回 -1 。

            示例 1：
            输入：grid = [
            [2,1,1],
            [1,1,0],
            [0,1,1]]
            输出：4

            示例 2：
            输入：grid = [
            [2,1,1],
            [0,1,1],
            [1,0,1]]
            输出：-1

            示例 3：
            输入：grid = [[0,2]]
            输出：0

           思路：
           使用广度优先搜索（BFS）来解决这个问题。我们可以从所有腐烂的橘子开始，
           每分钟，腐烂的橘子 周围 4 个方向上相邻 的新鲜橘子都会腐烂。
           我们使用一个队列来存储腐烂的橘子，每次从队列中取出一个橘子，
           然后将其周围 4 个方向上相邻的新鲜橘子都腐烂。
           最后我们返回腐烂的橘子数量。


            */

            var result = 0;
            var queue = new Queue<int>();
            var freshCount = 0;

            var visited = new bool[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(i * grid[0].Length + j);
                        visited[i, j] = true;
                    }
                    if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }
            while (queue.Count > 0)
            {
                var size = queue.Count;
                var isRotten = false;
                for (int i = 0; i < size; i++)
                {
                    var index = queue.Dequeue();
                    var x = index / grid[0].Length;// 行
                    var y = index % grid[0].Length; // 列
                    if (x > 0 && grid[x - 1][y] == 1)
                    {
                        grid[x - 1][y] = 2;
                        freshCount--;
                        // 这不死循环了吗
                        // 是的，所以需要一个visited数组来记录已经访问过的橘子
                        queue.Enqueue((x - 1) * grid[0].Length + y);
                        isRotten = true;
                    }
                    if (x < grid.Length - 1 && grid[x + 1][y] == 1)
                    {
                        grid[x + 1][y] = 2;
                        freshCount--;
                        queue.Enqueue((x + 1) * grid[0].Length + y);
                        isRotten = true;
                    }
                    if (y > 0 && grid[x][y - 1] == 1)
                    {
                        grid[x][y - 1] = 2;
                        freshCount--;
                        queue.Enqueue(x * grid[0].Length + y - 1);
                        isRotten = true;
                    }
                    if (y < grid[0].Length - 1 && grid[x][y + 1] == 1)
                    {
                        grid[x][y + 1] = 2;
                        freshCount--;
                        queue.Enqueue(x * grid[0].Length + y + 1);
                        isRotten = true;
                    }
                }
                if (isRotten)
                {
                    result++;
                }
            }

            if (freshCount > 0)
            {
                return -1;
            }
            return result;
        }


        public int[][] Matrix01(int[][] matrix)
        {
            /*
            题目内容：
            给定一个由 0 和 1 组成的矩阵，找出每个元素到最近的 0 的距离。
            两个相邻元素间的距离为 1 。

            示例 1：
            输入：matrix = [[0,0,0],[0,1,0],[0,0,0]]
            输出：[[0,0,0],[0,1,0],[0,0,0]]

            思路：
            BFS，先把0入队，这样可以预先把0 周围的所有1先处理掉
            这样后续再处理的时候，就可以依赖 周围1的值去累加，得到和0的最小距离

            */

            var dist = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                dist[i] = new int[matrix[0].Length];
            }

            var queue = new Queue<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.Enqueue(i * matrix[0].Length + j);
                    }
                    else
                    {
                        dist[i][j] = -1;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var index = queue.Dequeue();
                    var x = index / matrix[0].Length;
                    var y = index % matrix[0].Length;
                    for (int j = 0; j < 4; j++)
                    {
                        var newX = x + dx[j];
                        var newY = y + dy[j];

                        if (newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length) continue;

                        if (dist[newX][newY] != -1) continue;

                        dist[newX][newY] = dist[x][y] + 1;
                        queue.Enqueue(newX * matrix[0].Length + newY);
                    }
                }
            }

            return dist;
        }
    }
}