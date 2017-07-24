using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaFileCore
{
    public static class ByteExtends
    {
        public static int ToIntenger(this byte[] model, int startIndex, int count)
        {
            byte[] bytes = new byte[count];
            System.Buffer.BlockCopy(model, startIndex, bytes, 0, count);

            if (count == 2)
            {
                int result = (bytes[1] << 8) | bytes[0];
                return result;
            }

            else if (count == 4)
                return BitConverter.ToInt32(bytes, 0);

            else
                return (int)BitConverter.ToInt64(bytes, 0);
        }


    }
}
