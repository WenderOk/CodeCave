#include <iostream>

void sort(int arr[], int len);

int main()
{
    const int len{5};
    int arr[5]{123,54,76,12,6};

    std::cout << "Unsorted: ";
    for(int i{}; i < len; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";

    sort(arr,len);

    std::cout << "Sorted: ";
    for(int i{}; i < len; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

void sort(int arr[], int len)
{
    for(int i{}; i < len; i++)
    {
        for(int j{i}; j < len; j++)
        {
            int mn{};
            if (arr[i] > arr[j])
                {
                    mn = arr[j];
                    arr[j] = arr[i];
                    arr[i] = mn;
                }
        }
    }
}