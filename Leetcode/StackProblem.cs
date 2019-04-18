using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class StackProblem
    {
        /*
         * https://leetcode.com/problems/valid-parentheses/
         */
        public bool ValidParentheses(string s)
        {
            var stack = new Stack<char>();
            var hastTable = new Dictionary<char, char>()
            {
                {'(', ')' },
                {'[', ']' },
                {'{', '}' }
            };

            for (var i = 0; i < s.Length; i++)
            {
                if (stack.Count() == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (!hastTable.ContainsKey(stack.Peek()))
                    {
                        return false;
                    }
                    else
                    {
                        if (hastTable[stack.Peek()] == s[i])
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(s[i]);
                        }
                    }
                }
            }

            if (stack.Count() > 0) return false;

            return true;
        }

        /*
         * https://leetcode.com/problems/simplify-path/
         */
        public string SimplifyPath(string path)
        {
            var stack = new Stack<string>();

            var array = path.Split('/');
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == "..")
                {
                    if (stack.Count() == 0)
                    {
                        continue;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else if (array[i] == ".")
                {
                    continue;
                }
                else if (string.IsNullOrEmpty(array[i]))
                {
                    continue;
                }
                else
                {
                    stack.Push(array[i]);
                }
            }

            var result = string.Empty;
            while (stack.Count() != 0)
            {
                result = "/" + stack.Pop() + result;
            }

            if (string.IsNullOrEmpty(result)) result = "/";

            return result;
        }

        /*
         * https://leetcode.com/problems/largest-rectangle-in-histogram/
         */
        public int LargestRectangleArea()
        {
            return 0;
        }
    }
}
