#include <iostream>
#include "Array.h"

Array arrayFactory(int arrSize)
{
    Array arr{arrSize};
    arr.randomize();
    return arr;
}

int main()
{
    // Array arr1{10};
    // arr1.randomize();
    // std::cout << "Array 1: " << arr1 << "\n";
    // std::cout << "\n";

    // Array arr2{arr1};
    // std::cout << "Array 2: " << arr2 << "\n";
    // std::cout << "\n";

    // Array arr3{5};
    // std::cout << "Array 3 before copying: " << arr3 << "\n";
    // arr3 = arr2;
    // std::cout << "Array 3 after copying: " << arr3 << "\n";
    // std::cout << "\n";

    // Array arr1(arrayFactory(10));
    // std::cout << "Array 1: " << arr1 << "\n";

    Array arr1{ arrayFactory(15) };
    std::cout << "Array 1 " << arr1 << "\n\n";
    
    Array arr2{10};
    arr2.randomize();
    Array arr3{};
    arr3 = arr2;
    std::cout << "Array 3 " << arr3 << "\n\n";

    arr1 = arrayFactory(4);
    std::cout << "Array 1 " << arr1 << "\n\n";

    return 0;
}