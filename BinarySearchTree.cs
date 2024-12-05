using System;

namespace RazrabotkaAlgoritmov;

// Класс для представления узла дерева
class Node
{
    public int item; // Значение узла
    public Node leftc; // Левый дочерний узел
    public Node rightc; // Правый дочерний узел

    // Метод для отображения значения узла
    public void Display()
    {
        Console.Write("[" + item + "]");
    }
}

// Класс для представления бинарного поискового дерева
class Tree
{
    public Node root; // Корень дерева

    // Конструктор, инициализирующий корень как null
    public Tree()
    {
        root = null;
    }

    // Метод для получения корня дерева
    public Node ReturnRoot()
    {
        return root;
    }

    // Метод для вставки нового значения в дерево
    public void Insert(int id)
    {
        Node newNode = new Node(); // Создаем новый узел
        newNode.item = id; // Устанавливаем значение узла

        if (root == null) // Если дерево пустое, новый узел становится корнем
            root = newNode;
        else
        {
            Node current = root; // Начинаем с корня
            Node parent; // Переменная для хранения родительского узла

            while (true)
            {
                parent = current; // Сохраняем текущий узел как родительский
                if (id < current.item) // Если значение меньше, идем в левое поддерево
                {
                    current = current.leftc;
                    if (current == null) // Если достигли конца, вставляем новый узел здесь
                    {
                        parent.leftc = newNode;
                        return;
                    }
                }
                else // Иначе идем в правое поддерево
                {
                    current = current.rightc;
                    if (current == null) // Если достигли конца, вставляем новый узел здесь
                    {
                        parent.rightc = newNode;
                        return;
                    }
                }
            }
        }
    }

    // Метод для обхода дерева в порядке предварительного обхода (preorder)
    public void Preorder(Node Root)
    {
        if (Root != null) // Проверяем, не является ли узел null
        {
            Console.Write(Root.item + " "); // Сначала выводим значение текущего узла
            Preorder(Root.leftc); // Рекурсивно обходим левое поддерево
            Preorder(Root.rightc); // Рекурсивно обходим правое поддерево
        }
    }

    // Метод для обхода дерева в порядке симметричного обхода (inorder)
    public void Inorder(Node Root)
    {
        if (Root != null) // Проверяем, не является ли узел null
        {
            Inorder(Root.leftc); // Рекурсивно обходим левое поддерево
            Console.Write(Root.item + " "); // Затем выводим значение текущего узла
            Inorder(Root.rightc); // Рекурсивно обходим правое поддерево
        }
    }

    // Метод для обхода дерева в порядке посторного обхода (postorder)
    public void Postorder(Node Root)
    {
        if (Root != null) // Проверяем, не является ли узел null
        {
            Postorder(Root.leftc); // Рекурсивно обходим левое поддерево
            Postorder(Root.rightc); // Рекурсивно обходим правое поддерево
            Console.Write(Root.item + " "); // Затем выводим значение текущего узла
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Tree theTree = new Tree(); // Создаем новое дерево

        // Вставляем элементы в BST
        theTree.Insert(20);
        theTree.Insert(25);
        theTree.Insert(15);
        theTree.Insert(10);
        theTree.Insert(30);

        Console.WriteLine("Inorder Traversal : ");
        theTree.Inorder(theTree.ReturnRoot()); // Симметричный обход дерева (inorder)
        Console.WriteLine();

        Console.WriteLine("Preorder Traversal : ");
        theTree.Preorder(theTree.ReturnRoot()); // Предварительный обход дерева (preorder)
        Console.WriteLine();

        Console.WriteLine("Postorder Traversal : ");
        theTree.Postorder(theTree.ReturnRoot()); // Посторный обход дерева (postorder)
        Console.WriteLine();

        Console.ReadLine(); // Ожидаем ввода пользователя перед завершением программы
    }
}
