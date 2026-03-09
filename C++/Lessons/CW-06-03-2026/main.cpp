#include <iostream>
#include "Point.h"
#include "Rectangle.h"

int main()
{
    Point p1{12,4};
    Point p2{};
    std::cout << "Point 1: ";
    p1.print();
    std::cout << "\nPoint 2: ";
    p2.print();

    Rectangle r1{31, 65, 100, 200};
    Rectangle r2{};

    std::cout << "\n\nRect 1: ";
    r1.print();
    std::cout << "\nRect 2: ";
    r2.print();

    return 0;
}
