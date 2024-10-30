using lab3._1;

internal class Program
{
    private static void Main(string[] args)
    {
        // Задание 1: Ввод массива с клавиатуры
        Console.WriteLine("1. Введите размерность массива (n x m):");
        int n1 = Matrix.InputInteger("Введите количество строк (n): ");
        int m1 = Matrix.InputInteger("Введите количество столбцов (m): ");

        Matrix matrix1 = new Matrix(n1, m1);
        Console.WriteLine("Массив, введённый с клавиатуры:");
        Console.WriteLine(matrix1);

        // Задание 1: Шахматное заполнение случайными числами
        int n2 = Matrix.InputInteger("Введите размерность квадратного массива для шахматного заполнения (n x n): ");

        Matrix chessMatrix = new Matrix(n2, true);
        Console.WriteLine("Шахматный массив:");
        Console.WriteLine(chessMatrix);

        // Задание 1: Диагональное заполнение для произвольного n
        int n3 = Matrix.InputInteger("Введите размерность квадратного массива для диагонального заполнения (n x n): ");

        Matrix diagonalMatrix = new Matrix(n3);
        Console.WriteLine("Диагонально заполненный массив:");
        Console.WriteLine(diagonalMatrix);

        // Задание 2: Вычисление и вывод сумм столбцов по заданию 2
        int[] columnSums = chessMatrix.GetColumnSums();
        Console.WriteLine("2. Суммы столбцов матрицы - шахматный массив (с учётом уменьшения количества элементов):");
        for (int i = 0; i < columnSums.Length; i++)
        {
            Console.WriteLine($"Сумма столбца {i + 1}: {columnSums[i]}");
        }
        int maxColumnSum = chessMatrix.MaxColumnSum();
        Console.WriteLine($"Максимальная сумма среди всех сумм: {maxColumnSum}");

        // Вычисление выражения (A + 4 * B) - C^T с новыми массивами
        int n4 = Matrix.InputInteger("3. Введите размерность массивов для вычисления выражения (должна быть квадратная матрица n x n): ");

        Console.WriteLine("Введите элементы для массива A:");
        Matrix A = new Matrix(n4, n4);

        Console.WriteLine("Введите элементы для массива B:");
        Matrix B = new Matrix(n4, n4);

        Console.WriteLine("Введите элементы для массива C:");
        Matrix C = new Matrix(n4, n4);

        Matrix result = Matrix.CalculateExpression(A, B, C);
        Console.WriteLine("Результат выражения (A + 4 * B) - C^T:");
        Console.WriteLine(result);
    }
}
