using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        bool programRunning = true;

        while (programRunning)
        {
            Console.WriteLine("------МЕНЮ------");
            Console.WriteLine("1 -- Игра \"Отгадай ответ\"\n" +
                          "2 -- Об авторе\n" +
                          "3 -- Сортировка массива\n" +
                          "4 -- Выход");
            Console.WriteLine("Введите цифру для выбора действия");
            int key;
            while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > 4)
            {
                Console.WriteLine("Введите корректное значение!");
            }

            switch (key)
            {
                case 1:
                    PlayGame();
                    break;

                case 2:
                    InfoAboutAuthor();
                    break;

                case 3:
                    int length = LengthArray();
                    int[] array = MakeArray(length);

                    PrintArray(array);
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    int[] sortArray1 = CopyArray(array);
                    BubbleSort(sortArray1);
                    stopWatch.Stop();

                    long sortTime1 = stopWatch.ElapsedMilliseconds;
                    Console.WriteLine($"Время выполнения сортировки пузырьком: {sortTime1} мс");
                    PrintArray(sortArray1);

                    stopWatch.Reset();
                    stopWatch.Start();
                    int[] sortArray2 = CopyArray(array);
                    InsertionSort(sortArray2);
                    stopWatch.Stop();
                     
                    long sortTime2 = stopWatch.ElapsedMilliseconds;
                    Console.WriteLine($"Время выполнения сортировки вставками: {sortTime2} мс" );
                    PrintArray(sortArray2);
                    break;

                case 4:
                    programRunning = ConfirmExit();
                    break;
            }
        }
    }

    static double EnterNum()
    {
        double num;
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Введите корректное число");
        }
        return num;
    }

    static void PlayGame()
    {
        Console.WriteLine("Игра\"Отгадай ответ\"");
        double a, b;

        Console.Write("Введите число a: ");
        a = EnterNum();

        Console.Write("Введите число b: ");
        b = EnterNum();

        double result = CalculateFunction(a, b);
        double roundedResult = Math.Round(result, 2);
        Guessed(roundedResult);

    static void Guessed(double correctAnswer)
    {
        int attempts = 3;
        bool guessed = false;
        double roundedResult = Math.Round(correctAnswer, 2);

        Console.WriteLine("Результат функции округлен до 2 знаков после запятой");

        while (attempts > 0)
        {
            Console.Write($"Введите ваш ответ (осталось попыток: {attempts}): ");
            double userAnswer;

            while (!double.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Введите корректное число!");
            }

            double roundedUserAnswer = Math.Round(userAnswer, 2);

            if (roundedResult == roundedUserAnswer)
            {
                Console.WriteLine("Ответ верный!");
                guessed = true;
                attempts = 0;
            }
            else
            {
                Console.WriteLine("Ответ неверный!");
                attempts--;
            }
        }

        if (!guessed)
        {
            Console.WriteLine($"Вы проиграли! Правильный ответ: {roundedResult}");
        }
    }

}


    static double CalculateFunction(double a, double b)
    {
        double e = Math.E;
        double dividend = Math.Sin(a) + Math.Tan(2 * a);
        double divisor = Math.Sqrt(Math.Log(Math.Pow(e, 2), 3));

        return dividend / divisor;
    }

    static void InfoAboutAuthor()
    {
        Console.WriteLine("--Информация об авторе--");
        Console.WriteLine("ФИО: Горбаконенко Полина Максимовна");
        Console.WriteLine("Группа: 6102 - 090301D");
    }

    static bool ConfirmExit()
    {
        Console.WriteLine("Вы уверены, что хотите выйти?(д/н)");

        char confirmKey = Console.ReadKey().KeyChar;
        Console.WriteLine();

        while (confirmKey != 'д' && confirmKey != 'н')
        {
            Console.WriteLine("Ошибка! Введите 'д' для выхода или 'н' для отмены");
            confirmKey = Console.ReadKey().KeyChar;
            Console.WriteLine();
            confirmKey = char.ToLower(confirmKey);
        }

        if (confirmKey == 'д')
        {
            Console.WriteLine("Программа завершена");
            return false;
            
        }
        else
        {
            Console.WriteLine("Выход отменен");
        }
        return true;
    }

    static int LengthArray()
    {
        int length;
        Console.Write("Введите длину массива: ");
        while (!int.TryParse(Console.ReadLine(), out length) || length == 0)
        {
            Console.WriteLine("Ошибка! Введите корректное значение массива: ");
        }
        return length;
    }


    static int[] MakeArray(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = new Random().Next(1, 100);
        }
        return array;
    }

    static int[] CopyArray(int[] array)
    {
        int[] copyOfArray = new int[array.Length];
        foreach (int i in array)
        {
            copyOfArray[i] = array[i];
        }
        return copyOfArray;  
    }

    static void PrintArray(int[] array)
    {
        if (array.Length <= 10)
        {
            foreach (int num in array)
                Console.WriteLine(num);
        }
        else
        {
            Console.WriteLine("Массив нельзя вывести на экран, так как его длина больше 10");
        }
    }

    static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
    }
    static void InsertionSort(int[] array)
    {

        for (int i = 1; i < array.Length; i++)
        {
            int k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > k)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = k;
        }
    }
}


        

    