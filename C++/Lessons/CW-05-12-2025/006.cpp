#include <iostream>

void print(int* arr, int size);


int main()
{  
    int size{};
    std::cout << "Enter size of array: ";
    std::cin >> size;

    // int arr [size]{};

    int* arr = new int[size]{};
    
    print(arr, size);

    delete[] arr;

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