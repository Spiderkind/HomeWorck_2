using System;
using System.Collections.Generic;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 150, 254, 123, 3, 15, 25, 98, 123, 15, 26, 125, 652, 123, 148, 854, 754, 452, 1205 };
            List<int> sorted = Break(array);
            foreach (var num in sorted)
                Console.Write($"{num}; ");
        }
        public static List<int> Break(int[] input)
        {

            List<int> Sorted = new List<int>();
            int numblocks = Maximum(input);
            List<int>[] blocks = new List<int>[numblocks];
            for (int i = 0; i < numblocks; i++)
                blocks[i] = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int block = (input[i] / numblocks);
                blocks[block].Add(input[i]);
            }
            for (int i = 0; i < numblocks; i++)
            {
                List<int> sort = Sort(blocks[i]);
                Sorted.AddRange(sort);
            }
            return Sorted;
        }
        public static List<int> Sort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                int Value = input[i];
                int j = i - 1;
                while (i - 1 >= 0)
                {
                    if (Value < input[j])
                    {
                        input[j + 1] = input[j];
                        input[j] = Value;
                    }
                    else break;
                }
            }
            return input;
        }
        public static int Maximum(int[] input)
        {
            int max = input[0];
            for (int i = 1; i < input.Length; i++)
                if (input[i] > max)
                    max = input[i];
            int j = 0;
            while (max >= 1)
            {
                max /= 10;
                j++;
            }
            int output = Convert.ToInt32(Math.Pow(10, j - 2));
            return output;
        }
    }
}
