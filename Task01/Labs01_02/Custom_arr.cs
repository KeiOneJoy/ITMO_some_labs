using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ITMO_labs_task1
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
            }

            for (int i = 0; i < lastIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }



        public void CompressArray(double a, double b)
        {
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {

                if (!(Math.Abs(array[i]) >= a && Math.Abs(array[i]) <= b))
                {
                    array[newIndex] = array[i];
                    newIndex++;
                }
            }

            for (int i = newIndex; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }


        public double[] Array
        {
            get { return array; }
        }
    }
}
