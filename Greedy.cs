using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public int Number { get; set; }
    public int Weight { get; set; }
    public int Value { get; set; }
    public double ValueToWeightRatio => (double)Value / Weight;

    public Item(int number, int weight, int value)
    {
        Number = number;
        Weight = weight;
        Value = value;
    }
}

public class Program
{
    public static void Main()
    {
        // Считываем входные данные
        var firstLine = Console.ReadLine().Split(',');
        int n = int.Parse(firstLine[0]);
        int m = int.Parse(firstLine[1]);

        List<Item> items = new List<Item>();

        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split(',');
            int number = int.Parse(line[0]);
            int weight = int.Parse(line[1]);
            int value = int.Parse(line[2]);
            items.Add(new Item(number, weight, value));
        }

        // Вызываем жадный алгоритм
        var result = GetMaxValue(items, m);

        // Выводим результат
        Console.WriteLine(result.Item1);
        Console.WriteLine(string.Join(" ", result.Item2.OrderBy(x => x)));
    }

    private static (int, List<int>) GetMaxValue(List<Item> items, int maxWeight)
    {
        // Сортируем предметы по отношению ценности к весу
        var sortedItems = items.OrderByDescending(item => item.ValueToWeightRatio).ToList();
        
        int totalValue = 0;
        List<int> selectedItems = new List<int>();
        
        foreach (var item in sortedItems)
        {
            if (item.Weight <= maxWeight)
            {
                maxWeight -= item.Weight;
                totalValue += item.Value;
                selectedItems.Add(item.Number);
            }
        }

        return (totalValue, selectedItems);
    }
}
