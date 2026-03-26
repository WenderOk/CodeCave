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
    friend Point& operator++(Point& p);
    friend const Point operator++(Point& p, int);
    friend Point& operator--(Point& p);
    // Point& operator++();
    const Point operator--(int);
    friend std::ostream& operator<< (std::ostream& output, const Point& p);
    friend std::istream& operator>> (std::istream& input, Point& p);
};

Point operator*(const Point& p, double value)
{ return Point(p.x * value, p.y * value); }

Point operator*(double value, const Point& p)
{ return Point(p.x * value, p.y * value); }

Point operator+(const Point& p1, const Point& p2)
{ return Point(p1.x + p2.x, p1.y + p2.y); }

Point operator-(const Point& p)
{ return Point(-p.x, -p.y); }

// Префикс 
Point& operator++(Point& p)
{
    ++(p.x);
    ++(p.y); 
    return p;
}

// Постфикс
const Point operator++(Point& p, int)
{
    Point point(p.x ,p.y);
    ++p;
    return point;
}

Point& operator--(Point& p)
{
    --(p.x);
    --(p.y); 
    return p;
}

// Point& Point::operator++()
// {
//     ++x;
//     ++y;
//     return *this;
// }

const Point Point::operator--(int)
{
    Point point(x, y);
    --(*this);
    return point;
}


std::ostream& operator<< (std::ostream& output, const Point& p)
{
    output << "(" << p.x << ", " << p.y << ")";
    return output;
}
std::istream& operator>> (std::istream& input, Point& p)
{
    input >> p.x;
    input.ignore(1);
    input >> p.y;
    return input;
}




int main()
{
    Point p1{2,3};
    Point p2{2,3};

    Point sum1;
    Point sum2;
    sum1 = p1++*2;
    sum2 = ++p2*2;
    // sum1.print();
    // sum2.print();
    // p1.print();
    // p2.print();

    Point p3;
    // std::cin >> p3;
    // std::cout << p3;

    p1 = p2 = p3 = Point(2,1);
    p1=p1;
    std::cout << p1 << ", " << p2 << ", " << p3 << "\n";

    return 0;
}