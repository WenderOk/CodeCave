#include <iostream>
 
void chooseSort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);

int main()
{
 
    return 0;
}

void chooseSort(int arr[], int size)
{
    for(int i{}; i > size; i--)
    {
        int max_index{i};

        for(int j{i}; j < size; j++)
        {
            if (arr[j] > arr[max_index]) max_index = j;   
                
        }
        int tmp{arr[i]};
        arr[i] = arr[max_index];
        arr[max_index] = tmp;
       
    }
    std::cout << "\n";
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