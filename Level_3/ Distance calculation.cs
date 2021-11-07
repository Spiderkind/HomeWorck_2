using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Runtime.InteropServices;

namespace _1
{
    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public int i;

        [FieldOffset(0)]
        public float f;
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        public static float PointDistanceClassFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceStructFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistanceStructDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceStructFloatNS(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }
        [Benchmark]
        public void TestDistanceClassFloat()
        {
            var point1 = new PointClass() { X = 2, Y = 15 };
            var point2 = new PointClass() { X = 42, Y = 25 };
            PointDistanceClassFloat(point1, point2);
        }

        [Benchmark]
        public void TestDistanceStructureFloat()
        {
            var point1 = new PointStruct() { X = 2, Y = 15 };
            var point2 = new PointStruct() { X = 42, Y = 25 };

            PointDistanceStructFloat(point1, point2);
        }
        [Benchmark]
        public void TestDistanceStructDouble()
        {
            var point1 = new PointStruct() { X = 2, Y = 15 };
            var point2 = new PointStruct() { X = 42, Y = 25 };

            PointDistanceStructDouble(point1, point2);
        }
        [Benchmark]
        public void TestDistanceStructFloatNS()
        {
            float x = 2 - 42;
            float y = 15 - 25;
            x = x * x;
            y = y * y;
            float z = x + y;
            PointDistanceStructFloatNS(z);
        }
    }
}
