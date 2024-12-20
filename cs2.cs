using System;
using System.Linq;
using System.Data;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();
    }

    static void Task1()
    {
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Введіть 5 чисел для масиву A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Заповнення масиву B випадковими числами:");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = rand.NextDouble() * 100;
            }
        }
        Console.WriteLine("Масив A: " + string.Join(" ", A));
        Console.WriteLine("Масив B:");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.Write($"{B[i, j]:F2} ");
            }
            Console.WriteLine();
        }
        double max = Math.Max(A.Max(), B.Cast<double>().Max());
        double min = Math.Min(A.Min(), B.Cast<double>().Min());
        double sum = A.Sum() + B.Cast<double>().Sum();
        double product = A.Aggregate(1, (acc, x) => acc * x) * B.Cast<double>().Aggregate(1.0, (acc, x) => acc * x);
        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Мінімальний елемент: {min}");
        Console.WriteLine($"Сума всіх елементів: {sum}");
        Console.WriteLine($"Добуток всіх елементів: {product}");
        int evenSumA = A.Where(x => x % 2 == 0).Sum();
        Console.WriteLine($"Сума парних елементів масиву A: {evenSumA}");
        double oddColumnSumB = 0;
        for (int j = 0; j < B.GetLength(1); j += 2)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                oddColumnSumB += B[i, j];
            }
        }
        Console.WriteLine($"Сума елементів непарних стовпців масиву B: {oddColumnSumB}");
    }
    static void Task2()
    {
        int[,] array = new int[5, 5];
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = rand.Next(-100, 101);
            }
        }
        Console.WriteLine("Масив 5x5:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
        int min = array.Cast<int>().Min();
        int max = array.Cast<int>().Max();
        int minIndex = Array.IndexOf(array.Cast<int>().ToArray(), min);
        int maxIndex = Array.IndexOf(array.Cast<int>().ToArray(), max);
        int sum = 0;
        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);
        for (int i = start + 1; i < end; i++)
        {
            sum += array.Cast<int>().ToArray()[i];
        }
        Console.WriteLine($"Сума елементів між мінімальним і максимальним: {sum}");
    }
    static void Task3()
    {
        Console.Write("Введіть рядок для шифрування: ");
        string input = Console.ReadLine();
        Console.Write("Введіть зміщення для шифрування: ");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = CaesarCipher(input, shift);
        Console.WriteLine($"Зашифрований рядок: {encrypted}");

        string decrypted = CaesarCipher(encrypted, -shift);
        Console.WriteLine($"Розшифрований рядок: {decrypted}");
    }
    static string CaesarCipher(string input, int shift)
    {
        return new string(input.Select(c => {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                return (char)((c + shift - offset + 26) % 26 + offset);
            }
            return c;
        }).ToArray());
    }
    static void Task4()
    {
        int[,] matrix1 = {
            {1, 2},
            {3, 4}
        };
        int[,] matrix2 = {
            {5, 6},
            {7, 8}
        };
        int number = 2;

        Console.WriteLine("Множення матриці на число:");
        PrintMatrix(MultiplyMatrixByNumber(matrix1, number));

        Console.WriteLine("Додавання матриць:");
        PrintMatrix(AddMatrices(matrix1, matrix2));

        Console.WriteLine("Добуток матриць:");
        PrintMatrix(MultiplyMatrices(matrix1, matrix2));
    }
    static int[,] MultiplyMatrixByNumber(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }
        return result;
    }
    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }
    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    static void Task5()
    {
        Console.Write("Введіть арифметичний вираз (+, -): ");
        string expression = Console.ReadLine();

        var result = new DataTable().Compute(expression, null);
        Console.WriteLine($"Результат: {result}");
    }
    static void Task6()
    {
        Console.Write("Введіть текст: ");
        string input = Console.ReadLine();

        string result = CapitalizeSentences(input);
        Console.WriteLine($"Результат: {result}");
    }
    static string CapitalizeSentences(string input)
    {
        string[] sentences = input.Split(new[] { ". " }, StringSplitOptions.None);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Length > 0)
            {
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
            }
        }
        return string.Join(". ", sentences);
    }
    static void Task7()
    {
        Console.Write("Введіть текст: ");
        string text = Console.ReadLine();

        Console.Write("Введіть неприпустиме слово: ");
        string forbiddenWord = Console.ReadLine();

        string censoredText = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
        int count = (text.Length - censoredText.Length) / forbiddenWord.Length;

        Console.WriteLine($"Цензурований текст: {censoredText}");
        Console.WriteLine($"Кількість замін: {count}");
    }
}