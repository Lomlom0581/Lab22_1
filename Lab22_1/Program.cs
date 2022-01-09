using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22_1
{
    class Program
    {        
        public static long ListSum(List<int> l)
        {
            long sum = 0;
            foreach (var v in l) sum += v;
            return sum;
        }
                
        public static int MaxInList(List<int> l)
        {
            int MaxValue = 0;
            foreach (var v in l) if (v > MaxValue) MaxValue = v;
            return MaxValue;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите размер массива:");
            uint Dim = uint.Parse(Console.ReadLine());

            Random r = new Random();

            List<int> list = new List<int>();

            for (int i = 0; i < Dim; i++)
                list.Add(r.Next(10000));

            Task<long> ListSumTask = Task.Run(() => ListSum(list));
            Task<int> MaxValueTask = Task.Run(() => MaxInList(list));
            Task.WhenAll(new List<Task> { ListSumTask, MaxValueTask });

            Console.WriteLine("Максимальное значение: " + MaxValueTask.Result);
            Console.WriteLine("Cумма элементов: " + ListSumTask.Result);
            Console.ReadKey();


        }
    }
}
