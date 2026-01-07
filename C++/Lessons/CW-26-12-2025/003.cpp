#include <iostream>

auto func(int [][5], int) -> int(*)[5];
auto func2() -> int(*(*) (int arr[][5], int n))[5];

int main()
{
    int arr[2][5]{
        {1,3,6,2,4},
        {6,4,1,9,2}
    };
    std::cout << **func(arr, 2) << "\n";

    return 0;
}

// int(*func(int arr[][5], int n))[5]
// {
//     return &arr[0];
// }

auto func(int arr[][5], int n) -> int(*)[5]
{
    return &arr[0];
}

// int (*(*func2()) (int arr[][5], int n))[5]
// {
//     return func;
// }

auto func2() -> int(*(*) (int arr[][5], int n))[5]
{
        return func;
}