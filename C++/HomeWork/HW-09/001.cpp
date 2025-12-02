#include <iostream>
#include <cstdlib>
#include <ctime> 

void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size{10};
    const int size2{5};
    int origin_arr[size]{};
    int arr1[size2]{};
    int arr2[size2]{};

    fillWithRand(origin_arr, size);
    std::cout << "Original array: ";
    printArray(origin_arr, size);

    for(int i{}; i < size; i++)
    {
        if(i < size2) 
        {
            arr1[i] = origin_arr[i];
        }
        else
        {
            arr2[(size2 - i)*-1] = origin_arr[i];
        }
    }
    std::cout << "First half array: ";
    printArray(arr1,size2);
    std::cout << "Second half array: ";
    printArray(arr2,size2);
    
 
    return 0;
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

void fillWithRand(int arr[], int size)
{
    std::srand(std::time(nullptr));
    int rborder{100};
    int lborder{1};

    std::cout << "Enter range (a, b): ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < size; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }
}