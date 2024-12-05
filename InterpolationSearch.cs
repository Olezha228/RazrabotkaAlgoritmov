using System;

namespace RazrabotkaAlgoritmov;

public class InterpolationSearch
{
    // Метод для выполнения интерполяционного поиска
    public static int Search(int[] array, int target)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high && target >= array[low] && target <= array[high])
        {
            // Вычисляем позицию для интерполяционного поиска
            int pos = low + ((target - array[low]) * (high - low)) / (array[high] - array[low]);

            // Проверяем, находится ли элемент по вычисленной позиции
            if (array[pos] == target)
                return pos; // Элемент найден, возвращаем его индекс

            // Если целевой элемент больше, ищем в правой части
            if (array[pos] < target)
                low = pos + 1;
            // Если целевой элемент меньше, ищем в левой части
            else
                high = pos - 1;
        }

        return -1; // Элемент не найден
    }

    public static void Main(string[] args)
    {
        int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90 }; // Отсортированный массив
        int target = 30; // Элемент для поиска

        int result = Search(numbers, target); // Выполняем поиск

        if (result != -1)
            Console.WriteLine($"Элемент {target} найден на индексе {result}.");
        else
            Console.WriteLine($"Элемент {target} не найден в массиве.");
    }
}
