#include <iostream>
#include <cmath>

class Square {
protected:
    double centerX;
    double centerY;
    double sideLength;

public:
    Square(double x = 0, double y = 0, double s = 0);
    void Init(double x, double y, double s);
    void Read();
    void Display();
    double DistanceFromOrigin();
    double GetX();
    double GetY();
    double GetS();
};

Square::Square(double x, double y, double s) {
    centerX = x;
    centerY = y;
    sideLength = s;
}

void Square::Init(double x, double y, double s) {
    centerX = x;
    centerY = y;
    sideLength = s;
}

void Square::Read() {
    std::cout << "Введите координаты центра квадрата и длину стороны квадрата (x y s): ";
    std::cin >> centerX >> centerY >> sideLength;
}

void Square::Display() {
    std::cout << "Квадрат: центр (" << centerX << ", " << centerY << "), длина стороны: " << sideLength << "\n";
}

double Square::DistanceFromOrigin() {
    return std::sqrt(centerX * centerX + centerY * centerY);
}

double Square::GetX() {
    return centerX;
}

double Square::GetY() {
    return centerY;
}

double Square::GetS() {
    return sideLength;
}

class Rectangle : public Square {
private:
    double ratio;

public:
    Rectangle(double x = 0, double y = 0, double s = 0, double r = 0);
    void Init(double x, double y, double s, double r);
    void Read();
    void Display();
    double DistanceFromOrigin();
    void operator=(Square b);
    void Put(double r);
    double Get();
};

Rectangle::Rectangle(double x, double y, double s, double r) : Square(x, y, s) {
    ratio = r;
}

void Rectangle::Init(double x, double y, double s, double r) {
    Square::Init(x, y, s);
    ratio = r;
}

void Rectangle::Display() {
    std::cout << "Прямоугольник: центр (" << centerX << ", " << centerY << "), длина стороны: " << sideLength << ", отношение сторон: " << ratio << "\n";
}

double Rectangle::DistanceFromOrigin() {
    return std::sqrt(centerX * centerX + centerY * centerY);
}

void Rectangle::operator=(Square b) {
    this->centerX = b.GetX();
    this->centerY = b.GetY();
    this->sideLength = b.GetS();
    this->ratio = 1.0;
}

void Rectangle::Put(double r) {
    ratio = r;
}

double Rectangle::Get() {
    return ratio;
}

int main() {
    setlocale(LC_ALL, "Russian");

    Square square;
    square.Init(9, 3, 3);
    Rectangle rect;
    rect.Init(1, 7, 7, 5.2);

    rect = square;

    square.Display();

    std::cout << "Дистанция от начала координат до квадрата: " << square.DistanceFromOrigin() << std::endl;

    rect.Display();
    std::cout << "Дистанция от начала координат до прямоугольника: " << rect.DistanceFromOrigin() << std::endl;

    Square square1(1, 1, 4);
    Rectangle rect1(2, 2, 5, 1.5);

    square1.Display();
    std::cout << "Дистанция от начала координат до квадрата: " << square1.DistanceFromOrigin() << std::endl;

    rect1.Display();
    std::cout << "Дистанция от начала координат до прямоугольника: " << rect1.DistanceFromOrigin() << std::endl;

    Square* square2 = new Square(3, 3, 6);
    Rectangle* rect2 = new Rectangle(4, 4, 7, 2.0);

    square2->Display();
    std::cout << "Дистанция от начала координат до квадрата: " << square2->DistanceFromOrigin() << std::endl;

    rect2->Display();
    std::cout << "Дистанция от начала координат до прямоугольника: " << rect2->DistanceFromOrigin() << std::endl;

    delete square2;
    delete rect2;

    return 0;
}