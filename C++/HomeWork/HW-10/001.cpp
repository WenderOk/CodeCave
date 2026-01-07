#include <iostream>

void printArray(int arr[][5], int size1, int size2);
void fillArray(int arr[][5], int size1, int size2);

int main()
{
    const int size1{3};
    const int size2{5};

    int arr[size1][size2];

    fillArray(arr, size1, size2);
    printArray(arr, size1, size2);
    
    return 0;
}

void fillArray(int arr[][5], int size1, int size2)
{
    for(int i{}; i < size1; i++)
    {
        int number{};
        std::cout << "Enter a number: ";
        std::cin >> number;

        for(int j{}; j < size2; j++)
            arr[i][j] = (j == 0) ? number : arr[i][j - 1] * 2;
    }
}

void printArray(int arr[][5], int size1, int size2)
{
    for(int i{}; i < size1; i++)
    {
        for(int j{}; j < size2; j++)
            std::cout << arr[i][j] << " ";
        std::cout << '\n';
    }
}