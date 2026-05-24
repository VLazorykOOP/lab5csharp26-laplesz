using System;

namespace CombinedTasks
{
    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "Unknown";
            Age = 0;
            Console.WriteLine("Person: Default constructor");
        }

        public Person(string name)
        {
            Name = name;
            Age = 0;
            Console.WriteLine($"Person: Constructor with name ({name})");
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"Person: Constructor with basic parameters ({name}, {age})");
        }

        ~Person()
        {
            Console.WriteLine($"Person: Destructor of object {Name}");
        }

        public abstract void Show();
    }

    class Employee : Person
    {
        public string Position { get; set; }

        public Employee() : base()
        {
            Position = "Intern";
            Console.WriteLine("Employee: Default constructor");
        }

        public Employee(string name, int age) : base(name, age)
        {
            Position = "Employee";
            Console.WriteLine("Employee: Constructor with basic parameters");
        }

        public Employee(string name, int age, string position) : base(name, age)
        {
            Position = position;
            Console.WriteLine($"Employee: Constructor with complete data (Position: {position})");
        }

        ~Employee()
        {
            Console.WriteLine($"Employee: Destructor (Position: {Position})");
        }

        public override void Show()
        {
            Console.WriteLine($"[Employee] {Name}, {Age} years, Position: {Position}");
        }
    }

    class Worker : Person
    {
        public string Specialty { get; set; }

        public Worker() : base()
        {
            Specialty = "General laborer";
            Console.WriteLine("Worker: Default constructor");
        }
        public Worker(string name, int age) : base(name, age)
        {
            Specialty = "General";
            Console.WriteLine("Worker: Constructor with basic parameters");
        }
        public Worker(string name, int age, string specialty) : base(name, age)
        {
            Specialty = specialty;
            Console.WriteLine($"Worker: Constructor with complete data (Specialty: {specialty})");
        }

        ~Worker()
        {
            Console.WriteLine($"Worker: Destructor (Specialty: {Specialty})");
        }

        public override void Show()
        {
            Console.WriteLine($"[Worker] {Name}, {Age} years, Specialty: {Specialty}");
        }
    }

    class Engineer : Person
    {
        public string Specialization { get; set; }

        public Engineer() : base()
        {
            Specialization = "General engineering";
            Console.WriteLine("Engineer: Default constructor");
        }
        public Engineer(string name, int age) : base(name, age)
        {
            Specialization = "Junior engineer";
            Console.WriteLine("Engineer: Constructor with basic parameters");
        }
        public Engineer(string name, int age, string specialization) : base(name, age)
        {
            Specialization = specialization;
            Console.WriteLine($"Engineer: Constructor with complete data (Specialization: {specialization})");
        }

        ~Engineer()
        {
            Console.WriteLine($"Engineer: Destructor (Specialization: {Specialization})");
        }

        public override void Show()
        {
            Console.WriteLine($"[Engineer] {Name}, {Age} years, Specialization: {Specialization}");
        }
    }

    abstract class Function
    {
        public abstract double Calculate(double x);
        public abstract void PrintInfo(double x);
    }

    class Line : Function
    {
        public double A { get; set; }
        public double B { get; set; }

        public Line(double a, double b)
        {
            A = a;
            B = b;
        }

        public override double Calculate(double x)
        {
            return A * x + B;
        }

        public override void PrintInfo(double x)
        {
            double y = Calculate(x);
            Console.WriteLine($"Line:       y = {A}x + {B}");
            Console.WriteLine($"Result:     At x = {x}, y = {y}\n");
        }
    }

    class Quadratic : Function
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Quadratic(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Calculate(double x)
        {
            return A * x * x + B * x + C;
        }

        public override void PrintInfo(double x)
        {
            double y = Calculate(x);
            Console.WriteLine($"Quadratic: y = {A}x^2 + {B}x + {C}");
            Console.WriteLine($"Result:    At x = {x}, y = {y}\n");
        }
    }

    class Hyperbola : Function
    {
        public double K { get; set; }

        public Hyperbola(double k)
        {
            K = k;
        }

        public override double Calculate(double x)
        {
            if (x == 0)
            {
                return double.NaN;
            }
            return K / x;
        }

        public override void PrintInfo(double x)
        {
            Console.WriteLine($"Hyperbola:   y = {K}/x");

            if (x == 0)
            {
                Console.WriteLine($"Result:   At x = {x}, value is UNDEFINED (division by zero!)\n");
            }
            else
            {
                double y = Calculate(x);
                Console.WriteLine($"Result:   At x = {x}, y = {y}\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Task 1");
                Console.WriteLine("2. Task 2");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect a task (0-2): ");

                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Program terminated.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 0, 1, or 2.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                }
            }
        }

        static void RunTask1()
        {
            Person[] staff = new Person[9];

            Console.WriteLine("--- 1. Employee (default) ---");
            staff[0] = new Employee();

            Console.WriteLine("\n--- 2. Employee (partial) ---");
            staff[1] = new Employee("Olena", 22);

            Console.WriteLine("\n--- 3. Employee (full) ---");
            staff[2] = new Employee("Oleksandr", 30, "Director");

            Console.WriteLine("\n--- 4. Worker (default) ---");
            staff[3] = new Worker();

            Console.WriteLine("\n--- 5. Worker (partial) ---");
            staff[4] = new Worker("Ivan", 25);

            Console.WriteLine("\n--- 6. Worker (full) ---");
            staff[5] = new Worker("Petro", 45, "Welder");

            Console.WriteLine("\n--- 7. Engineer (default) ---");
            staff[6] = new Engineer();

            Console.WriteLine("\n--- 8. Engineer (partial) ---");
            staff[7] = new Engineer("Maria", 27);

            Console.WriteLine("\n--- 9. Engineer (full) ---");
            staff[8] = new Engineer("Hanna", 28, "Programmer");

            Array.Sort(staff, (p1, p2) => p1.Age.CompareTo(p2.Age));

            Console.WriteLine("\n\n=== List of created staff (Sorted by age) ===\n");
            foreach (var p in staff)
            {
                p.Show();
            }

            Console.WriteLine("\n=== End of method (objects go out of scope) ===");

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static void RunTask2()
        {
            double x = 2.5;

            Console.WriteLine($"=== Calculating function values at x = {x} ===\n");

            Function[] functions = new Function[]
            {
                new Line(2, -3),
                new Line(-1.5, 5),
                new Quadratic(1, -4, 4),
                new Quadratic(-2, 0, 10),
                new Hyperbola(5),
                new Hyperbola(-10)
            };

            foreach (var func in functions)
            {
                func.PrintInfo(x);
            }
        }
    }
}