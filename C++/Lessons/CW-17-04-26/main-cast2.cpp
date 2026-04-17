#include <iostream>

class Point3D;

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
    { return x || y; }

    explicit operator Point3D() const;
};


class Point3D
{
    int x;
    int y;
    int z;

public:
    Point3D() = default;
    Point3D(int xp, int yp, int zp): x{xp}, y{yp}, z{zp}
    {}

    Point3D& setX(int px)
    {
        x = px;
        return *this;
    }

    Point3D& setY(int py)
    {
        y = py;
        return *this;
    }

    Point3D& setZ(int pz)
    {
        z = pz;
        return *this;
    }

    void show() const
    { std::cout << x << ", " << y << ", " << z <<  "\n"; }

    operator bool() const
    { return x || y || z; }

    explicit operator Point() const;
};

Point::operator Point3D() const
{ return Point3D{x,y,0}; }

Point3D::operator Point() const
{ return Point{x,y}; }

int main()
{
    Point p{26,7};
    Point pConv{};

    Point3D p3d{5,-8,54};
    Point3D p3dConv{};

    pConv = (Point)p3d;
    p3dConv = (Point3D)p;

    pConv.show();
    p3dConv.show();

    return 0;
}