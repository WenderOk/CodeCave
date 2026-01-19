#include <iostream>

void print(int* arr, int size);

int main()
{  
    const int size{ 5 };
    int arr[size]{32,345,43,43,23};

    int size2{};
    std::cout << "Enter size of array: ";
    std::cin >> size2;
    int* arr2{ new int[size2]{} };

    for(int i{}; i < size2; i++)
    {
        std::cout << "Enter " << i+1 << " element: " ;
        std::cin >> arr2[i];
    }
    
    print(arr2, size2);

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