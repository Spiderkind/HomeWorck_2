using System;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int error = 1;
            int[] len = new int[0];
            Console.WriteLine("¬ведите размер пол€ N и M через пробел: ");
            while (error != 0 | len.Length != 2)
            {
                try
                {
                    string input = Console.ReadLine();
                    len = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    if (len.Length != 2)
                        Console.WriteLine("¬ведено <> 2 чисел, введите еще раз");
                    error = 0;
                }
                catch
                {
                    Console.WriteLine("¬ведены не числа, введите еще раз");
                }
            }
            int N = len[0];
            int M = len[1];
            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1;
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }
            Console.WriteLine(A[N - 1, M - 1]);
        }
    }
}