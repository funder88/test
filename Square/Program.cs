using System;
using Square;


namespace Square
{
    public class SquareClass
    {
        private double centerX;
        private double centerY;
        private double sideLength;

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
            Console.WriteLine($"Квадрат: центр ({centerX}, {centerY}), длина стороны: {sideLength}");
        }

        public double DistanceFromOrigin()
        {
            return Math.Sqrt(centerX * centerX + centerY * centerY);
        }

        public SquareClass Add(SquareClass sq1, SquareClass sq2)
        {
            SquareClass result = new SquareClass();
            result.Init((sq1.centerX + sq2.centerX) / 2,
                        (sq1.centerY + sq2.centerY) / 2,
                        (sq1.sideLength + sq2.sideLength) / 2);
            return result;
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
}

class Program
{
    static void Main(string[] args)
    {
        SquareClass square1 = new SquareClass();
        SquareClass square2 = new SquareClass();
        SquareClass square3 = new SquareClass();

        square1.Read();
        square2.Read();

        SquareClass result = square1.Add(square1, square2);

        Console.WriteLine("Сложение квадратов:");
        result.Display();

        square3.Read();
        Console.WriteLine($"Дистанция от начала координат до квадрата: {square3.DistanceFromOrigin()}");
    }
}
