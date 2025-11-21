#include <iostream>
#include <cstdlib>
#include <ctime>
#include <climits>

void guardinsertSort(int arr[], int size);
void insertSort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size {100'000};

    int arr[size]{};
    fillWithRand(arr, size);
    
    int arr2[size]{};
    fillWithRand(arr2, size);

    int t1_start = std::time(nullptr);
    insertSort(arr, size);
    int t1_end = std::time(nullptr);

    std::cout << "insert sort: " << t1_end - t1_start << "\n";
    
    int t2_start = std::time(nullptr);
    guardinsertSort(arr2, size);
    int t2_end = std::time(nullptr);
    
    std::cout << "insert sort: " << t2_end - t2_start << "\n";
    return 0;    
}

void guardinsertSort(int arr[], int size)
{
    int t{arr[0]}; 
    arr[0] = std::numeric_limits<int>::min();
    for(int i{1}; i < size; i++)
    {
        for (int j{i}; arr[j] < arr[j - 1]; j--)
        {
            int tmp = arr[j - 1];
            arr[j - 1] = arr[j];
            arr[j] = tmp;
        }
    }
    int i{};
    for(; t > arr[i]; i++)
    {
        arr[i - 1] = arr[i];
    }
    arr[i - 1] = t;
}

void insertSort(int arr[], int size)
{
    for(int i{1}; i < size; i++)
    {
        for (int j{i}; arr[j] < arr[j - 1]; j--)
        {
            int tmp = arr[j - 1];
            arr[j - 1] = arr[j];
            arr[j] = tmp;
        }
    }
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
}

void fillWithRand(int arr[], int size)
{
    std::srand(std::time(nullptr));
    int rborder{100};
    int lborder{1};

    std::cout << "Enter range (a, b): ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < size; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }
}