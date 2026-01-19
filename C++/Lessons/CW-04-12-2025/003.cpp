#include <iostream>

void print(int* arr, int size);
void swap(int* x, int* y);
void swap2(int& x, int& y);

int main()
{
    const int size{10};
    int arr[size]{1,4,2,6,34,87,223,6,23,4};

    // print(arr, size);

    int a{1};
    int b{2};

    // std::cout << a << " " << b << "\n";
    // swap(&a,&b);
    // swap2(a,b);
    // std::cout << a << " " << b << "\n";

    int* ptr = 0;
    std::cout << *ptr << "\n";


    return 0;
}

void print(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";
}

void swap(int* x, int* y)
{
    int t{*x};
    *x = *y;
    *y = t;
}

void swap2(int& x, int& y)
{
    int t{x};
    x = y;
    y = t;
}