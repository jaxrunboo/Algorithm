namespace Algorithm
{
    public class TopologicalSortTemplate
    {
        public bool CourseSchedule(int numCourses, int[][] prerequisites)
        {
            /*
            题目内容：
            你这个学期必须选修 numCourses 门课程，记为 0 到 numCourses - 1 。
            
            示例 1：
            输入：numCourses = 2, prerequisites = [[1,0]]
            输出：true
            解释：总共有 2 门课程。要学习课程 1，你需要先完成课程 0。因此，这是可能的。
            示例 2：
            输入：numCourses = 2, prerequisites = [[1,0],[0,1]]
            输出：false
            解释：总共有 2 门课程。要学习课程 1，你需要先完成课程 0；
            同时，你也需要完成课程 0，才能学习课程 1。因此，这是不可能的。
            
            思路：
            这个题目是典型的拓扑排序题目，我们可以使用拓扑排序来解决这个问题。
            拓扑排序的原理是：如果一个课程有先修课程，那么这个课程的先修课程必须在当前课程之前完成。
            因此，我们可以使用拓扑排序来解决这个问题。
            
            具体步骤如下：
            1. 创建一个邻接表来表示课程之间的依赖关系。
            2. 创建一个入度数组来表示每个课程的入度。
            3. 创建一个队列来存储入度为0的课程。
            4. 当队列不为空时，取出队列中的课程，将其加入到拓扑排序中，并将其邻接的课程的入度减1。
            */

            var adjacencyList = new List<int>[numCourses];
            var inDegree = new int[numCourses];
            var queue = new Queue<int>();
            var result = new List<int>();

            for (int i = 0; i < numCourses; i++)
            {
                adjacencyList[i] = new List<int>();
            }

            // 构建邻接表和入度数组
            foreach (var prerequisite in prerequisites)
            {
                adjacencyList[prerequisite[1]].Add(prerequisite[0]);
                inDegree[prerequisite[0]]++;
            }

            // 将入度为0的课程加入队列
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                adjacencyList[current].ForEach(neighbor =>
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                });
                result.Add(current);
            }

            return result.Count == numCourses;
        }
    
        public int[] CourseScheduleII(int numCourses, int[][] prerequisites)
        {
            /*
            题目内容：
            你这个学期必须选修 numCourses 门课程，记为 0 到 numCourses - 1 。
            
            示例 1：
            输入：numCourses = 2, prerequisites = [[1,0]]
            输出：[0,1]
            解释：总共有 2 门课程。要学习课程 1，你需要先完成课程 0。因此，正确的课程顺序是 [0,1] 。
            示例 2：
            输入：numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
            输出：[0,1,2,3]
            解释：总共有 4 门课程。要学习课程 3，你需要先完成课程 1 和 2。因此，正确的课程顺序是 [0,1,2,3] 。
            
            思路：
            这个题目是典型的拓扑排序题目，我们可以使用拓扑排序来解决这个问题。
            拓扑排序的原理是：如果一个课程有先修课程，那么这个课程的先修课程必须在当前课程之前完成。
            因此，我们可以使用拓扑排序来解决这个问题。
            
            具体步骤如下：
            1. 创建一个邻接表来表示课程之间的依赖关系。
            2. 创建一个入度数组来表示每个课程的入度。
            3. 创建一个队列来存储入度为0的课程。
            4. 当队列不为空时，取出队列中的课程，将其加入到拓扑排序中，并将其邻接的课程的入度减1。

            可是现在要求把学习顺序记录下来
            我一开始队列中是多源的课
            我怎么才能记录下来学习顺序
            还是说，我知道了他是DAG后，DFS去取值吗？
            我需要一个结果数组来记录学习顺序
            

            */
        }
    }
}