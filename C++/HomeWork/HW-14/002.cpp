#include <iostream>

void printArray(int arr[], int size);
void inputArray(int* arr, int size);
int findInArray(int arr[], int size, int value);
int findDublicates(int arr1[], int arr2[], int size1, int size2);
int* createResultArr(int arr1[], int arr2[], int size1, int size2, int res_size);

// По сути модифицированная версия первой программы с дублированием циклов. Не очень красиво и оптимизировано получаеся, но зато работает

int main()
{
    int M{};
    int N{};
    std::cout << "Enter M and N: ";
    std::cin >> M >> N;

    int* A {new int[M]{}};
    int* B {new int[N]{}};

    inputArray(A, M);
    inputArray(B, N);
    
    std::cout << "Array A: ";
    printArray(A, M);
    std::cout << "Array B: ";
    printArray(B, N);

    int k = findDublicates(A, B, M, N);

    if(k == 0)
    {
        std::cout << "All elements of first array are included in second array.\n";
        return 0;
    }
    
    std::cout << "Result: ";
    printArray(createResultArr(A, B, M, N, k), k);

    return 0;
}

int findDublicates(int arr1[], int arr2[], int size1, int size2)
{
    int tmp_size{size1+size2};
    int* tmp{new int[tmp_size]{}};
    int counter{};
    for (int i{}; i < size1; i++)
    {
        bool isIncluded{false};
        for (int j{}; j < size2; j++)
        {
            if(arr1[i] == arr2[j])
            {
                isIncluded = true;
                break;
            }
        }  
        if(!isIncluded && (findInArray(tmp, tmp_size, arr1[i]) < 0)) 
        {
            tmp[i] = arr1[i];
            counter++;
        }
    }
    for (int i{}; i < size2; i++)
    {
        bool isIncluded{false};
        for (int j{}; j < size1; j++)
        {
            if(arr1[j] == arr2[i])
            {
                isIncluded = true;
                break;
            }
        }  
        if(!isIncluded && (findInArray(tmp, tmp_size, arr2[i]) < 0)) 
        {
            tmp[i] = arr2[i];
            counter++;
        }
    }
    return counter;
}

int* createResultArr(int arr1[], int arr2[], int size1, int size2, int res_size)
{
    int* result{new int[res_size]{}};
    int k{};
    for (int i{}; i < size1; i++)
    {
        bool isIncluded{false};
        for (int j{}; j < size2; j++)
        {
            if(arr1[i] == arr2[j]) 
            {
                isIncluded = true;
                break;
            }
        }  
        if(!isIncluded && (findInArray(result, res_size, arr1[i]) < 0))
        {
            result[k] = arr1[i];
            k++;
        }
    }
    for (int i{}; i < size2; i++)
    {
        bool isIncluded{false};
        for (int j{}; j < size1; j++)
        {
            if(arr1[j] == arr2[i]) 
            {
                isIncluded = true;
                break;
            }
        }  
        if(!isIncluded && (findInArray(result, res_size, arr2[i]) < 0))
        {
            result[k] = arr2[i];
            k++;
        }
    }
    return result;
}

int findInArray(int arr[], int size, int value)
{
    int res{-1};
    for(int i{}; i < size; i++)
        if(arr[i] == value)
            {
                res = i;
                return i;
            }
    return res;
}

void inputArray(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << "Enter " << i+1 << " element: " ;
        std::cin >> arr[i];
    }
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}