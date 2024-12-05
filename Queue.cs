using System;

public class Queue<T>
{
    private T[] elements;
    private int front;
    private int rear;
    private int capacity;
    private int count;

    public Queue(int size)
    {
        elements = new T[size];
        capacity = size;
        front = 0;
        rear = -1;
        count = 0;
    }

    // Добавление элемента в очередь
    public void Enqueue(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Очередь переполнена");
        }

        rear = (rear + 1) % capacity; // Циклическое смещение
        elements[rear] = item;
        count++;
    }

    // Удаление элемента из очереди
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста");
        }

        T item = elements[front];
        front = (front + 1) % capacity; // Циклическое смещение
        count--;
        return item;
    }

    // Получение элемента из начала очереди без удаления
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста");
        }
        
        return elements[front];
    }

    // Проверка, пуста ли очередь
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Проверка, полна ли очередь
    public bool IsFull()
    {
        return count == capacity;
    }

    // Получение количества элементов в очереди
    public int Size()
    {
        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>(5);

        // Добавление элементов в очередь
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        
        Console.WriteLine("Первый элемент в очереди: " + queue.Peek()); // 1

        Console.WriteLine("Удаляем элемент: " + queue.Dequeue()); // 1
        Console.WriteLine("Теперь первый элемент: " + queue.Peek()); // 2

        queue.Enqueue(4);
        queue.Enqueue(5);
        
        Console.WriteLine("Размер очереди: " + queue.Size()); // 3

        while (!queue.IsEmpty())
        {
            Console.WriteLine("Удаляем элемент: " + queue.Dequeue());
        }
        
        Console.WriteLine("Очередь пуста: " + queue.IsEmpty()); // True
    }
}
