#include <iostream>
#include <cstdlib>
#include <ctime>
 
// Functions for sorting
int pancakeSort(int arr[], int size);
int findMaxIndex(int arr[], int size);
void flip(int arr[], int k);
// Additional functions
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
    const int size{5};
    int arr[size]{3, 1, 5, 2, 4};

    fillWithRand(arr, size);
    std::cout << "Unsorted pancakes: ";
    printArray(arr, size);

    int flips = pancakeSort(arr, size);
    std::cout << "Sorted pancakes: ";
    printArray(arr, size);
    std::cout << "Flips made: " << flips << '\n';

    return 0;
}

int pancakeSort(int arr[], int size)
{
    int flips{};
    for(int i{size}; i > 1; i--)
    {
        int max_index = findMaxIndex(arr, i);
        if(max_index == i - 1) continue;

        if(max_index != 0)
        {
            flip(arr, max_index);
            flips++;
        } 

        flip(arr, i - 1);
        flips++;
    }

    return flips;
}

int findMaxIndex(int arr[], int size)
{
    int max_index{};

    for(int i{1}; i < size; i++)
    {
        if (arr[i] > arr[max_index]) max_index = i;   
    }

    return max_index;
}

void flip(int arr[], int k)
{
    int left{};
    int right{k};

    while(left < right)
    {
        int tmp{arr[left]};
        arr[left] = arr[right];
        arr[right] = tmp;

        left++;
        right--;
    }
}


void fillWithRand(int arr[], int size)
{
    std::srand(std::time({}));
    int rborder{100};
    int lborder{1};

    std::cout << "Enter range for random numbers: ";
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