// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3

// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] MultMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] multMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    int sum = 0;
    for (int l = 0; l < matrix1.GetLength(0); l++)
    {
        for (int i = 0; i < matrix2.GetLength(1); i++)
        {
            for (int j = 0; j < matrix2.GetLength(0); j++)
            {
                sum += matrix1[l, j] * matrix2[j, i];
            }
            multMatrix[l, i] = sum;
            sum = 0;
        }
    }
    return multMatrix;
}

int row1 = GetNumber("Введите количество строк в первом массиве: ");
int column1 = GetNumber("Введите количество столбцов в первом массиве: ");
int min1 = GetNumber("Введите наименьшее значение первого массива: ");
int max1 = GetNumber("Введите наибольшее значение первого массива: ");

int row2 = GetNumber("Введите количество строк во втором массиве: ");
int column2 = GetNumber("Введите количество столбцов во втором массиве: ");
int min2 = GetNumber("Введите наименьшее значение второго массива: ");
int max2 = GetNumber("Введите наибольшее значение второго массива: ");
Console.WriteLine();

if (column1 != row2) Console.WriteLine("Число столбцов в первой матрице должно быть равно числу строк во второй матрице!");
else
{
    int[,] matrix1 = FillArray(row1, column1, min1, max1);
    PrintArray(matrix1);
    Console.WriteLine();
    int[,] matrix2 = FillArray(row2, column2, min2, max2);
    PrintArray(matrix2);
    Console.WriteLine();
    int[,] multMaitrix = MultMatrix(matrix1, matrix2);
    PrintArray(multMaitrix);
}