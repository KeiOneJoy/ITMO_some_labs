using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO_labs_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            Custom_arr customArr = new Custom_arr(size);

            double maxElement = customArr.GetMaxElement();
            Console.WriteLine("Максимальный элемент в массиве: " + maxElement);

            Console.WriteLine("Сгенерированный массив:");
            PrintArray(customArr.Array);


            double sum = customArr.GetSumUntilTheLastPositiveElement();
            Console.WriteLine("\nСумма элементов до последнего положительного элемента: " + sum);

            Console.Write("\nВведите значение a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите значение b: ");
            double b = double.Parse(Console.ReadLine());

            customArr.CompressArray(a, b);

            Console.WriteLine("\nМассив после сжатия:");

            PrintArray(customArr.Array);

            Console.WriteLine("\nЧасть 2:");

            var secondPart = new SecondPart(4);
            PrintMatrix(secondPart.Matrix);

            var summ = secondPart.SumOfColumnsWithoutNegativeElements();
            Console.WriteLine("Сумма элементов в тех столбцах, которые не содержат отрицательных эелементов: " + summ);

            var min = secondPart.MinimumSumOfAbsDiagonals();
            Console.WriteLine("Минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали матрицы: " + min);

            Console.WriteLine("\nНажмите Enter, чтобы завершить программу.");
            Console.ReadLine();

        }

        static void PrintArray(double[] array)
        {
            foreach (double element in array)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
