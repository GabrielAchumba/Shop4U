using SoftwareForecasting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SoftwareForecasting.Mathematics
{
    public class NativeMethods
    {
        [DllImport(Util.DllPath, CallingConvention = CallingConvention.StdCall)]
        internal static extern int TestArrayOfInts([In, Out] int[] array, int size);
    }
}
