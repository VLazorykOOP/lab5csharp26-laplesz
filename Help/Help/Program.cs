using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ТЕСТУВАННЯ КЛАСУ TRIANGLE ===\n");

        try
        {
            Console.WriteLine("--- 1. Створення та базові методи ---");
            Triangle t1 = new Triangle(3, 4, 5, 1);
            Console.WriteLine($"Створено трикутник t1:\n{t1}\n");

            Console.WriteLine("--- 2. Робота з індексатором ---");
            Console.WriteLine($"Значення t1[0] (сторона a): {t1[0]}");
            Console.WriteLine($"Значення t1[3] (колір): {t1[3]}");

            t1[0] = 6;
            t1[1] = 8;
            t1[2] = 10;
            Console.WriteLine($"Після зміни сторін через індексатор:\n{t1}\n");

            Console.WriteLine("--- 3. Перевантаження операторів ---");
            Console.WriteLine($"Після операції t1++:\n{t1}");

            Triangle t2 = t1 * 2;
            Console.WriteLine($"Новий трикутник t2 (результат t1 * 2):\n{t2}\n");

            Console.WriteLine("--- 4. Перевірка на true / false ---");
            if (t2)
            {
                Console.WriteLine("-> Трикутник t2 існує (спрацював оператор true).");
            }

            t2[0] = 1000;
            if (t2) { }
            else
            {
                Console.WriteLine($"-> Трикутник t2 став недійсним після зміни сторони! (спрацював оператор false)");
            }
            Console.WriteLine();

            Console.WriteLine("--- 5. Перетворення типів ---");
            string strTriangle = t1;
            Console.WriteLine($"Неявне перетворення t1 у рядок:\n{strTriangle}\n");

            Triangle t3 = (Triangle)"5, 12, 13, 9";
            Console.WriteLine($"Явне перетворення з рядка '5, 12, 13, 9':\n{t3}\n");

            Console.WriteLine("--- 6. Обробка помилок ---");
            Console.WriteLine("Спроба створити неможливий трикутник зі сторонами (1, 1, 10)...");

            Triangle invalidTriangle = new Triangle(1, 1, 10, 2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\n[ПОМИЛКА АРГУМЕНТУ]: {ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"\n[ПОМИЛКА ІНДЕКСУ]: {ex.Message}");
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"\n[ПОМИЛКА ПЕРЕТВОРЕННЯ]: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[НЕВІДОМА ПОМИЛКА]: {ex.Message}");
        }

        Console.WriteLine("\nТестування завершено. Натисніть Enter...");
        Console.ReadLine();
    }
}