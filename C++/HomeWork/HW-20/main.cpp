#include <iostream>

#define CHAR
#include "function.h"

int main()
{
    const int size{10};
    char arr[size]{};

    fillArrayRand(arr, size);
    printArray(arr, size);
    quickSort(arr, size);
    printArray(arr, size);
        
    return 0;
}