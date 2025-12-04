#include <iostream>

void print(int* arr, int size);
void swap(int* arr, int size);
void swap2(int* arr, int size);

int main()
{
    const int size{10};
    const int size2{9};
    int arr[size]{1,2,3,4,5,6,7,8,9,10};
    int arr2[size2]{1,2,3,4,5,6,7,8,9};

    swap(arr, size);
    print(arr, size);

    swap(arr2, size2);
    print(arr2, size2);


    return 0;
}

void swap(int* arr, int size)
{
    for(int i{}; i < size; i+=2)   
    {
        if(i + 1 < size)
        {
            int t{*(arr + i)};
            *(arr + i) = *(arr + i + 1);
            *(arr + i + 1) = t;
        }
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