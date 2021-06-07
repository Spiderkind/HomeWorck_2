using System;

namespace Level_1
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static string BlockScheme(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return ("Простое");
            }
            else
            {
                return ("Не простое");
            }
        }
        static void Test(TestCase testCase)
        {
            try
            {
                var actual = BlockScheme(testCase.N);

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
                N = 43,
                Expected = "Простое",
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 4,
                Expected = "Не простое",
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 457,
                Expected = "Простое",
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 8,
                Expected = "Простое",
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = 2,
                Expected = "Не простое",
                ExpectedException = null
            };
            var testCase6 = new TestCase()
            {
                N = 1,
                Expected = "Не простое",
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
