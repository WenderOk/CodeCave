#include <iostream>
#include <cstdlib>
#include <ctime>
 
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);
int linSearch(int arr[], int size, int number);

int main()
{
    const int size{10};
    int arr[size]{3, 11, 21, 7, 31, 36, 40, 40, 44, 49};

    fillWithRand(arr, size);
    printArray(arr, size);

    int value{};
    std::cout << "Enter value to find: ";
    std::cin >> value;

    int result{linSearch(arr, size, value)};

    if (result >= 0)
        std::cout << "Value index is: " << result << "\n";
    else
        std::cout << "Value not found!" << "\n";

    return 0;
}

int linSearch(int arr[], int size, int number)
{
    for(int i{}; i < size; i++)
        if(arr[i] == number) return i;
    return -1;
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

    for(int i{}; i < size; i++)
        arr[i] = std::rand() % rborder + lborder;
}