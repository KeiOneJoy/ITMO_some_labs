using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO_labs_task1
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }
            matrix = new int[size, size];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }
        public int SumOfColumnsWithoutNegativeElements()
        {
            int sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                bool hasNegative = false;
                int columnSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    columnSum += matrix[row, col];
                }

                if (!hasNegative)
                {
                    sum += columnSum;
                }
            }

            return sum;
        }

        public int MinimumSumOfAbsDiagonals()
        {
            int minSum = int.MaxValue;
            int size = matrix.GetLength(0);

            for (int k = 1 - size; k < size; k++)
            {
                int currentSum = 0;
                for (int i = 0; i < size; i++)
                {
                    int j = size - 1 - i - k;
                    if (j >= 0 && j < size)
                    {
                        currentSum += Math.Abs(matrix[i, j]);
                    }
                }

                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }

            return minSum;
        }

        public int[,] Matrix
        {
            get { return matrix; }
        }
    }
}
