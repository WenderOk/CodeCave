#include <iostream>
#include <cstdlib>
#include <ctime>

void quickSort(int arr[], int size);
void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);
int binSearch(int arr[], int size, int number);

int main()
{
    const int size{10};
    int arr[size]{3, 11, 21, 7, 31, 36, 40, 40, 44, 49};

    // fillWithRand(arr, size);
    printArray(arr, size);
    quickSort(arr, size);
    printArray(arr, size);

    int value{};
    std::cout << "Enter value to find: ";
    std::cin >> value;

    int result{binSearch(arr, size, value)};

    if (result)
        std::cout << "Value index is: " << result << "\n";
    else
        std::cout << "Value not found!" << "\n";

    return 0;
}

int binSearch(int arr[], int size, int number)
{
    int lb{0};
    int rb{size-1};
    int mid{rb / 2};

    while(1)
    {
        mid = (lb + rb) / 2;
        if(number == arr[mid]) 
            return mid;
        else if(number > arr[mid])
            lb = mid + 1;
        else
            rb = mid - 1;
        if (lb > rb)
            return -1;
    }

}


void quickSort(int arr[], int size)
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
    if(rb >= 0) quickSort(arr, rb+1);
    if(size > lb) quickSort(arr + lb, size - lb);
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