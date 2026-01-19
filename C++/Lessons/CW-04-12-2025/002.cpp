#include <iostream>

int main()
{
    const int size{10};
    int arr[size]{1,4,2,6,34,87,223,6,23,4};

    int* ptr{ &arr[0] };
    // std::cout << ptr << " " << *ptr << "\n";

    // ptr = &arr[1];
    // std::cout << ptr << " " << *ptr << "\n";

    // ptr += 1;
    // std::cout << ptr << " " << *ptr << "\n";

    for(int i{}; i < size; i++)
    {
        // std::cout << *ptr << " ";
        // ptr++;

        // std::cout << ptr[i] << " ";

        std::cout << *(ptr + i) << " ";
    }

    return 0;
}