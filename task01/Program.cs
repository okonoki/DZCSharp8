// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int GetNumber(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] FillArray(int row, int column, int min, int max)
{
    int[,] array = new int[row, column];
    Random rnd = new Random()!;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(min, max);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] SortArray(int[,] array)
{
    for (int k = 1; k < array.GetLength(1); k++) // k = 0
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1) - k; j++) // - 1 - k
            {
                if (array[i, j] < array[i, j + 1])
                {
                    int temp = array[i, j];
                    array[i, j] = array[i, j + 1];
                    array[i, j + 1] = temp;
                }
            }
        }
    }
    return array;
}

int row = GetNumber("Введите число строк массива: ");
int column = GetNumber("Введите число столбцов массива: ");
int min = GetNumber("Введите наименьшее значение массива: ");
int max = GetNumber("Введите наибольшее значение массива: ");
Console.WriteLine();
int[,] array = FillArray(row, column, min, max);
PrintArray(array);
Console.WriteLine();
int[,] resArray = SortArray(array);
PrintArray(resArray);