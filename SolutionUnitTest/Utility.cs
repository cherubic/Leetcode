using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionUnitTest
{
    public static class Utility
    {
        public static bool IntArrayEqual(int[] arrayA, int[] arrayB)
        {
            var result = true;

            if (arrayA == null && arrayB == null) return true;

            if (arrayA.Length != arrayB.Length) return false;

            for (var i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] != arrayB[i])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static int[] IntArrayGenerate()
        {
            var length = new Random().Next(0, 999);
            var result = new int[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = new Random(i).Next(int.MinValue, int.MaxValue);
            }

            return result;
        }
    }
}
