#include <iostream>
#include <cstdlib>
#include <ctime>

int max_index(int arr[], int n)
{
    int index{};
    for(int i{}; i < n; i++)
       index = arr[i] > arr[index] ? i : index;
    return index;
}

void change_arr(int arr[], int n)
{
    std::cout << "Enter number: ";
    std::cin >> arr[0];
}

int main()
{
    const int num {10};
    int arr[num]{};
    std::srand(std::time({}));
    int rborder{};
    int lborder{};

    std::cout << "Enter left and right borders: ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < num; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }

    for(int i{}; i < num; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";
    
    //std::cout << "\n" << max_index(arr, num);
    change_arr(arr, num);

    for(int i{}; i < num; i++)
    {
        std::cout << arr[i] << " ";
    }
    std::cout << "\n";

    return 0;
}