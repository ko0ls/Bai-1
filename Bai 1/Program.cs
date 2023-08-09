using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Nhập liệu
            var mc = new Program();
            int n = 0;
            Console.WriteLine("Nhap vao so tu nhien n:");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap vao ma tran A[{0}*{1}]:", n, n);
            int[,] maTran = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Nhap vao phan tu A[{0},{1}]: ", i + 1, j + 1);
                    maTran[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("----------------");
            #endregion

            int[,] outMT = null;
            bool flag = false;

            #region xử lý ma trận
            for (int size = 2; size <= n; size++)
            {
                for (int rIndex = 0; rIndex <= n - size; rIndex++)
                {
                    for (int cIndex = 0; cIndex <= n - size; cIndex++)
                    {
                        flag = mc.subMaxtrix(maTran, rIndex, cIndex, n, size, out outMT);
                        if (flag) break;
                    }
                    if (flag) break;
                }
                if (flag) break;
            }
            #endregion

            if (flag)
            {
                mc.printMaxTrix(outMT);
            }
            else
            {
                Console.Write("Khong tim thay ma tran thoa man");
            }

            Console.ReadLine();
        }

        private bool subMaxtrix(int[,] maTrix, int rIndex, int cIndex,int n, int size, out int[,] outMaTrix)
        {
            int[,] maTrixOut = null;
            bool HasMatrix = false;
            if ((rIndex + size <= n) && (cIndex + size <= n))
            {
                maTrixOut = new int[size, size];
                for (int i = rIndex; i < rIndex + size; i++)
                {
                    for (int j = cIndex; j < cIndex + size; j++)
                    {
                        maTrixOut[i - rIndex, j - cIndex] = maTrix[i, j];
                    }
                }

                int tong1 = 0, tong2 = 0;
                int m = size;
                for (int i = 0; i < size; i++)
                {
                    m -= 1;
                    for (int j = 0; j < size; j++)
                    {
                        if (i == j) tong1 += maTrixOut[i, j];
                        if (j == m) tong2 += maTrixOut[i, j];
                    }
                }
                if (tong1 == tong2) HasMatrix = true;
            }
            outMaTrix = maTrixOut;
            return HasMatrix;
        }

        private void printMaxTrix(int[,] matrix)
        {
            Console.WriteLine("Ket qua la:");
            int sl = matrix.Length;
            for (int i = 0; i < Math.Sqrt(sl); i++)
            {
                for (int j = 0; j < Math.Sqrt(sl); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
