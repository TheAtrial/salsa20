using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Salsa20
    {

        private byte[] key0 = null;
        private byte[] key1 = null;
        private byte[] sigma0 = { 101, 120, 112, 97 }; // "expa"
        private byte[] sigma1 = { 110, 100, 32, 51 };  // "nd 3"
        private byte[] sigma2 = { 50, 45, 98, 121 };   // "2-by"
        private byte[] sigma3 = { 116, 101, 32, 107 }; // "te k"
        private byte[] tau0 = { 101, 120, 112, 97 }; // "expa"
        private byte[] tau1 = { 110, 100, 32, 49 };  // "nd 1"
        private byte[] tau2 = { 54, 45, 98, 121 };   // "6-by"
        private byte[] tau3 = { 116, 101, 32, 107 }; // "te k"

        private const uint block_size = 64;
        private const uint double_rounds = 10;
        private const uint matrix_size = 16;

        public Salsa20(byte[] _key) {
            key0 = new byte[16];
            Array.Copy(_key, key0, 16);
            if (_key.Length == 32) {
                key1 = new byte[16];
                Array.Copy(_key, 16, key1, 0, 16);
            }
        }

        public uint rotl32(uint x, int shift) {
            return x << shift | x >> (32 - shift);
        }

        public void quarterround(ref uint y0, ref uint y1, ref uint y2, ref uint y3) {
            y1 ^= rotl32(y0 + y3, 7);
            y2 ^= rotl32(y1 + y0, 9);
            y3 ^= rotl32(y2 + y1, 13);
            y0 ^= rotl32(y3 + y2, 18);
        }

        public void rowround(ref uint[] y) {
            quarterround(ref y[0], ref y[1], ref y[2], ref y[3]);
            quarterround(ref y[5], ref y[6], ref y[7], ref y[4]);
            quarterround(ref y[10], ref y[11], ref y[8], ref y[9]);
            quarterround(ref y[15], ref y[12], ref y[13], ref y[14]);
        }

        public void columnround(ref uint[] y)
        {
            quarterround(ref y[0], ref y[4], ref y[8], ref y[12]);
            quarterround(ref y[5], ref y[9], ref y[13], ref y[1]);
            quarterround(ref y[10], ref y[14], ref y[2], ref y[6]);
            quarterround(ref y[15], ref y[3], ref y[7], ref y[11]);
        }

        public void doubleround(ref uint[] y) {
            columnround(ref y);
            rowround(ref y);
        }

        public uint littleendian(byte b0, byte b1, byte b2, byte b3) {
            return (uint)(b0 | b1 << 8 | b2 << 16 | b3 << 24);
        }

        public byte[] littleendian_r(uint x) {
            byte[] res = new byte[4];
            for (int i = 0; i != 4; ++i)
                res[i] = (byte)((x >> i * 8) & 0xff);
            return res;
        }

        public void salsa20(ref byte[] block) {
            uint[] x = new uint[matrix_size];
            uint[] temp = new uint[matrix_size];

            for (int i = 0; i != matrix_size; ++i)
                x[i] = littleendian(block[i*4], block[i*4 + 1], block[i*4 + 2], block[i*4 + 3]);
            Array.Copy(x, temp, matrix_size);
            
            for(int i = 0; i != double_rounds; ++i)
                doubleround(ref x);

            for (int i = 0; i != matrix_size; ++i)
                littleendian_r(temp[i] + x[i]).CopyTo(block, i * 4);
        }

        public byte[] salsa_exp(byte[] n) {
            byte[] block = null;
            if (key1 != null)
                block = sigma0.Concat(key0).Concat(sigma1).Concat(n)
                    .Concat(sigma2).Concat(key1).Concat(sigma3).ToArray();
            else
                block = tau0.Concat(key0).Concat(tau1).Concat(n)
                    .Concat(tau2).Concat(key0).Concat(tau3).ToArray();
            salsa20(ref block);
            return block;
        }

        public byte[] encrypt(byte[] input, byte[] nonce) {

            int input_size = input.Length;
            byte[] res = new byte[input_size];
            input.CopyTo(res, 0);
            byte[] n = new byte[16];
            nonce.CopyTo(n, 0);
            int offset = 8;
                
            int blocks = (int)Math.Ceiling((double)input_size / block_size);
            for (int i = 0; i != blocks; ++i) {
                for (int j = 0; j != sizeof(int); ++j)
                    n[j + offset] = (byte)((i >> 8 * j) & 0xff);
                byte[] block = salsa_exp(n);
                for (int pos = 0; pos != block_size && pos != input_size - i * block_size; ++pos)
                    res[i*block_size + pos] ^= block[pos];
            }

            return res;
        }

    }
}
