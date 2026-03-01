#include <iostream>

#define INTEGER
#include "function.h"

int main()
{
    const int size{10};
    int arr[size]{};

    fillArrayRand(arr, size);
    std::cout << "Random array: ";
    printArray(arr, size);
    quickSort(arr, size);
    std::cout << "Sorted array: ";
    printArray(arr, size);
    changeArray(arr, size, 5, 1000);
    std::cout << "Changed array: ";
    printArray(arr, size);
    std::cout << "Minimum element in array: " << minInArray(arr, size) << "\n";
    std::cout << "Maximum element in array: " << maxInArray(arr, size) << "\n";

        
    return 0;
}