using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace solution_3
{
    public static  class AnswerBook1
    {
        public static void PrintMatrix(List<int[]> matrix)
        {
            foreach (int[] item in matrix)
            {
                foreach (int item2 in item)
                {
                    Console.Write($"{item2} ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] item in matrix)
            {
                foreach (int item2 in item)
                {
                    Console.Write($"{item2} ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(string[][] matrix)
        {
            foreach (string[] item in matrix)
            {
                foreach (string item2 in item)
                {
                    Console.Write($"{item2} ");
                }
                Console.WriteLine();
            }
        }

        public static int[] ReadCondition()
        {
            string[] conditions = Console.ReadLine().Split(' ');
            int len_conditions = conditions.Count();
            int[] result = new int[len_conditions];
            for (int i = 0; i < len_conditions; i++)
            {
                result[i] = int.Parse(conditions[i]);
            }
            return result;
        }
        public static int[][] ReadMatrixInt(int height, int weight)
        {
            int[][] matrix = new int[height][];
            string[] line = new string[weight];
            for (int i = 0; i < height; i++)
            {
                line = Console.ReadLine().Split();
                matrix[i] = new int[weight];
                for (int j = 0; j < weight; j++)
                {
                    matrix[i][j] = int.Parse(line[j]);
                }
            }
            return matrix;
        }

        public static string[][] ReadMatrixstring(int height, int weight)
        {
            string[][] matrix = new string[height][];
            string[] line = new string[weight];
            for (int i = 0; i < height; i++)
            {
                matrix[i] = Console.ReadLine().Split();
            }
            return matrix;
        }

        public static void PrintArray(int[] array)
        {
            int len = array.Count();
            for (int i = 0; i < len - 1; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine(array[len - 1]);
        }

        public static void Task_A_1_ToSolutin()
        {
            Console.WriteLine("Задание #1");
            Console.WriteLine("Введите размерность матрицы m строк * n столбцов");
            int[] condition = ReadCondition();
            int m = condition[0];
            int n = condition[1];
            bool a = true;
            Console.WriteLine("Введите кооддинаты точки в матрице");
            condition = ReadCondition();
            int x = condition[0];
            int y = condition[1];
            int count = 0;
            if (x > n | y > m)
            {
                count++;
                while (a)
                {
                    Console.WriteLine("введите корректные координаты");
                    condition = ReadCondition();
                    x = condition[0];
                    y = condition[1];
                    a = false;
                    if (x > n | y > m)
                    {
                        a = true;
                        count++;
                    }
                    Console.WriteLine($"Ура!!! наконец-то это свершилось вы ошиблись {count} раз");
                }
            }
            int[][] result = new int[4][];
            result[0] = new int[] { x + 1, y };
            result[1] = new int[] { x - 1, y };
            result[2] = new int[] { x, y + 1 };
            result[3] = new int[] { x, y - 1 };
            for (int i = 0; i < 4; i++)
            {
                if (result[i][0] < n & result[i][1] < m & result[i][0] >= 0 & result[i][1] >= 0)
                {
                    AnswerBook1.PrintArray(result[i]);
                }
            }
        }

        public static void Task_B_2_ToSolutin()
        {
            Console.WriteLine("Задание #2");
            Console.WriteLine("Введите размер страны (одно число)");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Введите расположение войск в Квадратландии в виде матрицы размером {n} * {n}");
            int[][] country = ReadMatrixInt(n, n);
            int armies = 0;
            for (int i = 0; i < n; i++)
            {
                armies += country[0][i];
                armies += country[n - 1][i];
            }
            for (int i = 1; i < n - 1; i++)
            {
                armies += country[i][0];
                armies += country[i][n - 1];
            }
            Console.WriteLine(armies);
        }

        public static void Task_C_3_ToSolutin()
        {
            Console.WriteLine("Задача C. Анализ местности");
            Console.WriteLine("Введите размер сетки местности (одно число)");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Вветите значения высот местсти (матрицу размером {n}*{n})");
            int[][] matrix = ReadMatrixInt(n, n);
            int count = 0;
            // проверка 1-й строки
            if (matrix[0][0] > matrix[0][1] & matrix[0][0] > matrix[1][0])
            {
                count++;
            }
            for (int i = 1; i < n - 1; i++)
            {
                if (matrix[0][i] > matrix[0][i - 1] & matrix[0][i] > matrix[0][i + 1] & matrix[0][i] > matrix[1][i])
                {
                    count++;
                }
            }
            if (matrix[0][n - 1] > matrix[0][n - 2] & matrix[0][n - 1] > matrix[1][n - 1])
            {
                count++;
            }
            // проверка центральной части
            for (int i = 1; i < n - 1; i++)
            {
                if (matrix[i][0] > matrix[i][1] & matrix[i][0] > matrix[i + 1][0] & matrix[i][0] > matrix[i - 1][0])
                {
                    count++;
                }
                for (int k = 1; k < n - 1; k++)
                {
                    if (matrix[i][k] > matrix[i][k + 1] & matrix[i][k] > matrix[i][k - 1] & matrix[i][k] > matrix[i + 1][k] & matrix[i][k] > matrix[i - 1][k])
                    {
                        count++;
                    }
                }
                if (matrix[i][n - 1] > matrix[i][n - 2] & matrix[i][n - 1] > matrix[i + 1][n - 1] & matrix[i][n - 1] > matrix[i - 1][n - 1])
                {
                    count++;
                }
            }
            //проверка последней строки
            if (matrix[n - 1][0] > matrix[n - 1][1] & matrix[n - 1][0] > matrix[n - 2][0])
            {
                count++;
            }
            for (int i = 1; i < n - 1; i++)
            {
                if (matrix[n - 1][i] > matrix[n - 1][i - 1] & matrix[n - 1][i] > matrix[n - 1][i + 1] & matrix[n - 1][i] > matrix[n - 2][i])
                {
                    count++;
                }
            }
            if (matrix[n - 1][n - 1] > matrix[n - 1][n - 2] & matrix[n - 1][n - 1] > matrix[n - 2][n - 1])
            {
                count++;
            }
            Console.WriteLine(count);
        }

        public static void Task_D_4_ToSolutin()
        {
            Console.WriteLine("Задача D. Выручка театра");
            Console.WriteLine("Введите размер зала размерностью m строк * n столбцов");
            int[] condition = ReadCondition();
            int m = condition[0];
            int n = condition[1];
            Console.WriteLine($"Ввведите матрицу стоимости билетов {m} на {n}");
            int[][] matrix_price = ReadMatrixInt(m, n);
            Console.WriteLine($"Ввведите матрицу проданных билетов {m} на {n}");
            int[][] matrix_sold = ReadMatrixInt(m, n);
            int price = 0;
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix_sold[i][k] == 1)
                    {
                        price += matrix_price[i][k];
                    }
                }
            }
            Console.WriteLine(price);
        }

        public static void Task_E_5_ToSolutin()
        {
            Console.WriteLine("Задача E. Состязания");
            Console.WriteLine("введите два числа n и m:количество строк и количество столбцов - количество спортсменов и количество бросков (в одну строку через пробел)");
            int[] condition = ReadCondition();
            int n = condition[0];
            int m = condition[1];
            Console.WriteLine($"введите матрицу результатов размерностью {n}*{m}");
            int[][] matrix_result = ReadMatrixInt(n, m);
            int max_sum = -1;
            int sum = 0;
            int num = -1;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int k = 0; k < m; k++)
                {
                    sum += matrix_result[i][k];
                }
                if (max_sum < sum)
                {
                    max_sum = sum;
                    num = i;
                }
            }
            Console.WriteLine($"{max_sum} {num}");
        }

        public static void Task_F_6_ToSolutin()
        {
            Console.WriteLine("Задача F. Состязания-2");
            Console.WriteLine("введите два числа n и m:количество строк и количество столбцов - количество спортсменов и количество бросков (в одну строку через пробел)");
            int[] condition = ReadCondition();
            int n = condition[0];
            int m = condition[1];
            Console.WriteLine($"введите матрицу результатов размерностью {n}*{m}");
            int[][] matrix_result = ReadMatrixInt(n, m);
            int max_sum = -1;
            int sum = 0;
            int max_elem = -1;
            int elem = 0;
            int num = -1;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                elem = 0;
                for (int k = 0; k < m; k++)
                {
                    sum += matrix_result[i][k];
                    if (elem < matrix_result[i][k])
                    {
                        elem = matrix_result[i][k];
                    }
                }
                if (max_elem < elem)
                {
                    max_elem = elem;
                    max_sum = sum;
                    num = i;
                }
                else if (max_elem == elem)
                {
                    if (max_sum < sum)
                    {
                        max_elem = elem;
                        max_sum = sum;
                        num = i;
                    }
                }
            }
            Console.WriteLine($"{num}");
        }

        private class Task_7
        {
            public static int GetDownXLeftRight(string[][] matrix, int y, int x, int n)
            {
                int len = 0;
                if (y + 1 < n && x + 1 < n)
                {
                    if (matrix[y + 1][x + 1] == "X")
                    {
                        len++;
                        len += GetDownXLeftRight(matrix, y + 1, x + 1, n);
                    }
                }
                return len;
            }

            public static int GetDownXRightLeft(string[][] matrix, int y, int x, int n)
            {
                int len = 0;
                if (y - 1 >= 0 && x + 1 < n)
                {
                    if (matrix[y - 1][x + 1] == "X")
                    {
                        len++;
                        len += GetDownXRightLeft(matrix, y - 1, x + 1, n);
                    }
                }
                return len;
            }

            public static int GetXLine(string[][] matrix, int y, int x, int n)
            {
                int len = 0;
                if (x + 1 < n)
                {
                    if ((matrix[y][x + 1]) == "X")
                    {
                        len += 1;
                        len += GetXLine(matrix, y, x + 1, n);
                        return len;
                    }
                }
                return len;
            }

            public static int GetDownXLine(string[][] matrix, int y, int x, int n)
            {
                int len = 0;
                if (y - 1 >= 0)
                {
                    if (matrix[y - 1][x] == "X")
                    {
                        len++;
                        len += GetDownXLine(matrix, y - 1, x, n);
                        return len;
                    }
                }
                return len;
            }
        }

        public static void Task_G_7_ToSolutin()
        {
            Console.WriteLine("Задача G. Четыре в ряд");
            Console.WriteLine("Введите размерность дости (матрицы), необходимо ввести одно число");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Заполните поле размерность {n} * {n}");
            string[][] matrix = ReadMatrixstring(n, n);
            int[] max_num = new int[4] { 0, 0, 0, 0 };
            int get_len;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrix[i][k] == "X")
                    {
                        get_len = Task_7.GetDownXLeftRight(matrix, i, k, n) + 1;
                        if (max_num[0] < get_len)
                        {
                            max_num[0] = get_len;
                        }
                        get_len = Task_7.GetDownXRightLeft(matrix, i, k, n) + 1;
                        if (max_num[1] < get_len)
                        {
                            max_num[1] = get_len;
                        }
                        get_len = Task_7.GetXLine(matrix, i, k, n) + 1;
                        if (max_num[2] < get_len)
                        {
                            max_num[2] = get_len;
                        }
                        get_len = Task_7.GetDownXLine(matrix, i, k, n) + 1;
                        if (max_num[3] < get_len)
                        {
                            max_num[3] = get_len;
                        }
                    }
                }
            }
            Console.WriteLine(max_num.Max());
        }

        public static void Task_H_8_ToSolutin()
        {
            Console.WriteLine("Задача H. Побочная диагональ");
            Console.WriteLine("Введите размерность матрицы (одно число)");
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int k = 0; k < n; k++)
                {
                    if (i + k == n - 1)
                    {
                        matrix[i][k] = 1;
                    }
                    else if (i + k > n - 1)
                    {
                        matrix[i][k] = 2;
                    }
                    else if (i + k < n - 1)
                    {
                        matrix[i][k] = 0;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        public static List<int[]> UpLinePascal(List<int[]> pascal)
        {
            if (pascal.Count() > 2)
            {
                int[] line = pascal.Last();
                int len = line.Count();
                int[] newLine = new int[len + 1];
                for (int i = 0; i < len - 1; i++)
                {
                    newLine[i + 1] = line[i] + line[i + 1];
                }
                newLine[0] = 1;
                newLine[len] = 1;
                pascal.Add(newLine);
                return pascal;
            }
            else if (pascal.Count() == 0)
            {
                pascal.Add(new int[1] { 1 });
                return pascal;
            }
            else if (pascal.Count() == 1)
            {
                pascal.Add(new int[2] { 1, 1 });
                return pascal;
            }
            else
            {
                pascal.Add(new int[3] { 1, 2, 1 });
                return pascal;
            }

        }

        public static void Task_I_9_ToSolutin()
        {
            Console.WriteLine("Задача I. Треугольник Паскаля");
            Console.WriteLine("Введите количество выводимых строк");
            int n = int.Parse(Console.ReadLine());
            List<int[]> matrix = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                matrix = UpLinePascal(matrix);
            }
            PrintMatrix(matrix);
        }

        public static void Task_J_10_ToSolutin()
        {
            Console.WriteLine("Задача J. Заполнение змейкой");
            Console.WriteLine("Введите размеры матрицы (два числа через пробел)");
            int[] conditions = ReadCondition();
            int height = conditions[0];
            int weight = conditions[1];
            int[][] matrix = new int[height][];
            int num = 0;
            for (int i = 0; i < height; i++)
            {
                matrix[i] = new int[weight];
                for (int k = 0; k < weight; k++)
                {
                    matrix[i][k] = num;
                    num++;
                }
            }
            PrintMatrix(matrix);
        }

        public static void Task_K_11_ToSolutin()
        {
            Console.WriteLine("Задача K. Поворот");
            Console.WriteLine("Введите размерность массива ( два числа через пробел)");
            int[] condition = ReadCondition();
            int height = condition[0];
            int weight = condition[1];
            Console.WriteLine($"Заполните матрицу {height} * {weight}");
            int[][] matrix = ReadMatrixInt(height, weight);
            int[][] newMatrix = new int[weight][];
            int[] line = new int[height];
            for (int i = 0; i < weight; i++)
            {
                newMatrix[i] = new int[height];
                for (int k = 0; k < height; k++)
                {
                    newMatrix[i][k] = matrix[height - k - 1][i];
                }
            }
            Console.WriteLine($"{weight} {height}");
            PrintMatrix(newMatrix);
        }

        public static int[][] GetLocation(int[][] matrix, int x, int y, int n, int num)
        {
            if (x + 1 < n && y + 1 < n && x - 1 >= 0 && y - 1 >= 0)
            {
                if (matrix[y][x - 1] != -1 && matrix[y - 1][x] == -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
                else if (matrix[y][x - 1] == -1 && matrix[y + 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
                else if (matrix[y + 1][x] == -1 && matrix[y][x + 1] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
                else if (matrix[y][x + 1] == -1 && matrix[y - 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
                else if (matrix[y][x + 1] != -1 && matrix[y + 1][x] == -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 < n && y + 1 < n && x - 1 >= 0 && y - 1 < 0)
            {
                if (matrix[y][x - 1] == -1 && matrix[y + 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
                else if (matrix[y + 1][x] == -1 && matrix[y][x + 1] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 < n && y + 1 < n && x - 1 < 0 && y - 1 < 0)
            {
                if (matrix[y + 1][x] == -1 && matrix[y][x + 1] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 < n && y + 1 < n && x - 1 < 0 && y - 1 >= 0)
            {
                if (matrix[y + 1][x] == -1 && matrix[y][x + 1] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 < n && y + 1 == n && x - 1 < 0 && y - 1 >= 0)
            {
                if (matrix[y][x + 1] == -1 && matrix[y - 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 < n && y + 1 == n && x - 1 >= 0 && y - 1 >= 0)
            {
                if (matrix[y][x + 1] == -1 && matrix[y - 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x++;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 == n && y + 1 == n && x - 1 >= 0 && y - 1 >= 0)
            {
                if (matrix[y][x - 1] != -1 && matrix[y - 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 == n && y + 1 < n && x - 1 >= 0 && y - 1 >= 0)
            {
                if (matrix[y][x - 1] != -1 && matrix[y - 1][x] == -1)
                {
                    matrix[y][x] = num;
                    num++;
                    y--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            else if (x + 1 == n && y + 1 < n && x - 1 >= 0 && y - 1 < 0)
            {
                if (matrix[y][x - 1] == -1 && matrix[y + 1][x] != -1)
                {
                    matrix[y][x] = num;
                    num++;
                    x--;
                    matrix = GetLocation(matrix, x, y, n, num);
                    return matrix;
                }
            }
            return matrix;
        }
        public static void Task_L_12_ToSolutin()
        {
            Console.WriteLine("Задача L.Заполнение спиралью");
            Console.WriteLine("Введите нечетное число");
            int n = int.Parse(Console.ReadLine());
            int center = n / 2;
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int k = 0; k < n; k++)
                {
                    matrix[i][k] = -1;
                }
            }
            matrix[center][center] = 0;
            int x = center + 1;
            int y = center;
            matrix = GetLocation(matrix, x, y, n, 1);
            PrintMatrix(matrix);
        }

        private static int[][] GetNum(int[][] matrix, int x, int y, int n, int height)
        {
            int[] line = new int[height];
            for (int i = 0; i < height; i++)
            {
                line[i] = matrix[i][x];
            }
            if (Array.IndexOf(matrix[y], n) == -1 && Array.IndexOf(line, n) == -1)
            {
                matrix[y][x] = n;
            }
            else
            {
                n++;
                matrix = GetNum(matrix, x, y, n, height);
            }
            return matrix;
        }

        public static void Task_M_13_ToSolutin()
        {
            Console.WriteLine("Задача M. Магический квадрат");
            Console.WriteLine("Введите магическое число");
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int k = 0; k < n; k++)
                {
                    matrix[i][k] = 0;
                }
            }
            int h = 0;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    h = 0;
                    matrix = GetNum(matrix, k, i, h, n);
                }
            }
            PrintMatrix(matrix);
        }

        private static int[,] Input(int n)
        {
            int[,] a = new int[n, n];
            int[][] matrix = ReadMatrixInt(n, n);
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                {
                    a[i, j] = matrix[i][j];
                }
            return a;
        }

        private static bool Semetr(int[,] a)
        {
            bool symm = true;
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                    if (a[i, j] != a[j, i])
                    {
                        symm = false;
                        break;
                    }
                if (!symm) break;
            }
            return symm;
        }

        public static void Task_N_14_ToSolutin()
        {
            Console.WriteLine("Задача N. Симметричная ли матрица?");
            Console.Write("Введите размерность массива\nn = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Заполните матрицу {n}*{n}");
            int[,] a = Input(n); //тут заполняяем

            if (Semetr(a))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }

        public static void Task_O_15_ToSolutin()
        {
            Console.WriteLine("Задача O. Судоку");
            Console.WriteLine("Введите матрицу 9 * 8");
            int[][] matrix = ReadMatrixInt(9, 9);
            int[][] otvet = new int[9][];
            int[] line = new int[9];
            bool flag = true;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    line[k] = matrix[k][i];
                }
                otvet[i] = line;
            }
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    if (Array.IndexOf(matrix[i], k + 1) == -1 || Array.IndexOf(otvet[i], k + 1) == -1)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public static string GetZnath(string[][] matrix, int x, int y, int n, int m) 
        {
            string[] array = new string[8];
            int num = 0;
            if (x > 0 && y > 0 && x < n - 1 && y < m - 1)
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[8] { matrix[y - 1][x], matrix[y - 1][x + 1], matrix[y][x + 1], matrix[y + 1][x + 1], matrix[y + 1][x], matrix[y + 1][x - 1], matrix[y][x - 1], matrix[y - 1][x - 1] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x > 0 && y == 0 && x < n - 1 && y < m - 1)
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[5] {  matrix[y][x + 1], matrix[y + 1][x + 1], matrix[y + 1][x], matrix[y + 1][x - 1], matrix[y][x - 1]};
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x > 0 && y > 0 && x < n - 1 && y == m - 1)
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[5] { matrix[y - 1][x], matrix[y - 1][x + 1], matrix[y][x + 1], matrix[y][x - 1], matrix[y - 1][x - 1] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x > 0 && y > 0 && x == n - 1 && y < m - 1)
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[5] { matrix[y - 1][x], matrix[y + 1][x], matrix[y + 1][x - 1], matrix[y][x - 1], matrix[y - 1][x - 1] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x == 0 && y > 0 && x < n - 1 && y < m - 1)
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[5] { matrix[y - 1][x], matrix[y - 1][x + 1], matrix[y][x + 1], matrix[y + 1][x + 1], matrix[y + 1][x], };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x == 0 && y == 0 ) 
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[3] { matrix[y][x+1], matrix[y+1][x+1], matrix[y+1][x] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x == n-1 && y == m -1 )
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[3] { matrix[y][x - 1], matrix[y - 1][x - 1], matrix[y - 1][x] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x == n-1 && y == 0 )
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[3] { matrix[y][x - 1], matrix[y + 1][x - 1], matrix[y + 1][x] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            else if (x == 0 && y == m -1 )
            {
                if (matrix[y][x] != "*")
                {
                    array = new string[3] { matrix[y][x + 1], matrix[y - 1][x + 1], matrix[y - 1][x] };
                    foreach (string i in array)
                    {
                        if (i == "*")
                        {
                            num++;
                        }
                    }
                    return num.ToString();
                }
                return "*";
            }
            return "__";
        }

        public static void Task_P_16_ToSolutin()
        {
            Console.WriteLine("Задача P. Сапер");
            int[] condition = ReadCondition();
            int n = condition[0];
            int m = condition[1];
            int k = condition[2];
            int[][] matrix = new int[k][];
            string[] arg = new string[2];
            for (int i = 0; i < k; i++)
            {
                arg = Console.ReadLine().Split(' ');
                matrix[i] = new int[2] { int.Parse(arg[0]) - 1, int.Parse(arg[1]) - 1 };
            }
            string[][] pole = new string[n][];
            for (int i = 0; i < n; i++)
            {
                pole[i] = new string[m];
            }
            foreach (int[] item in matrix)
            {
                pole[item[0]][item[1]] = "*";
            }
            for (int i = 0; i < n; i++)
            {
                for (int h = 0; h < m; h++)
                {
                    pole[i][h] = GetZnath(pole, h, i, m, n);
                }
            }
            PrintMatrix(pole);
        }

        private static int[][] Multiplication(int[][] matrix, int line, int num)
        {
            int lenLine = matrix[line].Count();
            int[] newLine = new int[lenLine];
            for (int i = 0; i < lenLine; i++)
            {
                newLine[i] = matrix[line][i] * num;
            }
            matrix[line] = newLine;
            return matrix;
        }

        private static int[][] MovingLine(int[][] matrix, int line1, int line2)
        {
            int[] newLine = matrix[line2];
            matrix[line2] = matrix[line1];
            for (int i = 0; i < newLine.Count(); i++)
            {
                newLine[i] = -newLine[i];
            }
            matrix[line1] = newLine;
            return matrix;
        }

        private static int[][] DifferenceLine(int[][] matrix, int line1, int line2)
        {
            for (int i = 0; i < matrix[0].Count(); i++)
            {
                matrix[line1][i] -= matrix[line2][i];
            }
            return matrix;
        }


        public static void Task_R_18_ToSolutin()
        {
            Console.WriteLine("Задача R. Матрица");
            Console.WriteLine("Введите высоту и ширену через enter");
            int height = int.Parse(Console.ReadLine());
            int weight = int.Parse(Console.ReadLine());
            int[][] matrix = new int[height][];
            string[] strings = new string[weight];
            int[] line = new int[weight];
            Console.WriteLine($"Заполните матрицу размерами {height} * {weight}");
            matrix = ReadMatrixInt(height, weight);
            bool indef = false;
            int selected_variation;
            int numLine;
            int num;
            string text = "Все операции выполняются для обновленной матрицы!!!";
            while (indef != true)
            {
                Console.WriteLine("Выберите операцию согласно ее носеру\n" +
                    "1 - умножение строки на число альфа\n" +
                    "2 - вычитание строки i из строки j\n" +
                    "3 - перестановка строк i,j\n" +
                    "4 - выход");
                selected_variation = int.Parse(Console.ReadLine());
                Console.WriteLine(text.ToUpper());
                switch (selected_variation)
                {
                    case 1:
                        Console.WriteLine("Введите номер строки");
                        numLine = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите множитель");
                        num = int.Parse(Console.ReadLine());
                        PrintMatrix(Multiplication(matrix, numLine - 1, num));
                        continue;
                    case 2:
                        Console.WriteLine("Введите номер вычитаемой строки");
                        numLine = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите номер уменьшаемой строки");
                        num = int.Parse(Console.ReadLine());
                        PrintMatrix(DifferenceLine(matrix, num - 1, numLine - 1));
                        continue;
                    case 3:
                        Console.WriteLine("Введите номер первой строки");
                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите номер второй строки");
                        numLine = int.Parse(Console.ReadLine());
                        PrintMatrix(MovingLine(matrix, num - 1, numLine - 1));
                        continue;
                    case 4:
                        indef = true;
                        continue;
                }
            }
        }
    }
}
