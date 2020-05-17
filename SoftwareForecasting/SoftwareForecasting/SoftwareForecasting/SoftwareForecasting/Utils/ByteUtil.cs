using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SoftwareForecasting.Utils
{
    public class ByteUtil
    {
        public static byte[] SerializeToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object Deserialize(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;


            }
        }
    }
}
