// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int GetNumber(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[] GetArray(int[,,] array)
{
    int[] temp = new int[array.Length];
    for (int i = 0; i < array.Length; i++)
    {
        int randNumber = new Random().Next(10, 100);

        while (Contains(temp, randNumber))
        {
            randNumber = new Random().Next(10, 100);
        }
        temp[i] = randNumber;
    }
    return temp;
}

bool Contains(int[] temp, int randNumber)
{
    for (int i = 0; i < temp.Length; i++)
    {
        if (temp[i] == randNumber) return true;
    }
    return false;
}

int[,,] ReturnArray(int[] temp, int[,,] array)
{
    int index = 0;
    for (int x = 0; x < array.GetLength(0); x++)
    {
        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int z = 0; z < array.GetLength(2); z++)
            {
                array[x, y, z] = temp[index];
                index++;
            }
        }
    }
    return array;
}

void WriteArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"{array[i, j, k]} = ({i},{j},{k}); ");
            }
        }
    }
}

int row = GetNumber("Введите число строк в массиве: ");
int column = GetNumber("Введите число столбцов в массиве: ");
int page = GetNumber("Введите число страниц в массиве: ");

int[,,] array = new int[row, column, page];
int[] temp = GetArray(array);
Console.WriteLine(string.Join(" ", temp));
int[,,] array2 = ReturnArray(temp, array);
WriteArray(array2);