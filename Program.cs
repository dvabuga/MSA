using System;
using System.Linq;
using System.Text;

namespace MSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "abc";

            byte[] array = Encoding.Default.GetBytes(input.ToCharArray());
            array = array.OrderBy(x => x).ToArray();
            Console.WriteLine(Encoding.Default.GetString(array));

            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetPermutations(array);
            startTime.Stop();
            var resultTime = startTime.Elapsed;

            
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            Console.WriteLine(elapsedTime);

            Console.ReadLine();
        }

        static void GetPermutations(byte[] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Array is empty");
            }

            while (true)
            {
                var index1 = GetIndex1(arr);

                if (index1 == -1)
                {
                    Console.WriteLine("No suitable elements");
                    break;
                }
                var index2 = GetIndex2(arr, index1);
                Swap(arr, index1, index2);
                var perm = Reverse(arr, index1);
                Console.WriteLine(Encoding.Default.GetString(arr));
            }
        }


        static int GetIndex1(byte[] arr)
        {
            var lenght = arr.Length;
            var end = lenght - 1;
            int index1 = -1;

            for (var i = end; i != 0; i--)
            {
                if (arr[i] > arr[i - 1])
                {
                    index1 = i - 1;
                    break;
                }
            }

            return index1;
        }


        static int GetIndex2(byte[] arr, int index1)
        {
            var lenght = arr.Length;
            var end = lenght - 1;
            int index2 = -1;

            for (var i = end; i != 0; i--)
            {
                if (arr[i] > arr[index1])
                {
                    index2 = i;
                    break;
                }
            }

            return index2;
        }

        static byte[] Swap(byte[] arr, int index1, int index2)
        {
            byte temp;
            temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return arr;
        }


        static byte[] Reverse(byte[] arr, int index1)
        {
            var lenght = arr.Length;
            var end = lenght - 1;
            
            
            Array.Reverse(arr, index1 + 1, end - index1);

            return arr;
        }
    }
}
