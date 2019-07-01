﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
/* 1. Преобразуване от 10-ична в N-ична ПБС
Напишете програма, която получава число в в 10-ична бройна система и го преобразува в число в N-ична бройна система, където 2 < = N < = 10. Входът се състои от 1 ред, съдържащ две числа, разделени с един интервал. Първото число е основа N, към която трябва да преобразувате. Вторият е число в 10-ична бройна система. Не използвайте никакви вградени функционалности за преобразуване на числа, опитайте се да напишете свой собствен алгоритъм.
Решение: Божидар Андонов
*/
    class Program
    {
        private static string NumberinNthSystem(int numsys, int number)
        {
            string NewNumber = "";
            while (number != 0)
            {
                NewNumber += number % numsys;
                number /= numsys;
            }
            NewNumber = string.Join("", NewNumber.Reverse());
            return NewNumber;
        }
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numsys = input[0];
            int number = input[1];
            Console.WriteLine(NumberinNthSystem(numsys, number));
        }
    }
}
