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

    static Point add(const Point& p1, const Point& p2)
    { return Point(p1.x + p2.x, p1.y + p2.y); }
    Point operator+(const Point& p2)
    {return Point(x + p2.x, y + p2.y);}
    
    static Point mult(const Point& p, double value)
    { return Point(p.x * value, p.y * value); }
    Point operator*(int value)
    { return Point(x * value, y * value); }

    static double distance(const Point& p1, const Point& p2)
    { return std::sqrt((p1.x - p2.x) * (p1.x - p2.x) + 
                (p1.y - p2.y) * (p1.y - p2.y)); }
    double operator%(const Point& p2)
    { return std::sqrt((x - p2.x) * (y - p2.y)); }
    
    static double length(const Point& p)
    { return std::sqrt(p.x * p.x + p.y * p.y); }
    double operator!()
    { return std::sqrt(x * x + y * y); }
   
};


int main()
{
    Point p1{1,1};
    Point p2;
    Point p3{1,1};

    p1.print();
    p3.print();

    if(p1 == p3)
        std::cout << "Equal\n";
    else 
        std::cout << "Not equal\n";

    p2.read();

    std::cout << "Sum of p1 and p2: ";
    (p1 + p2).print();
    std::cout << "Mul of p2 and 10: ";
    (p2 * 10).print();

    std::cout << "Distance between p1 and p2: ";
    std::cout << Point::distance(p1,p2);
    

    return 0;
}