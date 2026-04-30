#include <iostream>

void print()
{}

template<typename First, typename... Other>
void print(const First& first, const Other&... other)
{
    std::cout << first << ' ';
    print(other...);
}

template<typename... Args>
void println(const Args&... args)
{
    print(args...);
    std::cout << '\n';
}

struct Point
{
    int x;
    int y;
    friend std::ostream& operator<<(std::ostream& out, const Point p) 
    {
        out << '('<< p.x << ", " << p.y << ')';
        return out;
    }
};

int main()
{
    Point p{12,35};
    println("asd", 4, 4.5, p);
    

    return 0;
}