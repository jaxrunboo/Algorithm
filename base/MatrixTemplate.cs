namespace Algorithm
{
    public class MatrixTemplate
    {

        public int MatrixDiagonalSum(int[,] matrix)
        {

            /*
            题目内容：
            计算矩阵对角线元素的和，包括主对角线和副对角线。
            主对角线：从矩阵的左上角到右下角的元素。
            副对角线：从矩阵的右上角到左下角的元素。
            元素总和：主对角线元素和副对角线元素的和。
            如果中心元素重复，只计算一次

            思路：
            1. 遍历矩阵，计算主对角线元素和副对角线元素的和。
            2. 如果中心元素重复，只计算一次。
            3. 返回元素总和。

            对角线的选择：
            1. 主对角线： col = row
            2. 副对角线： col + row = n - 1
            row = n - 1 - col
            
            */

            int n = matrix.GetLength(0);
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
                if (i != n - 1 - i)
                {
                    sum += matrix[i, n - 1 - i];
                }
            }
            return sum;
        }

        public int RangeSumQuery2D(int[,] matrix, int row1, int col1, int row2, int col2)
        {
            /*
            题目内容：
            给定一个二维矩阵，实现一个数据结构，支持快速查询矩阵中任意矩形区域的和。
            输入：matrix = 
            [[3,0,1,4,2],
            [5,6,3,2,1],
            [1,2,0,1,5],
            [4,1,0,1,7],
            [1,0,3,0,5]]

            row1 = 2, col1 = 1, row2 = 4, col2 = 3
            output = 8

            思路：
            1. 计算矩阵的和。
            2. 计算矩形区域的和。
            3. 返回矩形区域的和。

            sum = matrix[row2, col2] - matrix[row1, col2] - matrix[row2, col1] + matrix[row1, col1];
            二维的前缀和要怎么计算呢？
            好像还是个不规则的矩阵

            前缀和求法：
            preFix[i][j] = matrix[i][j] + preFix[i-1][j] + preFix[i][j-1] - preFix[i-1][j-1];
            我一直往下递归
            最后可能就是:
            i或者j<0。认为他的值是0，一直到两者都<=0 才结束递归
            这样就相当于一个个栈内求值，最终把值重新计算

            然后，任意矩形 的和，计算方式：
            sum[row1,col1 row2,col2] = preFix[row2,col2] - preFix[row1-1,col2] - preFix[row2,col1-1] + preFix[row1-1,col1-1];

            */

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[,] preFix = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    preFix[i, j] = preFix[i - 1, j] + preFix[i, j - 1] - preFix[i - 1, j - 1] + matrix[i - 1, j - 1];
                }
            }

            var res = preFix[row2 + 1, col2 + 1] - preFix[row1, col2 + 1] - preFix[row2 + 1, col1] + preFix[row1, col1];
            return res;
        }

        // 用来理解，递归性能很差
        private int GetPreFixSum(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return 0;
            }

            var res = GetPreFixSum(matrix, row - 1, col) + GetPreFixSum(matrix, row, col - 1) - GetPreFixSum(matrix, row - 1, col - 1) + matrix[row, col];
            return res;
        }
    }
}
