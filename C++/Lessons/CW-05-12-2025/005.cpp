#include <iostream>

void print(int* arr, int size);
int& rmax(int arr[], int size);

int main()
{  
    const int size{5};
    int arr[size]{1,2,3,4,5};    

    rmax(arr, size) = 0;

    print(arr, size);

    return 0;
}


int& rmax(int arr[], int size)
{
    int im{};
    for (int i{1}; i < size; i++)
    {
        im = arr[im] < arr[i] ? i : im;
    }
    return arr[im];
}

void print(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";
}