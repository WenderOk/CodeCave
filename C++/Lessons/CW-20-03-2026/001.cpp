#include <iostream>
#include <cmath>

class  Point
{
    double x;
    double y;
public:
    Point(double xp, double yp): x{xp}, y{yp}
    {}
    Point(): Point(0,0)
    {}

    void print() const
    { std::cout << x << " " << y << "\n"; }

    void read()
    {
        std::cout << "Enter x and y: ";
        std::cin >> x >> y;
    }

    static bool isEqual(const Point& p1, const Point& p2)
    { return (p1.x == p2.x) && (p1.y == p2.y); }
    bool operator==(const Point& p2)
    { return (x == p2.x) && (y == p2.y); }
    
    static Point mult(const Point& p, double value)
    { return Point(p.x * value, p.y * value); }
    // Point operator*(int value)
    // { return Point(x * value, y * value); }

    static double distance(const Point& p1, const Point& p2)
    { return std::sqrt((p1.x - p2.x) * (p1.x - p2.x) + 
                (p1.y - p2.y) * (p1.y - p2.y)); }
    double operator%(const Point& p2)
    { return std::sqrt((x - p2.x) * (y - p2.y)); }
    
    static double length(const Point& p)
    { return std::sqrt(p.x * p.x + p.y * p.y); }
    double operator!()
    { return std::sqrt(x * x + y * y); }

    friend Point operator+(const Point& p1, const Point& p2);
    friend Point operator-(const Point& p);
    friend Point operator*(const Point& p, double value);
    friend Point operator*(double value, const Point& p);
};

Point operator*(const Point& p, double value)
{ return Point(p.x * value, p.y * value); }

Point operator*(double value, const Point& p)
{ return Point(p.x * value, p.y * value); }

Point operator+(const Point& p1, const Point& p2)
{return Point(p1.x + p2.x, p1.y + p2.y);}

Point operator-(const Point& p)
{return Point(-p.x, -p.y);}


int main()
{
    Point p1{2,4};
    Point p2{3,2};
    Point sum{p1+p2};
    sum.print();

    (-sum).print();

    (p1 * 2).print();
    (2 * p1).print();
    

    return 0;
}