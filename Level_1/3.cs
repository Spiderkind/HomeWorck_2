using System;

namespace _3
{
    class Program
    {
        static int s = 0;
        public class TestCase
        {
            public int N { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static int Fib_R(int num)
        {
            if (num < 2)
                return num;
            return Fib_R(num - 1) + Fib_R(num - 2);

        }
        static int Fib_C(int n)
        {
            int f0 = 0; int f1 = 1; int fsum = 0;
            if (n == 1)
                fsum = f1;
            else if (n == 2)
                fsum = f1;
            for (int i = 2; i <= n; i++)
            {
                fsum = f0 + f1;
                f0 = f1;
                f1 = fsum;
            }
            return (fsum);
        }
        static void Test(TestCase testCase)
        {
            try
            {
                var actual = Fib_R(testCase.N);

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
        static void Test2(TestCase testCase)
        {
            try
            {
                var actual = Fib_C(testCase.N);

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
            var testCase1 = new TestCase()
            {
                N = 1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 7,
                Expected = 13,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 10,
                Expected = 55,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 15,
                Expected = 1132,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = 14,
                Expected = 102,
                ExpectedException = null
            };
            var testCase6 = new TestCase()
            {
                N = 3,
                Expected = 10,
                ExpectedException = null
            };

            Test(testCase1);
            Test2(testCase1);
            Test(testCase2);
            Test2(testCase2);
            Test(testCase3);
            Test2(testCase3);
            Test(testCase4);
            Test2(testCase4);
            Test(testCase5);
            Test2(testCase5);
            Test(testCase6);
            Test2(testCase6);
        }
    }
}