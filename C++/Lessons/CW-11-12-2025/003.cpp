#include <iostream>

void print(int* arr, int size);

int main()
{  
    const int size{ 1000 };
    int arr[size]{};

    int user_size{};
    std::cout << "Enter size of array: ";
    std::cin >> user_size;

    for(int i{}; i < user_size; i++)
    {
        std::cout << "Enter " << i+1 << " element: " ;
        std::cin >> arr[i];
    }

    print(arr, user_size);

    return 0;
}

void print(int* arr, int size)
{
    for(int i{}; i < size; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";
}