using System;

public class CityDistanceCalculator
{
    private const int Infinity = int.MaxValue;

    public static void Main()
    {
        Console.Write("Введите количество городов: ");
        int n = int.Parse(Console.ReadLine());

        int[,] distances = new int[n, n];

        // Инициализация матрицы расстояний
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    distances[i, j] = 0; // Расстояние от города до самого себя равно 0
                }
                else
                {
                    distances[i, j] = Infinity; // Инициализация остальных расстояний как "бесконечность"
                }
            }
        }

        // Ввод расстояний между городами
        for (int k = 0; k < n - 1; k++)
        {
            Console.WriteLine($"Введите расстояния от города {k + 1} до остальных городов:");
            for (int j = k + 1; j < n; j++)
            {
                Console.Write($"Расстояние от города {k + 1} до города {j + 1}: ");
                int distance = int.Parse(Console.ReadLine());
                distances[k, j] = distances[j, k] = distance;
            }
        }

        // Вывод матрицы расстояний
        Console.WriteLine("Матрица расстояний:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{distances[i, j]}\t");
            }
            Console.WriteLine();
        }

        // Поиск минимального и максимального расстояния
        Console.Write("Введите номер первого города: ");
        int city1 = int.Parse(Console.ReadLine()) - 1; // -1, так как индексы массива начинаются с 0

        Console.Write("Введите номер второго города: ");
        int city2 = int.Parse(Console.ReadLine()) - 1; // -1, так как индексы массива начинаются с 0

        int minDistance = int.MaxValue;
        int maxDistance = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            if (distances[city1, i] != Infinity && distances[city2, i] != Infinity)
            {
                int distance = distances[city1, i] + distances[city2, i];
                minDistance = Math.Min(minDistance, distance);
                maxDistance = Math.Max(maxDistance, distance);
            }
        }

        Console.WriteLine($"Минимальное расстояние между городом {city1 + 1} и городом {city2 + 1}: {minDistance}");
        Console.WriteLine($"Максимальное расстояние между городом {city1 + 1} и городом {city2 + 1}: {maxDistance}");
    }
}
