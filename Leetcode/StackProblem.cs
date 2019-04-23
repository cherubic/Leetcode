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
        public int LargestRectangleAreaStack(int[] heights)
        {
            var maxArea = 0;
            var stack = new Stack<int>();

            for (var i = 0; i < heights.Length; i++)
            {
                if (stack.Count() == 0 || heights[i] >= heights[stack.Peek()])
                {
                    stack.Push(i);
                }
                else
                {
                    var top = stack.Pop();
                    maxArea = Math.Max(maxArea, (heights[top] * (stack.Count() == 0 ? i : i - 1 - stack.Peek())));
                    i--;
                }
            }

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                maxArea = Math.Max(maxArea, (heights[top] * (stack.Count() == 0 ? heights.Length - 1 : heights.Length - 1 - 1 - stack.Peek())));
            }

            return maxArea;
        }

        //TODO: Dynamic Programming
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

        /*
         * https://leetcode.com/problems/maximal-rectangle/
         */
        public int MaximalRectangleStack(char[][] matrix)
        {
            var matrixInt = new int[matrix.Length][];
            var maxArea = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                matrixInt[i] = new int[matrix[i].Length];

                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0)
                        {
                            matrixInt[i][j] = 1;
                        }
                        else
                        {
                            matrixInt[i][j] = matrixInt[i - 1][j] + 1;
                        }
                    }
                    else
                    {
                        matrixInt[i][j] = 0;
                    }
                }

                var stack = new Stack<int>();
                for (var l = 0; l < matrixInt[i].Length; l++)
                {
                    if (stack.Count() == 0 || matrixInt[i][l] >= matrixInt[i][stack.Peek()])
                    {
                        stack.Push(l);
                    }
                    else
                    {
                        var top = stack.Pop();
                        maxArea = Math.Max(maxArea, (matrixInt[i][top] * (stack.Count() == 0 ? l : l - 1 - stack.Peek())));
                        l--;
                    }
                }

                while (stack.Count() > 0)
                {
                    var top = stack.Pop();
                    maxArea = Math.Max(maxArea, (matrixInt[i][top] * (stack.Count() == 0 ? matrixInt[i].Length : matrixInt[i].Length - 1 - stack.Peek())));
                }
            }

            return maxArea;
        }

        //TODO: Dynamic Programming
        public int MaximalRectangleDynamicProgramming(char[][] matrix)
        {
            return 0;
        }
    }
}
