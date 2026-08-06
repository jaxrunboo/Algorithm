namespace Algorithm
{
    public class GraphBfsTemplate
    {
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
                        visited[x - 1, y] = true;
                        isRotten = true;
                    }
                    if (x < grid.Length - 1 && grid[x + 1][y] == 1)
                    {
                        grid[x + 1][y] = 2;
                        freshCount--;
                        queue.Enqueue((x + 1) * grid[0].Length + y);
                        visited[x + 1, y] = true;
                        isRotten = true;
                    }
                    if (y > 0 && grid[x][y - 1] == 1)
                    {
                        grid[x][y - 1] = 2;
                        freshCount--;
                        queue.Enqueue(x * grid[0].Length + y - 1);
                        visited[x, y - 1] = true;
                        isRotten = true;
                    }
                    if (y < grid[0].Length - 1 && grid[x][y + 1] == 1)
                    {
                        grid[x][y + 1] = 2;
                        freshCount--;
                        queue.Enqueue(x * grid[0].Length + y + 1);
                        visited[x, y + 1] = true;
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
    }
}