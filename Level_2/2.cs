using System;

namespace _2
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public int[] Array { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1; //O(1)
            while (min <= max)    //O(N)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        // Асимптотическая сложность O(N)
        static void Test(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.Array, testCase.N);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        static void Main(string[] args)
        {
            int[] Array1 = { 0, 1, 2, 3, 12, 13, 25, 57, 59, 122 };
            int[] Array2 = { 1, 3, 5, 7, 9 };
            int[] Array3 = { 12, 15, 35, 59, 97 };

            var testCase1 = new TestCase()
            {
                N = 0,
                Array = Array1,
                Expected = 0,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 5,
                Array = Array2,
                Expected = 2,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 15,
                Array = Array3,
                Expected = 1,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 0,
                Array = Array1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = 7,
                Array = Array2,
                Expected = 1,
                ExpectedException = null
            };
            var testCase6 = new TestCase()
            {
                N = 97,
                Array = Array3,
                Expected = 59,
                ExpectedException = null
            };

            Test(testCase1);
            Test(testCase2);
            Test(testCase3);
            Test(testCase4);
            Test(testCase5);
            Test(testCase6);
        }
    }
}