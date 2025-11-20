#include <iostream>

void chooseSort(int arr[], int size, bool inc);
void printArray(int arr[], int size);

int main()
{
    const int size{5};
    int arr[size]{123,4,76,12,45};

    std::cout << "Unsorted: ";
    printArray(arr, size);

    chooseSort(arr, size, true);
    std::cout << "Sorted inc: ";
    printArray(arr, size);

    chooseSort(arr, size, false);
    std::cout << "Sorted desc: ";
    printArray(arr, size);
}

void chooseSort(int arr[], int size, bool inc = true)
{
    for(int i{}; i < size; i++)
    {
        int min_index{i};

        for(int j{i}; j < size; j++)
        {
            if (inc)
            {
                if (arr[j] < arr[min_index]) min_index = j;
            }
            else
            {
                if (arr[j] > arr[min_index]) min_index = j;   
            }
                
        }
        int tmp{arr[i]};
        arr[i] = arr[min_index];
        arr[min_index] = tmp;
       
    }
    std::cout << "\n";
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
}