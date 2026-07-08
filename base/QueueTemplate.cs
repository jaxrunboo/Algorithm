namespace Algorithm
{
    public class QueueTemplate
    {
        public class ImplementQueueUsingStacks
        {

            /*
            题目：
            使用两个栈实现一个队列。
            队列的声明如下：
            class MyQueue {
                public void Push(int x);
                public int Pop();
                public int Peek();
                public bool IsEmpty();
                public int Size();
            }

            思路：
            两个栈，第一个就是完全倒序了，第二个就恢复到正序
            所以 push的时候只要在第一个栈push就可以
            pop 的时候，需要把当前栈的全部内容倒到第二个栈，然后pop 第二个栈
            peek 也是如此，先倒过去，但是只是取栈顶的数作为队列的开头
            (倒数的要求，第二个栈必须已经空了才可以，不然就影响顺序了)
            isEmpty 判断两个栈是否都为空
            size 两个栈的和
            */

            private Stack<int> stack1 = new Stack<int>();
            private Stack<int> stack2 = new Stack<int>();

            public void Push(int x)
            {
                stack1.Push(x);
            }

            public int Pop()
            {
                PourIfNeeded();
                if (stack2.Count == 0)
                {
                    throw new Exception("Queue is empty");
                }
                return stack2.Pop();
            }

            public int Peek()
            {
                PourIfNeeded();
                if (stack2.Count == 0)
                {
                    throw new Exception("Queue is empty");
                }
                return stack2.Peek();
            }

            public bool IsEmpty()
            {
                return stack1.Count == 0 && stack2.Count == 0;
            }

            public int Size()
            {
                return stack1.Count + stack2.Count;
            }

            private void PourIfNeeded()
            {
                if (stack2.Count == 0)
                {
                    while (stack1.Count > 0)
                    {
                        stack2.Push(stack1.Pop());
                    }
                }
            }

        }


        public class NumberOfRecentCalls
        {
            /*
            题目：
            写一个 RecentCounter 类来计算特定时间范围内最近的请求。
            请实现 RecentCounter 类：
            RecentCounter() 初始化计数器，请求数为 0 。
            int Ping(int t) 在时间 t 添加一个新请求，并返回过去 3000 毫秒内发生的所有请求数（包括新请求）。确切地说，返回在 [t-3000, t] 内发生的请求数。
            保证每次对 Ping 的调用都使用比之前更大的 t 值。

            思路：
            用队列按时间顺序存每次 Ping 的时间戳
            新请求入队后，从队头不断出队早于 t - 3000 的请求
            队列长度就是 [t-3000, t] 内的请求数
            */

            private Queue<int> queue = new Queue<int>();

            public int Ping(int t)
            {
                queue.Enqueue(t);
                while (queue.Peek() < t - 3000)
                {
                    queue.Dequeue();
                }
                return queue.Count;
            }
        }
    }
}