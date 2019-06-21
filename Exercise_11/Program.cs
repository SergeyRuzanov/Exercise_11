﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    class Program
    {
        const int count = 11;
        static void Main(string[] args)
        {
            string text;
            do
            {
                Console.WriteLine("Введите строку из 121 символа:");
                text = Console.ReadLine();
                if (text.Length == count * count)
                    break;
            } while (true);

            //text = "At principle perfectly by sweetness do. Up hung mr we give rest half. Made neat an on be gave show snug tore. Celebrated.";
            char[,] matrix = CreateMatrix(text);
            string encryptingText = Encrypting(matrix);
            Console.WriteLine("Закодированный текст:");
            Console.WriteLine(encryptingText);
            string unecryptingText = Unecrypting(encryptingText);
            Console.WriteLine("Раскодированный текст:");
            Console.WriteLine(unecryptingText);
            Console.ReadLine();
        }
        static char[,] CreateMatrix(string txt)
        {
            char[,] matrix = new char[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = txt[i * count + j];
                }
            }
            return matrix;
        }
        static string Encrypting(char[,] matrix)
        {
            string str = "";
            int i = (count - 1) / 2, j = (count - 1) / 2;

            int i_min = i;
            int i_max = i;
            int j_min = j;
            int j_max = j;

            int d = 0;
            for (int k = 0; k < count * count; k++)
            {
                str += matrix[i, j];
                switch (d)
                {
                    case 0:
                        j = j - 1;
                        if (j < j_min)
                        {
                            d = 1;
                            j_min = j;
                        }
                        break;
                    case 1:
                        i = i + 1;
                        if (i > i_max)
                        {
                            d = 2;
                            i_max = i;
                        }
                        break;
                    case 2:
                        j = j + 1;
                        if (j > j_max)
                        {
                            d = 3;
                            j_max = j;
                        }
                        break;
                    case 3:
                        i = i - 1;
                        if (i < i_min)
                        {
                            d = 0;
                            i_min = i;
                        }
                        break;
                }
            }
            return str;
        }
        static string Unecrypting(string txt)
        {
            char[,] matrix = new char[count, count];
            int i = (count - 1) / 2, j = (count - 1) / 2;

            int i_min = i;
            int i_max = i;
            int j_min = j;
            int j_max = j;

            int d = 0;
            for (int k = 0; k < count * count; k++)
            {
                matrix[i, j] = txt[k];
                switch (d)
                {
                    case 0:
                        j = j - 1;
                        if (j < j_min)
                        {
                            d = 1;
                            j_min = j;
                        }
                        break;
                    case 1:
                        i = i + 1;
                        if (i > i_max)
                        {
                            d = 2;
                            i_max = i;
                        }
                        break;
                    case 2:
                        j = j + 1;
                        if (j > j_max)
                        {
                            d = 3;
                            j_max = j;
                        }
                        break;
                    case 3:
                        i = i - 1;
                        if (i < i_min)
                        {
                            d = 0;
                            i_min = i;
                        }
                        break;
                }
            }

            string str = "";
            foreach (char ch in matrix)
            {
                str += ch;
            }
            return str;
        }
    }
}
