using System;

namespace RazrabotkaAlgoritmov;

public class HeapSorter
{
    // Основной метод сортировки
    public static void Sort(int[] array)
    {
        int n = array.Length;

        // Построение кучи (перегруппировка массива)
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // Один за другим извлекаем элементы из кучи
        for (int i = n - 1; i >= 0; i--)
        {
            // Перемещаем текущий корень в конец массива
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            // Вызываем heapify на уменьшенной куче
            Heapify(array, i, 0);
        }
    }

    // Метод для преобразования подмассива в кучу
    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i; // Инициализируем корень как наибольший элемент
        int leftChild = 2 * i + 1; // Левый дочерний узел
        int rightChild = 2 * i + 2; // Правый дочерний узел

        // Если левый дочерний элемент больше корня
        if (leftChild < n && array[leftChild] > array[largest])
        {
            largest = leftChild;
        }

        // Если правый дочерний элемент больше наибольшего элемента
        if (rightChild < n && array[rightChild] > array[largest])
        {
            largest = rightChild;
        }

        // Если наибольший элемент не корень
        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            // Рекурсивно преобразуем затронутое поддерево в кучу
            Heapify(array, n, largest);
        }
    }

    public static void Main(string[] args)
    {
        int[] numbers = { 4, 10, 3, 5, 1 }; // Исходный массив
        Sort(numbers); // Сортировка массива

        Console.WriteLine(string.Join(", ", numbers)); // Вывод отсортированного массива: [1, 3, 4, 5, 10]
    }
}
