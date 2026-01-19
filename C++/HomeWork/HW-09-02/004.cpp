#include <iostream>
#include <cstdlib>
#include <ctime>
 
void bubbleSort(int arr[], int size);
void chooseSort(int arr[], int size, bool inc);

void fillWithRand(int arr[], int size);

int BUBBLE_SWAPS{};
int CHOOSE_SWAPS{};

int main()
{
    const int size{1000};
    int arr[size]{};
    int bubble_sum{};
    int choose_sum{};
    
    for(int i{}; i < 10; i++)
    {
        fillWithRand(arr, size);
        bubbleSort(arr, size);
        bubble_sum += BUBBLE_SWAPS;

        fillWithRand(arr, size);
        chooseSort(arr, size, true);
        choose_sum += CHOOSE_SWAPS;
    }

    std::cout << "Averege swaps for bubble sort: " << bubble_sum / 10.0 << '\n';
    std::cout << "Averege swaps for choose sort: " << choose_sum / 10.0 << '\n';

    return 0;
}

void bubbleSort(int arr[], int size)
{
    BUBBLE_SWAPS = 0;
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
                BUBBLE_SWAPS++;
            }
        }
        if (!is_swap)
            break;
    }
}

void chooseSort(int arr[], int size, bool inc = true)
{
    CHOOSE_SWAPS = 0;
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
        CHOOSE_SWAPS++;
    }
}

void fillWithRand(int arr[], int size)
{
    std::srand(std::time({}));
    int rborder{100};
    int lborder{1};

    for(int i{}; i < size; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }
}