#include <iostream>
#include <initializer_list>

template<typename T>
class Array
{
    int length;
    T* data;
public:
    Array(): length{}, data{nullptr} {}
    Array(int len): length{len}
    { data = new T[length]; }
    Array(const std::initializer_list<T>& list): Array(list.size())
    {
        int i{};
        for(auto& item: list)
        {
            data[i] = item;
            i++;
        }
    }

    ~Array()
    { delete[] data; }

    T& operator[](int index)
    { return data[index]; }

    int getLength() const
    { return length; }
};

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
    const int len{7};
    Array<double> arr{7.7,6,5,4.5,3,2.9,1};
    Array<Point> arrp{{1,2},{3,4},{5,6},{7,8}};

    for(int i{}; i<len; i++)
        std::cout << arr[i] << ' ';    
    std::cout << '\n';

    for(int i{}; i<arrp.getLength(); i++)
        std::cout << arrp[i] << ' ';    
    std::cout << '\n';
    std::cout << "\x07"; // Воспроизведет звук

    return 0;
}