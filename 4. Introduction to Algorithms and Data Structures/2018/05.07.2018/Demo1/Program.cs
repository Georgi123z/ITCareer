﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        // Измерване на време на работа на алгоритъма
        private static void MesureTime(Action method)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            method(); 
            timer.Stop();
            Console.WriteLine("Time = {0} ms", timer.Elapsed.TotalMilliseconds);
        }

        // Алгоритми за търсене
        static void Main(string[] args)
        {
            // 0. Data Structure            
            char[] array = new char[] { 'm', 'a', 'g', 'i', 'c', 'h', 'a', 'p', 'p', 'e', 'n', 'd', 's', 'h', 'e', 'r', 'e' };
            char[] sorted = array.ToArray();
            // int[] array = new int[] { 5, -5, 4, -4, 3, -3, 2, -2, 1, -1 };
            // int[] sorted = array.ToArray();
            Array.Sort(sorted);
            int index = 0;
            char key = 'p';

            // 1. LinearSearch = O(N)
            Console.WriteLine("1. LinearSearch = O(N)");
            MesureTime(() =>  index = Search.LinearSearch(array, key));
            if (index == -1) Console.WriteLine("Not Found\n");
            else Console.WriteLine("Index = {0}\n", index);

            // 2. RecursiveBinarySearch = O(log(N))
            Console.WriteLine("2. RecursiveBinarySearch = O(log(N))");
            MesureTime(() => index = Search.RecursiveBinarySearch(sorted, key, 0, array.Count() - 1));
            if (index == -1) Console.WriteLine("Not Found\n");
            else Console.WriteLine("Index = {0}\n", index);

            // 3. BinarySearch = O(log(N))
            Console.WriteLine("3. BinarySearch = O(log(N))");
            MesureTime(() => index = Search.BinarySearch(sorted, key, 0, array.Count() - 1));
            if (index == -1) Console.WriteLine("Not Found\n");
            else Console.WriteLine("Index = {0}\n", index);

            // 4. InterpolationSearch = O(log(log(N)))
            Console.WriteLine("4. InterpolationSearch = O(log(log(N)))");
            MesureTime(() => index = Search.InterpolationSearch(sorted, key));
            if (index == -1) Console.WriteLine("Not Found\n");
            else Console.WriteLine("Index = {0}\n", index);

            // 5. EasySearch = O(N)
            Console.WriteLine("5. EasySearch = O(N)");
            MesureTime(() => index = Search.EasySearch(sorted, key));
            Console.WriteLine(index == -1 ? "Not Found\n" : $"Index = {index}\n");
        }
    }
}
