using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DynamicProgramming
    {
        /*
         * https://leetcode.com/problems/regular-expression-matching/
         */
        public bool RegularExpressionMatchingIsMatch(string s, string p)
        {
            var stringIndex = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (stringIndex + 1 < p.Length)
                {
                    if (p[stringIndex + 1] == '*')
                    {
                        if (p[stringIndex] == '.')
                        {
                            return true;
                        }
                        else
                        {
                            if (p[stringIndex] == s[i])
                            {
                                continue;
                            }
                            else
                            {
                                stringIndex += 2;
                                i--;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (p[stringIndex] == '.' || p[stringIndex] == s[i])
                        {
                            stringIndex++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (stringIndex < p.Length)
                    {
                        if (p[stringIndex] == '.' || p[stringIndex] == s[i])
                        {
                            stringIndex++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (stringIndex == p.Length || (stringIndex + 2 == p.Length && p[stringIndex + 1] == '*')) return true;

            return false;
        }
    }
}
