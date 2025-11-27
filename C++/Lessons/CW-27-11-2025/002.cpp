#include <iostream>
#include <cstdlib>
#include <ctime>
#include <climits>

void quick_sort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size {9};

    int arr[size]{6,1,2,3,4,5};
    fillWithRand(arr, size);
    printArray(arr, size);

    quick_sort(arr, size);
    printArray(arr, size);

    return 0;    
}

void quick_sort(int arr[], int size)
{
    int lb{};
    int rb{size-1};
    int p{arr[size / 2]};

    do
    {
        while (arr[lb] < p) lb++;
        while (arr[rb] > p) rb--;
        if(lb <= rb)
        {
            int temp{arr[lb]};
            arr[lb] = arr[rb];
            arr[rb] = temp;
            lb++;
            rb--;
        }
    } while(lb <= rb);
    if(rb >= 0) quick_sort(arr, rb+1);
    if(size > lb) quick_sort(arr + lb, size - lb);
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

    std::cout << "Enter range (a, b): ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < size; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }
}