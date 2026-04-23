#include <iostream>
#include <string>

template<class T>
class Array
{
    static const size_t size{5};
    T arr[size];  

public:
    Array();

    static size_t getSize()
    { return size; }
    
    T getItem(size_t index) const;
    void setItem(size_t index, T value);
    void print();
    void sort();
};

template<class T>
T Array<T>::getItem(size_t index) const
{
    if(index >= 0 && index <= size)
        return arr[index];
    else
        exit(1);
}

template<class T>
Array<T>::Array()
{ 
    for(int i{}; i < size; i++)
        arr[i] = T();
}

template<class T>
void Array<T>::setItem(size_t index, T value)
{
    if(index >= 0 && index <= size)
        arr[index] = value;
    else
        exit(1);
}

template<class T>
void Array<T>::print()
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << ' ';
    std::cout << '\n';
}

template<class T>
void Array<T>::sort()
{
    for(size_t i{size-1}; i > 0; i--)
    {
        for(size_t j{}; j < i; j++ )
            if(arr[j] > arr[j+1])
                std::swap(arr[j], arr[j+1]);
        
    }
}
