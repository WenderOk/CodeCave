#include <iostream>

void print(int* arr, int size);

int main()
{
    const int size{10};
    int arr[size]{1,4,2,6,34,87,223,6,23,4};

    print(arr, size);

    return 0;
}

void print(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << *(arr + i) << " ";
    }
    std::cout << "\n";
}