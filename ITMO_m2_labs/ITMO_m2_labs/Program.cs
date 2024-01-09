using System;

namespace ITMO_m2_labs
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
            foreach (double element in customArr.GetArray())
            {
                Console.Write(element + " ");
            }

            double sum = customArr.GetSumUntilTheLastPositiveElement();
            Console.WriteLine("\nСумма элементов до последнего положительного элемента: " + sum);

            Console.Write("\nВведите значение a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите значение b: ");
            double b = double.Parse(Console.ReadLine());

            customArr.CompressArray(a, b);

            Console.WriteLine("\nМассив после сжатия:");
            foreach (double element in customArr.GetArray())
            {
                Console.Write(element + " ");
            }

            Console.WriteLine("\nНажмите Enter, чтобы завершить программу.");
            Console.ReadLine(); // Ожидание пользовательского ввода
        }
    }
}
