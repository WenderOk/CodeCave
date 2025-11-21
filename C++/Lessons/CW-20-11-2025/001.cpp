#include <iostream>

void bubbleSort(int arr[], int size, bool inc);
void printArray(int arr[], int size);

int main()
{
    const int size{6};
    int arr[size]{6,1,2,3,4,5};

    std::cout << "Unsorted: ";
    printArray(arr, size);
    std::cout << "\n";

    bubbleSort(arr, size, true);
    std::cout << "Sorted inc: ";
    printArray(arr, size);

    // bubbleSort(arr, size, false);
    // std::cout << "Sorted desc: ";
    // printArray(arr, size);
}

void bubbleSort(int arr[], int size, bool inc)
{
    for(int i{}; i < size; i++)
    {
        bool is_swap{false};
        for(int j{}; j < size-i-1; j++)
        {
            is_swap = false;
            std::cout << "\n";
            if ((inc) ? (arr[j] > arr[j+1]) : (arr[j] < arr[j+1]))
            {
                int tmp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = tmp;
                is_swap = true;
            }
            printArray(arr, size);
        }
        if (!is_swap)
            break;
    }
    std::cout << "\n";
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
}