namespace Algorithm
{
    public class TreeTemplate
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public int height;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int DepthOfBinaryTree(TreeNode root)
        {
            /*
            题目：
            求root的最大深度
            思路：
            递归
            左子树的最大深度和右子树的最大深度的更大值+1，就是最大深度

            优先考虑退出机制 
            当root为null时，返回0
            */
            if (root is null) return 0;
            var leftDepth = DepthOfBinaryTree(root.left);
            var rightDepth = DepthOfBinaryTree(root.right);
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public bool SameTree(TreeNode p, TreeNode q)
        {
            /*
            题目：
            判断两个二叉树是否相同
            思路：
            递归
            左子树和右子树是否相同

            优先考虑退出机制
            当p和q都为null时，返回true
            当p和q其中一个为null时，返回false 
            当p和q的值不相同时，返回false
            */
            if (p is null && q is null) return true;
            if (p is null || q is null) return false;
            if (p.val != q.val) return false;

            var leftSame = SameTree(p.left, q.left);
            var rightSame = SameTree(p.right, q.right);
            return leftSame && rightSame;
        }


        public List<int> BinaryTreePreorderTraversal(TreeNode root)
        {
            /*
            题目：
            二叉树的前序遍历
            思路：
            递归
            先遍历根节点，然后遍历左子树，然后遍历右子树
            */

            var result = new List<int>();
            PreOrder(root, result);
            return result;
        }

        // 前序遍历 root -> left -> right
        private void PreOrder(TreeNode root, List<int> result)
        {
            if (root is null) return;
            result.Add(root.val);
            PreOrder(root.left, result);
            PreOrder(root.right, result);
        }

        // 中序遍历 left -> root -> right
        private void InOrder(TreeNode root, List<int> result)
        {
            if (root is null) return;
            InOrder(root.left, result);
            result.Add(root.val);
            InOrder(root.right, result);
        }

        // 后续遍历 left -> right -> root
        private void PostOrder(TreeNode root, List<int> result)
        {
            if (root is null) return;
            PostOrder(root.left, result);
            PostOrder(root.right, result);
            result.Add(root.val);
        }

        // BST 二叉搜索树 中序遍历是升序 因为他root左侧小于右侧
        // DFS 深度优先(前中后序都是DFS)

        public bool BalancedBinaryTree(TreeNode root)
        {
            /*
            题目：
            判断二叉树是否平衡
            思路：
            递归
            左子树和右子树是否平衡
            需要优先看左右子树高度才能得到结论，所以是后序遍历
            */
            return CheckHeight(root) != -1;
        }

        private int CheckHeight(TreeNode root)
        {
            if (root is null) return 0;
            var leftHeight = CheckHeight(root.left);
            if (leftHeight == -1) return -1;
            var rightHeight = CheckHeight(root.right);
            if (rightHeight == -1) return -1;
            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;
            return Math.Max(leftHeight, rightHeight) + 1;
        }



        public List<List<int>> BinaryTreeLevelOrderTraversal(TreeNode root)
        {
            /*
            题目：
            二叉树的层序遍历
            思路：
            广度优先遍历
            使用队列
            队列中存储节点和当前层的数量
            将节点的左右子节点存储到队列中
            返回列表
            */
            var result = new List<List<int>>();
            if (root is null) return new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelSize = queue.Count; // 他并不是用来表示当前循环的深度，而是用来表示本轮要执行的循环次数
                var level = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);

                    if (node.left is not null) queue.Enqueue(node.left);
                    if (node.right is not null) queue.Enqueue(node.right);
                }
                result.Add(level);
            }
            return result;
        }


        public bool PathSum(TreeNode root, int targetSum)
        {
            /*
            题目：
            路径总和
            是否存在一条从根节点到叶子节点的路径，使得路径上所有节点值的和等于目标值。
            或者是targetSum逐个层级减去当前节点的值，最后叶子节点的值时，剩余的值= 叶子节点的值，则返回true

            思路：
            我应该在递归的过程中，记录路径的值信息
            似乎前中后序都可以
            用层序似乎不太合适，可能需要节点有额外的字段记录

            */

            if (root is null) return false;
            if (root.left is null && root.right is null)
            {
                return targetSum == root.val;
            }

            var leftPathSum = PathSum(root.left, targetSum - root.val);
            var rightPathSum = PathSum(root.right, targetSum - root.val);
            return leftPathSum || rightPathSum;
        }

        public List<List<int>> PathSumII(TreeNode root, int targetSum)
        {
            /*
            题目：
            路径总和 II 返回所有满足条件的路径
            思路：
            还是递归，但是我这次需要在过程中记录路径信息
            需要有个List<int>的接口来存储一条路径信息
            最终满足条件的路径信息进行汇总

            */

            var result = new List<List<int>>();
            var path = new List<int>();
            IsPathSum(root, targetSum, path, result);
            return result;

        }

        private void IsPathSum(TreeNode root, int targetSum, List<int> path, List<List<int>> result)
        {
            if (root is null) return;
            path.Add(root.val);

            if (root.left is null && root.right is null)
            {
                if (targetSum == root.val)
                {
                    result.Add(new List<int>(path));
                }
            }
            else
            {
                IsPathSum(root.left, targetSum - root.val, path, result);
                IsPathSum(root.right, targetSum - root.val, path, result);
            }

            path.RemoveAt(index: path.Count - 1);
        }

        public TreeNode SearchInABinarySearchTree(TreeNode root, int target)
        {
            /*
            题目：
            在二叉搜索树中搜索一个值
            思路：
            递归，和二分查找一样，每次都判断当前节点值和目标值的大小关系，然后递归搜索左子树或右子树
            如果当前节点值等于目标值，则返回当前节点
            如果当前节点值大于目标值，则递归搜索左子树
            如果当前节点值小于目标值，则递归搜索右子树
            */
            if (root is null) return root;
            if (root.val == target) return root;

            if (root.val > target) return SearchInABinarySearchTree(root.left, target);
            else return SearchInABinarySearchTree(root.right, target);
        }

        public bool ValidateBinarySearchTree(TreeNode root)
        {
            /*
            题目：
            验证二叉搜索树
            思路：
            直接采用中序遍历，只要他比上一个值大就可以
            */
            last = null;

            return InOrderV1(root);

        }

        long? last = null;
        private bool InOrderV1(TreeNode root)
        {
            if (root is null) return true;

            if (!InOrderV1(root.left)) return false;

            if (last is not null && root.val <= last) return false;

            last = root.val;

            return InOrderV1(root.right);
        }

        public bool SymmetricTree(TreeNode root)
        {
            /*
            题目：
            判断二叉树是否对称
            思路：
            递归，判断左子树和右子树是否对称
            */
            if (root is null) return true;
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            if (left.val != right.val) return false;

            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }

        public TreeNode InvertBinaryTree(TreeNode root)
        {
            /*
            题目：
            翻转二叉树
            思路：
            递归，翻转左子树和右子树
            我觉得这是个前序遍历
            */
            Invert(root);
            return root;
        }

        private void Invert(TreeNode root)
        {
            if (root is null) return;
            if (root.left is null && root.right is null) return;

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            Invert(root.left);
            Invert(root.right);
        }


        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            /*
            题目：
            二叉树的最近公共祖先
            思路：
            递归，判断左子树和右子树是否包含p和q

            递归的方法，返回值应该是左右节点中存在p或者q的节点
            只有当两者都满足的时候，返回，就是最小的(用后序)
            如果只有一个满足，说明只是某一个节点的父级，还是返回p或者q，这只是一个标识

            */

            if (root is null || root == p || root == q) return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left is not null && right is not null) return root;
            return left ?? right;
        }

        /*
        树题型的统一实现思路：
        1. 每个节点要回答什么问题
        2. 能否通过左右子树的返回值，得到答案
        3. 返回值: 子树需要向上传递什么信息
        4. 边界情况
        5. root上如何组合左右节点
        */

        public TreeNode LowestCommonAncestorOfABinarySearchTree(TreeNode root, TreeNode p, TreeNode q)
        {
            /*
            题目：
            二叉搜索树的最近公共祖先
            思路：
            递归，判断左子树和右子树是否包含p和q

            因为bst是有序的，是不是可以从这里做文章
            当然，不管是不是bst仍可以通过上个题目的思路实现
            那说明bst可以通过更少的递归来得到结论？
            上一个用的是引用，这次似乎可以直接用值来判断

            似乎还有一个规则，如果是最小公共节点，节点的值一定在pq之间。这个规则似乎可以帮助我减少递归

            现有的实现方式是错误的，bst一定要想好是有序的，是否可以用中序的思路呢？
            节点实现的目的是找到LCA
            但是我似乎根本不需要返回值，用当前值就可以判断

            所以最终思路应该是：
            如果root的值在pq之间，则返回root，就已经可以准确定位LCA了
            如果root的值大于p和q，则递归左子树
            如果root的值小于p和q，则递归右子树

            */
            if (root is null || root.val == p.val || root.val == q.val) return root;

            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestorOfABinarySearchTree(root.left, p, q);
            }
            if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestorOfABinarySearchTree(root.right, p, q);
            }
            return root;
        }

        /*
        BST 题型统一推理（详见 canvases/bst-problem-guide.canvas.tsx）

        核心：左 < 根 < 右 → 每一步能否排除一半？

        | 题目              | 有序性用法                     | 走几边   | 模板           |
        |-------------------|--------------------------------|----------|----------------|
        | Search (700)      | 根 vs target：大左小右         | 只一边   | 单向查找       |
        | Validate (98)     | 中序升序 / (min,max) 区间      | 必须两边 | 中序或上下界   |
        | LCA BST (235)     | 都比根小→左；都比根大→右       | 只一边   | Search 双目标版|
        | LCA 普通 (236)    | 无有序性                       | 两边都要 | 后序信息上传   |

        选题三问：
        1. 是 BST 吗？
        2. 当前节点能否 O(1) 判断答案在左还是右？
        3. 能 → 单向搜索；不能 → 后序分治

        易错：LCA 235 的「LCA 在 pq 之间」= 分岔处停，不是区间外 return null
        */

        private int MaxDiameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            /*
            题目：
            二叉树的直径
            思路：
            递归，计算左子树和右子树的深度，然后返回左子树和右子树的深度之和

            直径是经过根节点的最大路径长度
            所以需要计算每个节点的直径，然后返回最大的直径

            直径的计算方式是：
            左子树的深度 + 右子树的深度
            所以需要计算每个节点的深度
            */
            GetDepth(root);
            return MaxDiameter;
        }

        // 这里要返回的是树的深度，而不是直径，所以直径需要一个额外的值来记录
        // 这里实际上是不确定哪两个节点最长的，所以是要把每个节点的深度都计算一遍，然后取最大值
        // 逻辑上认为这两件事是等价的 
        private int GetDepth(TreeNode root)
        {
            if (root is null) return 0;
            var leftDepth = GetDepth(root.left);
            var rightDepth = GetDepth(root.right);

            MaxDiameter = Math.Max(MaxDiameter, leftDepth + rightDepth);
            return Math.Max(leftDepth, rightDepth) + 1;
        }


        public int BinaryTreeMaximumPathSum(TreeNode root)
        {
            /*
            题目：
            二叉树的最大路径和
            路径和是路径上所有节点值的和

            思路：
            递归，计算左子树和右子树的和，然后返回左子树和右子树的和之和
            也是DFS的后序
            需要一个额外的值来记录最大路径和

            每个节点要返回左右子树的两者的最大路径和和当前节点值的和，也就是当前节点下的最大路径和，并且要更新最大路径和
            可是，如果我只要当前节点的最大路径和，我最终root节点拿到的不就是最大路径和吗，为什么还要一个额外字段呢，除非这两个并不是一个含义
            或者说，跟上一题目类似。最大路径和可能是不过root的，因为可能存在负数节点

            */

            MaxPathSum = int.MinValue;
            GetMaxPathSum(root);
            return MaxPathSum;
        }

        private int MaxPathSum = int.MinValue;
        private int GetMaxPathSum(TreeNode root)
        {
            if (root is null) return 0;
            var leftMaxPathSum = GetMaxPathSum(root.left);
            var rightMaxPathSum = GetMaxPathSum(root.right);

            if (leftMaxPathSum < 0) leftMaxPathSum = 0;
            if (rightMaxPathSum < 0) rightMaxPathSum = 0;

            // 返回给上层的是，是左右节点的最长路径，目的是给节点做后续判断使用的，如果是包含拐点的最长路径，上层节点无法使用
            var currentMaxPath = root.val + Math.Max(leftMaxPathSum, rightMaxPathSum);
            var maxPathSumThroughRoot = root.val + leftMaxPathSum + rightMaxPathSum; // 在当前节点拐弯的最大路径
            MaxPathSum = Math.Max(MaxPathSum, maxPathSumThroughRoot);
            return currentMaxPath;
        }

        public TreeNode ConstructBinaryTreeFromPreorderAndInorderTraversal(int[] preorder, int[] inorder)
        {
            /*
            题目：
            从前序与中序遍历序列构造二叉树
            思路：

            前序的第一个节点是root
            中序的root左侧是左子树，右侧是右子树
            想办法递归下去
            但是这个题目看起来需要要求树的值是不同的，不然看起来无法命中
            */

            var inDict = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                inDict.Add(inorder[i], i);
            }

            return Construct(preorder, 0, preorder.Length - 1, inDict, inorder, 0, inorder.Length - 1);


        }

        private TreeNode Construct(int[] preorder, int preStart, int preEnd,
         Dictionary<int, int> inDict, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd) return null;
            if (inStart > inEnd) return null;

            var root = preorder[preStart];
            var inIndex = inDict[root];

            var treeNode = new TreeNode(root);
            treeNode.left = Construct(preorder, preStart + 1, preStart + inIndex - inStart, inDict, inorder, inStart, inIndex - 1);
            treeNode.right = Construct(preorder, preStart + inIndex - inStart + 1, preEnd, inDict, inorder, inIndex + 1, inEnd);
            return treeNode;
        }


        public TreeNode ConstructBinaryTreeFromInorderAndPostorderTraversal(int[] inorder, int[] postorder)
        {
            /*
            题目：
            从中序与后序遍历序列构造二叉树
            思路：
            后序的最后一个节点是root
            结合中序组成字典来进行递归处理
            */
            var inDict = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                inDict.Add(inorder[i], i);
            }

            return ConstructPost(inDict, 0, inDict.Count - 1, postorder, 0, postorder.Length - 1);
        }

        private TreeNode ConstructPost(Dictionary<int, int> inDict, int inStart, int inEnd,
         int[] postorder, int postStart, int postEnd)
        {
            if (postStart > postEnd) return null;
            if (inStart > inEnd) return null;

            var root = postorder[postEnd];
            var inIndex = inDict[root];

            var treeNode = new TreeNode(root);
            treeNode.left = ConstructPost(inDict, inStart, inIndex - 1, postorder, postStart, postStart + inIndex - inStart - 1);
            treeNode.right = ConstructPost(inDict, inIndex + 1, inEnd, postorder, postStart + inIndex - inStart, postEnd - 1);
            return treeNode;
        }

        public string SerializeBinaryTree(TreeNode node)
        {
            /*
            思路：
            要求对Null的内容有记录，这样才能知道谁是叶子节点

            前序递归，每次返回补充的path
            */

            var list = new List<string>();
            SerializePreOrderNode(node, list);
            return string.Join(",", list);

        }

        private void SerializePreOrderNode(TreeNode node, List<string> path)
        {
            if (node is null)
            {
                path.Add("#");
                return;
            }

            path.Add(node.val.ToString());

            SerializePreOrderNode(node.left, path);
            SerializePreOrderNode(node.right, path);
        }

        public TreeNode DeserializeBinaryTree(string path)
        {
            /*
            思路:
            用，拆分，接下来获得的就是前序数组
            第一个值是根节点，后面的#是前一个节点的子节点，第一个是左，第二个是右
            */
            var queue = new QueueTemplate<string>(path.Split(','));
            return DeserializeBT(queue);
        }

        public TreeNode DeserializeBT(Queue<string> queue)
        {
            var val = queue.Dequeue();
            if (val == "#")
            {
                return null;
            }

            var newNode = new TreeNode(int.Parse(val));

            newNode.left = DeserializeBT(queue);
            newNode.right = DeserializeBT(queue);
            return newNode;

        }

    }
}