namespace Algorithm
{
    public class StackTemplate
    {
        public bool ValidParentheses(string s)
        {
            /*
            题目：
            给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。
            有效字符串需满足：
            左括号必须用相同类型的右括号闭合。
            左括号必须以正确的顺序闭合。
            每个右括号都有一个对应的相同类型的左括号。

            思路：
            明显是使用栈来解决的问题
            但是我应该怎么写呢？

            感觉可以是左侧就是入栈，右侧出栈，而且要求出入栈的内容是配对的
            */

            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var res = stack.Pop();
                    if (c == ')' && res != '(')
                    {
                        return false;
                    }
                    else if (c == '}' && res != '{')
                    {
                        return false;
                    }
                    else if (c == ']' && res != '[')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }


        public bool BackspaceStringCompare(string s, string t)
        {
            /*
            题目：
            给定 s 和 t 两个字符串，当它们分别被输入到空白的文本编辑器后，如果两者相等，返回 true 。# 代表退格字符。
            注意：如果对空文本输入退格字符，文本继续为空。

            思路:
            用栈很容易做到数据写入
            但是我怎么比对数据呢，难道要写入重新判断吗
            好像可以直接在写入的时候，判断入值，但是出栈如何判断相同呢？
            这也有点脱了裤子放屁的意思啊，我直接挨个比较不就行了吗？
            也不是，要最后的行为相同。所以我好像还是需要入栈都结束后，出栈来判断
            */

            Stack<char> stack1 = new Stack<char>();
            Stack<char> stack2 = new Stack<char>();

            foreach (char c in s)
            {
                if (c != '#')
                {
                    stack1.Push(c);
                }
                else
                {
                    if (stack1.Count > 0)
                    {
                        stack1.Pop();
                    }
                }
            }

            foreach (char c in t)
            {
                if (c != '#')
                {
                    stack2.Push(c);
                }
                else
                {
                    if (stack2.Count > 0)
                    {
                        stack2.Pop();
                    }
                }
            }

            if (stack1.Count != stack2.Count)
            {
                return false;
            }

            while (stack1.Count > 0)
            {
                if (stack1.Pop() != stack2.Pop())
                {
                    return false;
                }
            }


            return true;

        }
    }
}