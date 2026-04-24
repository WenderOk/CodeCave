#include <iostream>

template<class T>
void print(T value)
{ std::cout << value << '\n'; }

template<class T>
T sum(T value1, T value2)
{ return value1 + value2; }

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
    out << p.x << ' ' << p.y;
    return out;
}

int main()
{
    int n1{1};
    int n2{2};
    print(sum(n1, n2));

    double d1{1.1};
    double d2{2.2};
    print(sum(d1, d2));

    Point p1{1,1};
    Point p2{2,2};
    print(sum(p1, p2));

    return 0;
}