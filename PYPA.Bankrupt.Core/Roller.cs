using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PYPA.Bankrupt.Core
{
    public class Roller
    {
        Random r;
        public Roller()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[32];
                rg.GetBytes(rno);
                int randomvalue = BitConverter.ToInt32(rno, 0);
                r = new Random(randomvalue);
            }
        }
        public int RollInt(int maxValue = Int32.MaxValue)
        {
            return r.Next(maxValue);
        }
        public int RollRNGInt(int maxValue = Int32.MaxValue)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[32];
                rg.GetBytes(rno);
                int randomvalue = BitConverter.ToInt32(rno, 0);
                return Math.Abs(randomvalue) % maxValue;
            }
        }

    }
}
