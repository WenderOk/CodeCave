#include <iostream>

class Point
{
    int x;
    int y;
public:
    Point(int xP, int yP) : x{xP}, y{yP}
    {}

    void print()
    {
        std::cout << x << " " << y;
    }
    
};