// Напишите программу, которая заполнит спирально массив 4 на 4.

// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int GetNumber(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] FillArray(int row, int column)
{
    int[,] array = new int[row, column];
    int k = 1;
    int iBegin = 0;
    int iEnd = 0;
    int jBegin = 0;
    int jEnd = 0;
    int i = 0;
    int j = 0;
    while (k <= row * column)
    {
        array[i, j] = k;

        if (i == iBegin && j < column - 1 - jEnd) j++;
        else if (j == column - 1 - jEnd && i < row - 1 - iEnd) i++;
        else if (i == row - 1 - jEnd && j > jBegin) j--;
        else if (j == jBegin && i > iBegin) i--; 

        if (i == iBegin + 1 && j == jBegin)
        {
            ++iBegin;
            ++iEnd;
            ++jBegin;
            ++jEnd;
        }
        
        k++;
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] / 10 == 0 ) Console.Write($"0{array[i, j]} ");
            else Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int row = GetNumber("Введите количество строк в массиве: ");
int column = GetNumber("Введите количество столбцов в массиве: ");

int[,] array = FillArray(row, column);
PrintArray(array);