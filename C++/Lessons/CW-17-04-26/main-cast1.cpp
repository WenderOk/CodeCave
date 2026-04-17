#include <iostream>
#include <cmath>

class  Point
{
    int x;
    int y;
public:
    Point() = default;
    Point(int xp, int yp): x{xp}, y{yp}
    {}

    Point& setX(int px)
    {
        x = px;
        return *this;
    }

    Point& setY(int py)
    {
        y = py;
        return *this;
    }

    void show()
    { std::cout << x << ", " << y << "\n"; }

    operator bool() const
    { return x && y; }

    
};


int main()
{
    Point p1{5,2};
    Point p2{0,2};
    Point p3{-4,2};
    Point p4{8,0};
    Point p5{0,0};

    if(p1) { p1.show(); }
    if(p2) { p2.show(); }
    if(p3) { p3.show(); }
    if(p4) { p4.show(); }
    if(p5) { p5.show(); }
    

    return 0;
}