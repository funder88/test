using System;

class Square
{
    protected double centerX;
    protected double centerY;
    protected double sideLength;

    public Square() { }

    public Square(double x, double y, double s)
    {
        centerX = x;
        centerY = y;
        sideLength = s;
    }

    public void Init(double x, double y, double s)
    {
        centerX = x;
        centerY = y;
        sideLength = s;
    }

    public void Read()
    {
        Console.Write("Введите координаты центра квадрата и длину стороны квадрата (x y s): ");
        string[] input = Console.ReadLine().Split(' ');
        centerX = Convert.ToDouble(input[0]);
        centerY = Convert.ToDouble(input[1]);
        sideLength = Convert.ToDouble(input[2]);
    }

    public void Display()
    {
        Console.WriteLine("Квадрат: центр ({0}, {1}), длина стороны: {2}", centerX, centerY, sideLength);
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(centerX * centerX + centerY * centerY);
    }

    public double GetX()
    {
        return centerX;
    }

    public double GetY()
    {
        return centerY;
    }

    public double GetS()
    {
        return sideLength;
    }
}

class Rectangle : Square
{
    private double ratio;

    public Rectangle() : base() { }

    public Rectangle(double x, double y, double s, double r) : base(x, y, s)
    {
        ratio = r;
    }

    public new void Init(double x, double y, double s, double r)
    {
        base.Init(x, y, s);
        ratio = r;
    }

    public new void Display()  // Добавлено new
    {
        base.Display();
        Console.WriteLine("Отношение сторон: {0}", ratio);
    }

    public new double DistanceFromOrigin()
    {
        return base.DistanceFromOrigin();
    }

    public void Assign(Square b)
    {
        this.centerX = b.GetX();
        this.centerY = b.GetY();
        this.sideLength = b.GetS();
        this.ratio = b.DistanceFromOrigin();
    }

    public void Put(double r)
    {
        ratio = r;
    }

    public double Get()
    {
        return ratio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square();
        square.Init(9, 3, 3);
        Rectangle rect = new Rectangle();
        rect.Init(1, 7, 7, 5.2);

        square.Display();
        Console.WriteLine("Дистанция от начала координат до квадрата: {0}", square.DistanceFromOrigin());

        rect.Display();
        Console.WriteLine("Дистанция от начала координат до прямоугольника: {0}", rect.DistanceFromOrigin());

        // Присваивание объекта базового класса объекту производного класса
        Console.WriteLine();
        rect.Assign(square);
        square.Display();
        Console.WriteLine("Дистанция от начала координат до квадрата: {0}", square.DistanceFromOrigin());

        rect.Display();
        Console.WriteLine("Дистанция от начала координат до прямоугольника: {0}", rect.DistanceFromOrigin());
    }
}