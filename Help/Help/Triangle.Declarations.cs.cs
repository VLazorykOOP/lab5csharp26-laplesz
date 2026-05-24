using System;

public sealed partial class Triangle
{
    private int a, b, c;
    private int color;

    public Triangle(int a, int b, int c, int color)
    {
        if (IsValid(a, b, c))
        {
            this.a = a; this.b = b; this.c = c;
            this.color = color;
        }
        else throw new ArgumentException($"Triangle with sides ({a}, {b}, {c}) cannot exist.");
    }

    public int Color => color;

    private static partial bool IsValid(int a, int b, int c);
    public partial int CalculatePerimeter();
    public partial double CalculateArea();

    public int this[int index]
    {
        get => index switch
        {
            0 => a,
            1 => b,
            2 => c,
            3 => color,
            _ => throw new IndexOutOfRangeException("Індекс має бути від 0 до 3.")
        };
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                case 3: color = value; break;
                default: throw new IndexOutOfRangeException("Індекс має бути від 0 до 3.");
            }
        }
    }

    public static Triangle operator ++(Triangle t) => new Triangle(t.a + 1, t.b + 1, t.c + 1, t.color);
    public static Triangle operator --(Triangle t) => new Triangle(t.a - 1, t.b - 1, t.c - 1, t.color);
    public static bool operator true(Triangle t) => IsValid(t.a, t.b, t.c);
    public static bool operator false(Triangle t) => !IsValid(t.a, t.b, t.c);
    public static Triangle operator *(Triangle t, int scalar) => new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);
    public static Triangle operator *(int scalar, Triangle t) => new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);

    public static implicit operator string(Triangle t) => t?.ToString();
    public static explicit operator Triangle(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException("Рядок не може бути порожнім.");
        string[] parts = s.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 4 &&
            int.TryParse(parts[0], out int a) &&
            int.TryParse(parts[1], out int b) &&
            int.TryParse(parts[2], out int c) &&
            int.TryParse(parts[3], out int color))
        {
            return new Triangle(a, b, c, color);
        }
        throw new InvalidCastException("Невірний формат рядка.");
    }
}