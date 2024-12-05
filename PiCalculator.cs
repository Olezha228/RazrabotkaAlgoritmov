using System;

namespace RazrabotkaAlgoritmov;

public class PiCalculator
{
    public static void Main(string[] args)
    {
        CalculatePi();
        CalculatePiWithAccuracy();
    }

    public static void CalculatePi()
    {
        int pointsInsideCircle = 0;
        int totalPoints = 10000;

        Random random = new Random(); // Инициализация генератора случайных чисел

        for (int i = 0; i < totalPoints; i++)
        {
            double x = -1.0 + (1.0 - (-1.0)) * random.NextDouble();
            double y = -1.0 + (1.0 - (-1.0)) * random.NextDouble();

            if ((x * x + y * y) <= 1.0)
                pointsInsideCircle++;
        }

        double estimatedPi = 4.0 * ((double)pointsInsideCircle / totalPoints);
        Console.WriteLine(estimatedPi);
    }

    public static void CalculatePiWithAccuracy()
    {
        double accuracy = 0.0000001;
        int pointsInsideCircle = 0;
        int totalPoints = 0;

        Random random = new Random(); // Инициализация генератора случайных чисел

        while (true)
        {
            double x = -1.0 + (1.0 - (-1.0)) * random.NextDouble();
            double y = -1.0 + (1.0 - (-1.0)) * random.NextDouble();
            totalPoints++;

            if ((x * x + y * y) <= 1.0)
                pointsInsideCircle++;

            double estimatedPi = 4.0 * ((double)pointsInsideCircle / totalPoints);

            if (Math.Abs(estimatedPi - Math.PI) <= accuracy)
            {
                Console.WriteLine(estimatedPi);
                break;
            }
        }
    }
}
