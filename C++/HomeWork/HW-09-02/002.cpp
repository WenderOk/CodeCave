#include <iostream>
#include <cstdlib>
#include <ctime>
 
void bubbleSort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size{5};
    int arr[size]{};

    fillWithRand(arr, size);

    std::cout << "Unsorted: ";
    printArray(arr, size);

    bubbleSort(arr, size);
    std::cout << "Sorted: ";
    printArray(arr, size);

    return 0;
}

void bubbleSort(int arr[], int size)
{
    for(int i{}; i < size; i++)
    {
        bool is_swap{false};
        for(int j{}; j < size-i-1; j++)
        {
            is_swap = false;
            if (arr[j] > arr[j+1])
            {
                int tmp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = tmp;
                is_swap = true;
            }
        }
        if (!is_swap)
            break;
    }
}

void fillWithRand(int arr[], int size)
{
    std::srand(std::time({}));
    int rborder{100};
    int lborder{1};

    std::cout << "Enter range (a, b): ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < size; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}