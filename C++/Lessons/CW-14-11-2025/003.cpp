#include <iostream>

int find_in_arr(int arr[], int len, int value);


int main()
{
    const int len{5};
    int arr[5]{123,54,76,12,6};

    int value{54};
    std::cout << "Enter a number: ";
    std::cin >> value;

    if(find_in_arr(arr, len, value) != -1)
        std::cout << "Number found!\nNumber index: " << find_in_arr(arr, len, value) << "\n";
    else
        std::cout << "Number not found...\n";
}

int find_in_arr(int arr[], int len, int value)
{
    int res{-1};
    for(int i{}; i < len; i++)
        if(arr[i] == value)
            {
                res = i;
                return i;
            }
    return res;
}