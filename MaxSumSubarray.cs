// G   algorithm max consecutive sum of subarray
using System;

namespace MaxSubarray_CS
{

    class MaxSubArray
    {
        static int sumSubArray(int[] B, int l, int r)
        {
            // protect & validation has been done before enter
            int value = 0;
            for (int i = l; i <= r; i++)
                value += B[i];

            //Console.WriteLine("  \tdbg {0}~{1} sum={2}", l, r, value);

            return value;
        }
        public static int getMaxSumSubArray(int [] A, out int l0, out int r0)
        {
            l0 = 0;
            r0 = 0;
            if (A == null || A.Length == 0)
                return int.MinValue;

            int count = A.Length;
            int max = A[0];
            for(int i = 0; i < count; i++)
                for(int j = i; j < count; j++)
            {
                    int maxSub = sumSubArray(A, i, j);
                    //Console.WriteLine("  \tdbg {0}~{1} preMax={2} test={3}", i, j, max, maxSub);
                    if ( max < maxSub)
                    {
                        //Console.WriteLine("  dbg {0}~{1} preMax={2} curMax={3}", i, j, max, maxSub);
                        max = maxSub;
                        l0 = i;
                        r0 = j;
                    }
            }

            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[]{ -2, -3, 4, -1, -2, 1, 5, -3 };
            int left, right;
            int max_sum = MaxSubArray.getMaxSumSubArray(a, out left, out right);
            foreach (int val in a)
                Console.Write("{0}  ", val);
            Console.WriteLine("\nMaximum contiguous sum is {0} at [{1}]~[{2}]", max_sum, left, right);

            a = new int[] { -2, -3, 6, -1, -8, 1, 5, -3 };
            max_sum = MaxSubArray.getMaxSumSubArray(a, out left, out right);
            foreach (int val in a)
                Console.Write("{0}  ", val);
            Console.WriteLine("\nMaximum contiguous sum is {0} at [{1}]~[{2}]", max_sum, left, right);

            a = new int[] { };
            max_sum = MaxSubArray.getMaxSumSubArray(a, out left, out right);
            foreach (int val in a)
                Console.Write("{0}  ", val);
            Console.WriteLine("\nMaximum contiguous sum is {0} at [{1}]~[{2}]", max_sum, left, right);
        }
    }
}
