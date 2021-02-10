using System;
using System.Linq;
using System.Text;

namespace MSA
{
    class Program
    {
        static int Lenght;
        static int End;

        static void Main(string[] args)
        {
            var input = "abclxk";

            char[] array = input.ToCharArray();
            array = array.OrderBy(x => x).ToArray();

            Lenght = array.Length;
            End = Lenght - 1;

            Console.WriteLine(new string(array));

            var startTime = System.Diagnostics.Stopwatch.StartNew();
            GetPermutationAndPrint(array);
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

        static void GetPermutationAndPrint(char[] arr)
        {
            if (Lenght == 0)
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
                Reverse(arr, index1);
                Console.WriteLine(new string(arr));
            }
        }


        static int GetIndex1(char[] arr)
        {
            int index1 = -1;

            for (var i = End; i != 0; i--)
            {
                if (arr[i] > arr[i - 1])
                {
                    index1 = i - 1;
                    break;
                }
            }

            return index1;
        }


        static int GetIndex2(char[] arr, int index1)
        {
            int index2 = -1;

            for (var i = End; i != 0; i--)
            {
                if (arr[i] > arr[index1])
                {
                    index2 = i;
                    break;
                }
            }

            return index2;
        }

        static void Swap(char[] arr, int index1, int index2)
        {
            //деконструкция туплов
            (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
        }


        static void Reverse(char[] arr, int index1)
        {
            Array.Reverse(arr, index1 + 1, End - index1);
        }
    }
}
