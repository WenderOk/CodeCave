#include <iostream>

void print(int* arr, int size);
void inputArray(int* arr, int size);

void fillDub(int arr1[], int arr2[], int result[], int size1, int size2, int res_size);
int findDub(int arr1[], int arr2[], int size1, int size2);

int main()
{  
    int size1{};
    int size2{};
    std::cout << "Enter size of 2 arrays: ";
    std::cin >> size1 >> size2;

    int* arr1{ new int[size1]{} };
    int* arr2{ new int[size2]{} };

    inputArray(arr1, size1);
    inputArray(arr2, size2);
    
    std::cout << "First array: ";
    print(arr1, size1);
    std::cout << "Second array: ";
    print(arr2, size2);

    int k = findDub(arr1, arr2, size1, size2);

    if(k == 0)
    {
        std::cout << "All elements of first array are included in second array.";
        return 0;
    }
    int* result = new int[k]{};
    
    fillDub(arr1, arr2, result, size1, size2, k);
    
    std::cout << "Result: ";
    print(result, k);

    return 0;
}

void fillDub(int arr1[], int arr2[], int result[], int size1, int size2, int res_size)
{
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
        if(!isIncluded)
        {
            result[k] = arr1[i];
            k++;
        }
    }
}

int findDub(int arr1[], int arr2[], int size1, int size2)
{
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
        if(!isIncluded) counter++;
    }
    return counter;
}

void inputArray(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << "Enter " << i+1 << " element: " ;
        std::cin >> arr[i];
    }
}

void print(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";
}