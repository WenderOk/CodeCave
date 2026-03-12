#include <iostream>

class Point
{
private:
    /* data */
public:
    int x;
    int y;
    static double PI;

    Point() : x{}, y{}
    {}
    Point(int xP, int yP) : x{xP}, y{yP}
    {}

    void print()
    {
        std::cout << x << " " << y << " " << PI << "\n";
    }
};

double Point::PI{3.14};