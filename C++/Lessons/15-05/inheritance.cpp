#include <iostream>

class Point
{
protected:
    int x;
    int y;
public:
    Point(): x{}, y{}
    { std::cout << "Parent constructor\n"; }
    Point(int px, int py): x{px}, y{py}
    { std::cout << "Parent constructor\n"; }
    ~Point()
    { std::cout << "Parent destructor\n"; }

    int& getX()
    { return x; }

    int& getY()
    { return y; }
};

class Window: public Point
{
    int width;
    int height;
public:
    Window(int w, int h): width{w}, height{h}
    { std::cout << "Potomok constructor\n"; }
    Window(int px, int py, int w, int h)
        :Point(px, py), width{w}, height{h}
    { std::cout << "Potomok constructor\n"; }
    ~Window()
    { std::cout << "Potomok destructor\n"; }

    int& getWidth()
    { return width; }
    int& getHeight()
    { return height; }

    void moveX(int dx)
    { x+=dx; }
    void moveY(int dy)
    { x+=dy; }

    void show()
    { std::cout << "Corner: (" << getX() << ", " << getY() << ")\nwidth: " << getWidth() << " height: " << getHeight(); }
};


int main()
{
    Window w1{100, 50};
    w1.show();
    w1.getX() = 50;
    w1.getY() = 70;
    w1.getWidth() = 200;
    w1.getHeight() = 100;
    w1.show();

    std::cout << "\n";
    w1.moveX(25);
    w1.moveY(55);
    w1.show();

    std::cout << "\n";
    Window w2 {50, 50, 100, 200};
    w2.show();

    return 0;
}