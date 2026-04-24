#include "../23-04_class-temp/Array.h"

struct Point
{
    int x;
    int y;

    Point operator+(Point p2)
    { return Point{x + p2.x, y + p2.y}; }

    friend std::ostream& operator<<(std::ostream& out, Point p);
};

std::ostream& operator<<(std::ostream& out, Point p)
{
    out << '(' << p.x << ' ' << p.y << ')';
    return out;
}

bool operator>(Point p1, Point p2)
{ return (p1.x + p1.y) > (p2.x + p2.y); }



int main()
{
    Array<Point> pointArr;
    pointArr.print();
    const size_t s(Array<Point>::getSize());
    
    for(size_t i{s}; i > 0; i--)
    { pointArr.setItem(s - i, Point{(int)i, (int)i}); }
    pointArr.print();

    pointArr.sort();

    pointArr.print();

    return 0;
}