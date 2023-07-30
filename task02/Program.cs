// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int GetNumber(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] FillArray(int row, int column, int min, int max)
{
    int[,] array = new int[row, column];
    Random rnd = new Random()!;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
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

int[] SumArray(int[,] array)
{
    int sum = 0;
    int[] sumStr = new int[array.GetLength(0)];
    int index = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        sumStr[index] = sum;
        sum = 0;
        index++;
    }
    return sumStr;
}

void PrintData(int[] inArray)
{
    int index = 0;
    int min = inArray[0];
    for (int i = 1; i < inArray.Length; i++)
    {
        if (min > inArray[i])
        {
            min = inArray[i];
            index = i;
        }
    }
    Console.Write($"Cтрока с наименьшей суммой элементов ({min}): {index + 1}.");
}

int row = GetNumber("Введите количество строк в массиве: ");
int column = GetNumber("Введите количество столбцов в массиве: ");
int min = GetNumber("Введите наименьшее значение массива: ");
int max = GetNumber("Введите наибольшее значение массива: ");
Console.WriteLine();

if (row == column) Console.WriteLine("Длина и ширина массива не должны быть равны!");
else
{
    int[,] array = FillArray(row, column, min, max);
    PrintArray(array);
    Console.WriteLine();
    int[] sumArray = SumArray(array);
    Console.WriteLine(string.Join(" ", sumArray));
    PrintData(sumArray);
}