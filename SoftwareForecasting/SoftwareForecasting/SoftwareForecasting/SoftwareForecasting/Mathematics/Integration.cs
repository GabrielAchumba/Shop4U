using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SoftwareForecasting.Utils;

namespace SoftwareForecasting.Mathematics
{
    public class Integration
    {
        [DllImport(Util.DllPath,
         EntryPoint = "Add", CallingConvention = CallingConvention.StdCall)]
        public static extern double Add(double a, double b);

        [DllImport(Util.DllPath,
        EntryPoint = "Subtract", CallingConvention = CallingConvention.StdCall)]
        public static extern double Subtract(double a, double b);

        [DllImport(Util.DllPath,
        EntryPoint = "Multiply", CallingConvention = CallingConvention.StdCall)]
        public static extern double Multiply(double a, double b);

        [DllImport(Util.DllPath,
        EntryPoint = "Divide", CallingConvention = CallingConvention.StdCall)]
        public static extern double Divide(double a, double b);

        [DllImport(Util.DllPath,
        SetLastError = true, EntryPoint = "GetString", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetString([MarshalAs(UnmanagedType.LPStr)]String a);

        [DllImport(Util.DllPath,
        EntryPoint = "GetString2", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetString2([MarshalAs(UnmanagedType.LPStr)]String a);

        public static double Trapezoidal(double x, double y)
        {
            return x * y;
        }

        public static double Addition(double a, double b)
        {
            double c = Add(a, b);
            //double d = Subtract(a, b);
            //double e = Multiply(a, b);
            //double f = Divide(a, b);
            //string str_input = "Gab";
            //GetString(str_input);
            //string g = GetString2(str_input);

            return c;
        }

        public static void TestArrayOfInts()
        {
            int[] array1 = new int[10];

            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i;
            }

            int sum1 = NativeMethods.TestArrayOfInts(array1, array1.Length);
        }
    }

    public struct InputDeckStuct
    {
        string ModuleName;
        double OilRate;

    }
}
