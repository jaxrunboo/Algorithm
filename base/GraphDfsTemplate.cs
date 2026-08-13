namespace Algorithm
{
    public class GraphDfsTemplate
    {

        public int[] dx = new int[] { 1, -1, 0, 0 };
        public int[] dy = new int[] { 0, 0, 1, -1 };

        public int NumberOfIslands(char[][] grid)
        {
            /*
            题目内容：
            给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。
            岛屿总是被水包围，并且每座岛屿只能由水平方向和/或竖直方向上相邻的陆地连接形成。
            此外，你可以假设该网格的四条边均被水包围。
            
            示例 1：
            输入：grid = [
                ["1","1","1","1","0"],
                ["1","1","0","1","0"],
                ["1","1","0","0","0"],
                ["0","0","0","0","0"]
            ]
            输出：1
            示例 2：
            输入：grid = [
                ["1","1","0","0","0"],
                ["1","1","0","0","0"],
                ["0","0","1","0","0"],
                ["0","0","0","1","1"]
            ]
            输出：3
            
            思路：
            使用深度优先搜索（DFS）来解决这个问题。我们可以遍历整个网格，当遇到一个陆地时，
            我们就以该陆地为起点，进行深度优先搜索，将所有相邻的陆地都标记为已访问，
            这样我们就完成了一个岛屿的搜索。然后我们继续遍历网格，如果遇到一个未访问的陆地，
            我们就以该陆地为起点，进行深度优先搜索，这样我们就完成了一个岛屿的搜索。
            最后我们返回岛屿的数量。
            */

            var result = 0;
            var visited = new bool[grid.Length, grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        result++;
                        DFS(grid, visited, i, j);
                    }
                }
            }
            return result;
        }

        private void DFS(char[][] grid, bool[,] visited, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0' || visited[i, j])
            {
                return;
            }
            visited[i, j] = true;
            for (int k = 0; k < 4; k++)
            {
                DFS(grid, visited, i + dx[k], j + dy[k]);
            }
        }


        public int MaxAreaOfIsland(int[][] grid)
        {
            /*
            题目内容：
            给你一个大小为 m x n 的二进制矩阵 grid 。
            岛屿 是由一些相邻的 1 (代表土地) 构成的组合，这里的「相邻」要求两个 1 必须在水平或者竖直的四个方向之一接壤。
            你可以假设 grid 的四个边缘都被 0（代表水）包围着。
            岛屿的面积是岛上值为 1 的单元格的数目。
            计算并返回 grid 中最大的岛屿面积。如果没有岛屿，则返回面积为 0 。

            示例 1：
            输入：grid = [
                [0,0,1,0,0,0,0,1,0,0,0,0,0],
                [0,0,0,0,0,0,0,1,1,1,0,0,0],
                [0,1,1,0,1,0,0,0,0,0,0,0,0],
                [0,1,0,0,1,1,0,0,1,0,1,0,0],
                [0,1,0,0,1,1,0,0,1,1,1,0,0],
                [0,0,0,0,0,0,0,0,0,0,1,0,0],
                [0,0,0,0,0,0,0,1,1,1,0,0,0],
                [0,0,0,0,0,0,0,1,1,0,0,0,0]
            ]
            输出：6
            解释：答案不应该是 11 ，因为岛屿只能包含水平或垂直这四个方向的 1 。
            示例 2：
            输入：grid = [[0,0,0,0,0,0,0,0]]
            输出：0

            思路：
            dfs搜索图，遇到一个陆地，记录面积，跟最大值比较
            */

            var result = 0;
            var visited = new bool[grid.Length, grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1 && !visited[i, j])
                    {
                        result = Math.Max(result, MaxAreaOfIslandDFS(grid, visited, i, j));
                    }
                }
            }
            return result;
        }

        private int MaxAreaOfIslandDFS(int[][] grid, bool[,] visited, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0 || visited[i, j])
            {
                return 0;
            }
            visited[i, j] = true;
            var result = 1;
            for (int k = 0; k < 4; k++)
            {
                result += MaxAreaOfIslandDFS(grid, visited, i + dx[k], j + dy[k]);
            }
            return result;
        }


        // 如果要优化空间复杂度可以在grid中存储信息，把visited去掉，这种一定程度上优化空间，但是如果一个人
        // 真这么做，我就一定会认为这个人没有工程思维



        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            /*
            题目内容：
            给定一个图像，按照题目要求，进行flood fill操作
            flood fill：从图像的某个起始像素开始，将其和它周围所有相同颜色的像素都填充成新的颜色。
            
            示例 1：
            输入：image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
            输出：[[2,2,2],[2,2,0],[2,0,1]]
            解释：
            从位置 (1, 1) 开始，将所有和位置 (1, 1) 颜色相同的像素填充成颜色 2。
            注意，右下角的像素没有被填充，因为它不属于初始颜色区域。

            思路：
            这个明显只是需要遍历即可，所以可以使用DFS，关键点就是visted记录已经访问的内容

            循环中递归四个方向的节点 ，把已访问的节点记录
            */
            var originColor = image[sr][sc];
            if (originColor == color)
            {
                return image;
            }

            FloodFillDFS(image, sr, sc, color, originColor);


            return image;
        }

        private void FloodFillDFS(int[][] image, int i, int j, int color, int originColor)
        {
            if (i < 0 || i >= image.Length || j < 0 || j >= image[0].Length
            || image[i][j] == color || image[i][j] != originColor)
            {
                return;
            }
            image[i][j] = color;
            for (int k = 0; k < 4; k++)
            {
                FloodFillDFS(image, i + dx[k], j + dy[k], color, originColor);
            }
        }


        public void SurroundedRegions(char[][] board)
        {
            /*
            题目内容：
            给定一个二维网格，其中包含 'X' 和 'O'，你需要将所有被 'X' 包围的 'O' 都填充为 'X'。
            
            示例 1：
            输入：board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
            输出：[["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
            解释：
            被 'X' 包围的 'O' 都填充为 'X'。
            示例 2：
            输入：board = [["X"]]
            输出：[["X"]]
            
            思路：
            这个明显只是需要遍历即可，所以可以使用DFS，关键点就是visted记录已经访问的内容

            可以是多个数据源(边缘的O)开始去递归
            如果某个子节点的四边任何一边，有O，就是为他是通的，可以继续递归，直到所有四边的未访问的内容都是封闭的

            */

            var visited = new bool[board.Length, board[0].Length];

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][0] == 'O' && !visited[i, 0])
                {
                    SurroundedRegionsDFS(board, visited, i, 0);
                }
                if (board[i][board[0].Length - 1] == 'O' && !visited[i, board[0].Length - 1])
                {
                    SurroundedRegionsDFS(board, visited, i, board[0].Length - 1);
                }
            }

            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[0][j] == 'O' && !visited[0, j])
                {
                    SurroundedRegionsDFS(board, visited, 0, j);
                }
                if (board[board.Length - 1][j] == 'O' && !visited[board.Length - 1, j])
                {
                    SurroundedRegionsDFS(board, visited, board.Length - 1, j);
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O' && !visited[i, j])
                    {
                        board[i][j] = 'X';
                    }
                }
            }

        }

        private void SurroundedRegionsDFS(char[][] board, bool[,] visited, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] == 'X' || visited[i, j])
            {
                return;
            }
            visited[i, j] = true;
            for (int k = 0; k < 4; k++)
            {
                SurroundedRegionsDFS(board, visited, i + dx[k], j + dy[k]);
            }
        }

    }
}