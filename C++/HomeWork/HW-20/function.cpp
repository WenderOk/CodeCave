#include <iostream>
#include <cstdlib>
#include <ctime>
#include <limits>

void fillArrayRandInt(int arr[], int size)
{
    srand(time({nullptr}));
    for(int i{}; i < size; i++)
        arr[i] = std::rand() % 100 + 1;
}

void printArrayInt(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

int minInArrayInt(int arr[], int size)
{
    int min{std::numeric_limits<int>::min()};
    for(int i{}; i < size; i++)
        if(arr[i] < min) min = arr[i];
    return min;
}

int maxInArrayInt(int arr[], int size)
{
    int max{std::numeric_limits<int>::max()};
    for(int i{}; i < size; i++)
        if(arr[i] > max) max = arr[i];
    return max;
}

void quickSortInt(int arr[], int size)
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
    if(rb >= 0) quickSortInt(arr, rb+1);
    if(size > lb) quickSortInt(arr + lb, size - lb);
}


void fillArrayRandDouble(double arr[], int size)
{
    srand(time({nullptr}));
    for(int i{}; i < size; i++)
        arr[i] = (double)rand() / RAND_MAX*(100.0 - 0.0) + 0.0;
}

void printArrayDouble(double arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

int minInArrayDouble(double arr[], int size)
{
    double min{std::numeric_limits<double>::min()};
    for(int i{}; i < size; i++)
        if(arr[i] < min) min = arr[i];
    return min;
}

int maxInArrayDouble(double arr[], int size)
{
    double max{std::numeric_limits<double>::max()};
    for(int i{}; i < size; i++)
        if(arr[i] > max) max = arr[i];
    return max;
}

void quickSortDouble(double arr[], int size)
{
    int lb{};
    int rb{size-1};
    double p{arr[size / 2]};

    do
    {
        while (arr[lb] < p) lb++;
        while (arr[rb] > p) rb--;
        if(lb <= rb)
        {
            double temp{arr[lb]};
            arr[lb] = arr[rb];
            arr[rb] = temp;
            lb++;
            rb--;
        }
    } while(lb <= rb);
    if(rb >= 0) quickSortDouble(arr, rb+1);
    if(size > lb) quickSortDouble(arr + lb, size - lb);
}



void fillArrayRandChar(char arr[], int size)
{
    srand(time({nullptr}));
    for(int i{}; i < size; i++)
        arr[i] = rand() % 221 + 33;
}

void printArrayChar(char arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

int minInArrayChar(char arr[], int size)
{
    char min{std::numeric_limits<char>::min()};
    for(int i{}; i < size; i++)
        if(arr[i] < min) min = arr[i];
    return min;
}

int maxInArrayChar(char arr[], int size)
{
    char max{std::numeric_limits<char>::max()};
    for(int i{}; i < size; i++)
        if(arr[i] > max) max = arr[i];
    return max;
}

void quickSortChar(char arr[], int size)
{
    int lb{};
    int rb{size-1};
    char p{arr[size / 2]};

    do
    {
        while (arr[lb] < p) lb++;
        while (arr[rb] > p) rb--;
        if(lb <= rb)
        {
            char temp{arr[lb]};
            arr[lb] = arr[rb];
            arr[rb] = temp;
            lb++;
            rb--;
        }
    } while(lb <= rb);
    if(rb >= 0) quickSortChar(arr, rb+1);
    if(size > lb) quickSortChar(arr + lb, size - lb);
}