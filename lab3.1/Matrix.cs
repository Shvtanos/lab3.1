using System;

namespace lab3._1
{
    internal class Matrix
    {
        private int[,] array;

        // Конструктор для ввода массива с клавиатуры (задание 1)
        public Matrix(int n, int m)
        {
            array = new int[n, m];
            Console.WriteLine("Введите элементы массива построчно:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = InputInteger($"Элемент [{i},{j}]: ");
                }
            }
        }

        // Конструктор для создания массива с шахматным заполнением случайными числами (задание 2)
        public Matrix(int n, bool chessPattern)
        {
            array = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool isBlackCell = (i + j) % 2 == 0;
                    int randomValue;
                    do
                    {
                        randomValue = rand.Next(1, 101); // случайное число от 1 до 100
                    } while (isBlackCell ? randomValue % 2 != 0 : randomValue % 2 == 0);

                    array[i, j] = randomValue;
                }
            }
        }

        // Конструктор для создания массива с диагональным заполнением (задание 3)
        public Matrix(int n)
        {
            array = new int[n, n];
            FillDiagonalPattern(n);
        }

        // Метод для заполнения диагонального массива
        private void FillDiagonalPattern(int n)
        {
            int number = 1;

            // Заполняем массив по диагоналям, начиная с нижней левой части к верхней правой
            for (int startRow = n - 1; startRow >= 0; startRow--)
            {
                int row = startRow;
                int col = 0;
                while (row < n && col < n)
                {
                    array[row, col] = number++;
                    row++;
                    col++;
                }
            }

            // Продолжаем заполнение по диагоналям справа от главной диагонали
            for (int startCol = 1; startCol < n; startCol++)
            {
                int row = 0;
                int col = startCol;
                while (row < n && col < n)
                {
                    array[row, col] = 0;
                    row++;
                    col++;
                }
            }
        }

        // Метод для вычисления сумм столбцов (задание 2)
        public int[] GetColumnSums()
        {
            int cols = array.GetLength(1);
            int[] columnSums = new int[cols - 1];

            for (int j = 0; j < cols - 1; j++)
            {
                int sum = 0;
                for (int i = 0; i < array.GetLength(0) - j - 1; i++)
                {
                    sum += array[i, j];
                }
                columnSums[j] = sum;
            }
            return columnSums;
        }

        // Метод для нахождения максимальной суммы из массива столбцовых сумм
        public int MaxColumnSum()
        {
            int[] columnSums = GetColumnSums();
            int maxSum = int.MinValue;
            foreach (int sum in columnSums)
            {
                if (sum > maxSum)
                    maxSum = sum;
            }
            return maxSum;
        }

        // Перегрузка оператора + для сложения двух массивов
        public static Matrix operator +(Matrix a, Matrix b)
        {
            int n = a.array.GetLength(0);
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.array[i, j] = a.array[i, j] + b.array[i, j];
                }
            }
            return result;
        }

        // Перегрузка оператора * для умножения массива на число
        public static Matrix operator *(Matrix a, int scalar)
        {
            int n = a.array.GetLength(0);
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.array[i, j] = a.array[i, j] * scalar;
                }
            }
            return result;
        }

        // Перегрузка оператора - для вычитания массивов
        public static Matrix operator -(Matrix a, Matrix b)
        {
            int n = a.array.GetLength(0);
            Matrix result = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result.array[i, j] = a.array[i, j] - b.array[i, j];
                }
            }
            return result;
        }

        // Метод для транспонирования матрицы
        public Matrix Transpose()
        {
            int n = array.GetLength(0);
            Matrix transposed = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    transposed.array[j, i] = array[i, j];
                }
            }
            return transposed;
        }

        // Перегрузка метода ToString для вывода массива в виде таблицы
        public override string ToString()
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += array[i, j].ToString().PadLeft(3) + " ";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        // Основной метод для выполнения выражения (A + 4 * B) - C^T
        public static Matrix CalculateExpression(Matrix A, Matrix B, Matrix C)
        {
            return (A + B * 4) - C.Transpose();
        }

        // Вспомогательный метод для безопасного ввода целого числа
        public static int InputInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }
    }
}

