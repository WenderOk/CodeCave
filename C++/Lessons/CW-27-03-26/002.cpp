#include <iostream>
#include "Array.h"

int main()
{
    Array arr1{5};
    Array arr2;

    for(int i{}; i < arr1.len(); i++)
    { arr1[i] = i; }

    for(int i{}; i < arr2.len(); i++)
    { arr2[i] = i+11; }

    std::cout << "Size: " << arr1.len() << "\nArray: " << arr1 << "\n";
    std::cout << "Size: " << arr2.len() << "\nArray: " << arr2 << "\n";

    Array arr3{5};
    // for(int i{}; i < arr3.len(); i++)
    // {
    //     std::cout <<"Enter " << i+1 << " item: ";
    //     std::cin >> arr3[i]; 
    // }

    // std::cout << "Size: " << arr3.len() << "\nArray: " << arr3 << "\n";

    if(arr1 == arr2) std::cout << "Equal\n";
    else std::cout << "Not equal\n";

    Array arr4{arr1};

    if(arr1 == arr4) std::cout << "Equal\n";
    else std::cout << "Not equal\n";

    arr1 = arr2;

    std::cout << "Size: " << arr1.len() << "\nArray: " << arr1 << "\n";
    std::cout << "Size: " << arr2.len() << "\nArray: " << arr2 << "\n";

    arr1[13] = 123;


    return 0;
}