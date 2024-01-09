using System;
using System.CodeDom;

namespace ITMO_m2_labs
{
    public class Custom_arr
    {
        private readonly double[] array;

        public Custom_arr(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var random = new Random();

            array = new double[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        public double GetMaxElement()
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Массив пуст");

            double maxElement = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
           
        }
      
        public double GetSumUntilTheLastPositiveElement()
        {
            double sum = 0;
            int lastIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    lastIndex = i;
                }

                sum += array[i];
            }

            if (lastIndex != -1)
            {
                sum -= array[lastIndex];
            }

            return sum;
        }





        public void CompressArray(double a, double b)
        {
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) >= a && Math.Abs(array[i]) <= b)
                {
                    array[newIndex] = 0;
                }
                else
                {
                    array[newIndex] = array[i];
                }
            }

            // Заполняем оставшиеся элементы нулями
            for (int i = newIndex; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public double[] GetArray()
        {
            return array;
        }
    }
}
