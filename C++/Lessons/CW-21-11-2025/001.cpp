#include <iostream>
#include <cstdlib>
#include <ctime>

void shakerSort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size {10};
    int arr[size]{};

    fillWithRand(arr, size);

    std::cout << "Unsorted: ";
    printArray(arr, size);
    std::cout << "\n";

    shakerSort(arr, size);

    std::cout << "Sorted: ";
    printArray(arr, size);
    return 0;    
}



void shakerSort(int arr[], int size)
{
    int j{};
    int k{size-1};
    int lb{1};
    int rb{size-1};

    do
    {
        for(j = rb; j > 0; j--)
        {
            if(arr[j - 1] > arr[j])
            {
                int tmp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = tmp;
                k = j;
            }
        }
        lb = k + 1;
        for(j = 1; j <= rb; j++)
        {
            if(arr[j - 1] > arr[j])
            {
                int tmp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = tmp;
                k = j;
            }
        }
        rb = k - 1;
    } while (lb < rb);
    
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
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