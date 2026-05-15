#include <iostream>

class Point
{
    int x;
    int y;

public:
    Point(int px, int py): x{px}, y{py}
    {}

    int getX() const
    { return x; }

    int getY() const
    { return y; }

    void setX(int px)
    { x = px; }

    void setY(int py)
    { y = py; }
};

class Circle
{
protected:
    Point center;
    int radius;
public:
    Circle(Point cen, int rad): center{cen}, radius{rad}
    {}
};

class Square
{
protected:
    Point corner;
    int side;
public:
    Square(Point cor, int s): corner{cor}, side{s}
    {}
    
};

class CircleSquare: public Square, public Circle
{
public:
    CircleSquare(Point cen, int rad)
        : Circle{cen, rad}, 
          Square{Point{cen.getX() - rad, cen.getY() - rad}, 2 * rad }
    {}

    void show() const
    {
        std::cout << "Center of circle: "
                  << "(" << center.getX() << ", " << center.getY() << ")"
                  << "\nRadius: " << radius
                  << "\nTop left corner: "
                  << "(" << corner.getX() << ", " <<  corner.getY() << ")"
                  << "\nSide size: " << side << "\n";
    }
};

int main()
{
    CircleSquare cs{Point{960, 540}, 150};
    cs.show();
    return 0;
}