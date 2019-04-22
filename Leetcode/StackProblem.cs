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
        public int LargestRectangleArea(int[] heights)
        {
            var low = 0;
            var result = 0;
            LargestRectangleArea(heights, 0, heights.Length - 1, ref result, ref low);
            return result;
        }

        private int LargestRectangleAreaStack(int[] heights)
        {
            return 0;
        }

        private void LargestRectangleArea(int[] heights, int start, int end, ref int result, ref int low)
        {
            if (start == end)
            {
                result = heights[start];
                low = heights[start];
            }
            else
            {
                var mid = (start + end) / 2;
                var lowleft = 0;
                var lowright = 0;
                var resultleft = 0;
                var resultright = 0;

                LargestRectangleArea(heights, start, mid, ref resultleft, ref lowleft);
                LargestRectangleArea(heights, mid + 1, end, ref resultright, ref lowright);

                var loweast = lowleft < lowright ? lowleft : lowright;
                var mergeresult = loweast * (end - start + 1);
                if (resultleft > resultright && resultleft > mergeresult)
                {
                    low = lowleft;
                    result = resultleft;
                }
                else if (resultright > resultleft && resultright > mergeresult)
                {
                    low = lowright;
                    result = resultright;
                }
                else
                {
                    low = loweast;
                    result = mergeresult;
                }
            }
        }

    }
}
