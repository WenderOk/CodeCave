#include <iostream>

#include <cmath>

class  Point
{
    int x;
    int y;
public:
    Point()
    {}
    Point(double valX, double valY): x{valX}, y{valY}
    {}
    Point& setX(double value) = delete;
    Point& setX(int value)
    {
        x = value;
        return *this;
    }

    Point& setY(double value) = delete;
    Point& setY(int value)
    {
        y = value;
        return *this;
    }

    Point& print() 
    {
         std::cout << x << ", " << y << "\n";
         return *this;
    }
};

int main()
{
    Point p1;
    p1.setX(4).setY(8);
    p1.print();
    Point p2{2.32,3.53};

    p2.setX(5).setY(5).print();

 

    return 0;
}
