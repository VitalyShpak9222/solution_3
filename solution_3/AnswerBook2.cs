using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_3
{
    internal static class AnswerBook2
    {
        private static void PrintList(List<int> list)
        {
            int len = list.Count();
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{list[i]} ");
            }
        }

        private static void PrintList(List<string> list)
        {
            int len = list.Count();
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{list[i]} ");
            }
        }

        public static void Task_1_A_ToSolutions()
        {
            Console.WriteLine("Задача A. Простое заполнение");
            Console.WriteLine("Введите число");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i + 1;
            }
            AnswerBook1.PrintArray(array);
        }

        public static void Task_2_B_ToSolutions()
        {
            Console.WriteLine("Задача B. N элементов");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            int[] ints = new int[n];
            for (int i = 0; i < n; i++)
            {
                ints[i] = int.Parse(array[i]);
            }
            AnswerBook1.PrintArray(ints);
        }

        public static void Task_3_C_ToSolutions()
        {
            Console.WriteLine("Задача C. N элементов в обратном порядке");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            int[] ints = new int[n];
            for (int i = 0; i < n; i++)
            {
                ints[n - 1 - i] = int.Parse(array[i]);
            }
            AnswerBook1.PrintArray(ints);
        }

        public static void Task_4_D_ToSolutions()
        {
            Console.WriteLine("Задача D. Выведите нечетные элементы");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            for (int i = 0; i < n; i++)
            {
                if (int.Parse(array[i]) % 2 == 1) 
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }

        public static void Task_5_E_ToSolutions()
        {
            Console.WriteLine("Задача E. Выведите четные элементы");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            for (int i = 0; i < n; i++)
            {
                if (int.Parse(array[i]) % 2 == 0)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }

        public static void Task_6_F_ToSolutions()
        {
            Console.WriteLine("Задача F. A[0], A[2], A[4], ...");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }

        public static void Task_7_G_ToSolutions()
        {
            Console.WriteLine("Задача G. Количество элементов, больших предыдущего");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            int[] mass = new int[n];
            for (int i = 0; i < n; i++)
            {
                mass[i] = int.Parse(array[i]);
            }
            int k = 0;
            for (int i = 0; i < n-1; i++)
            {
                if (mass[i] < mass[i+1])
                {
                    k++;
                }
            }
            Console.WriteLine(k);
        }

        public static void Task_8_H_ToSolutions()
        {
            Console.WriteLine("Задача H. Есть ли два элемента с одинаковыми знаками");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            int[] mass = new int[n];
            for (int i = 0; i < n; i++)
            {
                mass[i] = int.Parse(array[i]);
            }
            bool k = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (mass[i]>= 0 && mass[i + 1]>= 0)
                {
                    k = true;
                    break;
                }
            }
            if (k) 
            {
                Console.WriteLine("YES");
            }
            else 
            {
                Console.WriteLine("NO");
            }
        }

        public static void Task_9_I_ToSolutions()
        {
            Console.WriteLine("Задача I. Количество элементов больших обоих соседей");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            List<string> array = new List<string>(Console.ReadLine().Split(' '));
            int[] mass = new int[n];
            for (int i = 0; i < n; i++)
            {
                mass[i] = int.Parse(array[i]);
            }
            int k = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if (mass[i-1] < mass[i] && mass[i + 1] < mass[i])
                {
                    k++;
                    break;
                }
            }
        }

        public static void Task_10_J_ToSolutions()
        {
            Console.WriteLine("Задача J. Переставить соседние элементы");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            string k = "";
            string v = "";
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) 
                {
                    k = array[i];
                    v = array[i + 1];
                }
                else 
                {
                    array[i-1] = v;
                    array[i] = k;
                }
            }
            int len = array.Count();
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        public static void Task_11_K_ToSolutions()
        {
            Console.WriteLine("Задача K. Количество положительных элементов");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (int.Parse(array[i]) > 0)
                {
                    k++;
                }
            }
            Console.WriteLine(k);
        }

        public static void Task_12_L_ToSolutions()
        {
            Console.WriteLine("Задача L. Количество отрицательных элементов");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (int.Parse(array[i]) < 0)
                {
                    k++;
                }
            }
            Console.WriteLine(k);
        }

        public static void Task_13_M_ToSolutions()
        {
            Console.WriteLine("Задача M. Сколько равно X?\r\n");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите Х");
            string x = Console.ReadLine();
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == x)
                {
                    k++;
                }
            }
            Console.WriteLine(k);
        }

        public static void Task_14_N_ToSolutions()
        {
            Console.WriteLine("Задача N. Где равные X?");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            string[] array = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите Х");
            string x = Console.ReadLine();
            List<int> index = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (array[i] == x)
                {
                    index.Add(i+1);
                }
            }
            PrintList(index);
        }

        public static void Task_15_O_ToSolutions()
        {
            Console.WriteLine("Задача O. Максимум и минимум в массиве");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            int max = -100000;
            int min = 100000;
            int k;
            for (int i = 0; i < n; i++)
            {
                k = int.Parse(Console.ReadLine());
                if (k > max)
                {
                    max = k;
                }
                else if (k < min) 
                {
                    min = k;
                }
            }
            Console.WriteLine($"{max} {min}");
        }

        public static void Task_16_P_ToSolutions()
        {
            Console.WriteLine("Задача P. Номера минимумов");
            Console.WriteLine("Введите количество элементов в массиве");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите {n} элементов массива");
            int min = 100000;
            int k;
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                k = int.Parse(Console.ReadLine());
                if (k < min)
                {
                    min = k;
                    list.Clear();
                    list.Add(i + 1);
                }
                else if (k == min) 
                {
                    list.Add(i+1);
                }
            }
            PrintList(list);
        }

        public static void Task_17_Q_ToSolutions()
        {
            Console.WriteLine("Задача Q. Арифметическая прогрессия");
            Console.WriteLine("Введите начальное значение");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите разность");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите размер");
            int len = int.Parse(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{x} ");
                x += r;
            }
        }

        public static void Task_18_R_ToSolutions()
        {
            Console.WriteLine("Задача R. Циклический сдвиг вправо");
            Console.WriteLine("Введите размер массива");
            int n = int.Parse(Console.ReadLine());
            string[] array = new string[n];
            for (int i = 0; i < n-1; i++)
            {
                array[i+1] = Console.ReadLine();
            }
            array[0] = Console.ReadLine();
            foreach (string item in array)
            {
                Console.Write($"{item} ");
            }
        }

        public static void Task_19_S_ToSolutions()
        {
            Console.WriteLine("Задача S. Уникальные элементы");
            Console.WriteLine("Введите размер массива");
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            Console.WriteLine("Введите элементы масива");
            string k;
            for (int i = 0; i < n; i++)
            {
                k = Console.ReadLine();
                if (list.IndexOf(k) == -1) 
                {
                    list.Add(k);
                }
            }
            PrintList(list);
        }

        public static void Task_20_N_ToSolutions()
        {
            Console.WriteLine("Задача T. N-ичный Счетчик");
        }
    }
}
