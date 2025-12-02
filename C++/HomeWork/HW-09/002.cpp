#include <iostream>
#include <cstdlib>
#include <ctime> 

void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size{10};
    int result_arr[size]{};
    int arr1[size]{};
    int arr2[size]{};

    fillWithRand(arr1, size);
    fillWithRand(arr2, size);

    std::cout << "First array: ";
    printArray(arr1,size);
    std::cout << "Second array: ";
    printArray(arr2,size);

    for(int i{}; i < size; i++)
    {
        result_arr[i] = arr1[i] + arr2[i];
    }
    std::cout << "Result array: ";
    printArray(result_arr, size);
    
 
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