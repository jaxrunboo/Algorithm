using static Algorithm.TreeTemplate;

public class TreePractice
{
    public TreeNode LowestCommonAncestorOfBinaryTree(TreeNode root, TreeNode p, TreeNode q)
    {
        /*
        思路：
        最小公共祖先
        递归解决，node方法的返回值就是p 或者 q 或者已经找到的lca 和 null,意思是当前节点是某个节点的祖先
        如果左右子树都包含，这就是最小公共祖先
        */

        if (root == null || root == p || root == q)
        {
            return root;
        }

        //
        var left = LowestCommonAncestorOfBinaryTree(root.left, p, q);
        var right = LowestCommonAncestorOfBinaryTree(root.right, p, q);
        if (left != null && right != null)
        {
            return root;
        }
        return left ?? right;
    }

    private int maxSum = int.MinValue;
    public int BinaryTreeMaximumPathSum(TreeNode root)
    {
        /*
        题目要求：
        给定一个非空二叉树，返回其最大路径和。

        思路：
        有一个全局变量记录最大路径和
        递归节点返回的是包含左右子树的单边最大贡献
        */
        maxSum = int.MinValue;
        GetNodePath(root);
        return maxSum;
    }

    private int GetNodePath(TreeNode node)
    {
        if (node is null) return 0;

        var left = Math.Max(0, GetNodePath(node.left));
        var right = Math.Max(0, GetNodePath(node.right));

        maxSum = Math.Max(maxSum, left + right + node.val);
        return Math.Max(left, right) + node.val;
    }
}

