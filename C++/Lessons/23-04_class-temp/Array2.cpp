#include <iostream>
#include <string>

template<class T, int size>
class Array2
{
    T arr[size];  
public:
    T* getArray();
    T& operator[](size_t index)
    { return arr[index]; }
};

template<class T, int size>
T* Array2<T, size>::getArray()
{ return arr; }

int main()
{
    const size_t s{10};
    Array2<int, s> arr;
    for(size_t i{}; i < s; i++)
        arr[i] = i;
    
    for(size_t i{}; i < s; i++)
        std::cout << arr[i] << ' ';
    std::cout << '\n';
    return 0;
}
