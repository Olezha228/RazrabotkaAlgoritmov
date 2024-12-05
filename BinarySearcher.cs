using System;

namespace RazrabotkaAlgoritmov;

public class BinarySearcher
{
    // Метод для выполнения двоичного поиска
    public static int Search(int[] array, int target)
    {
        int left = 0; // Начальный индекс
        int right = array.Length - 1; // Конечный индекс

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Находим средний индекс

            // Проверяем, равен ли элемент по среднему индексу искомому значению
            if (array[mid] == target)
            {
                return mid; // Элемент найден, возвращаем его индекс
            }
            else if (array[mid] < target)
            {
                left = mid + 1; // Ищем в правой части
            }
            else
            {
                right = mid - 1; // Ищем в левой части
            }
        }

        return -1; // Элемент не найден
    }

    public static void Main(string[] args)
    {
        int[] numbers = { 1, 3, 5, 7, 9, 11 }; // Отсортированный массив
        int target = 7; // Элемент для поиска

        int result = Search(numbers, target); // Выполняем поиск

        if (result != -1)
            Console.WriteLine($"Элемент {target} найден на индексе {result}.");
        else
            Console.WriteLine($"Элемент {target} не найден в массиве.");
    }
}
